using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Text_RPG.Program;

namespace Text_RPG
{
    internal class Program
    {
        public interface ICharacter
        {
            string Name { get; }  // 캐릭터 이름
            int Level { get; }    // 캐릭터 레벨
            string Job { get; }   // 캐릭터 직업
            int Attack { get; }   // 기본 공격력
            int Defense { get; }  // 기본 방어력
            int Health { get; }   // 체력
            int Gold { get; set; }  // 보유 골드

            Inventory Inventory { get; }  // 캐릭터의 인벤토리

            void ShowStatus();  // 캐릭터 상태 출력

            int GetTotalAttack();  // 장비를 포함한 총 공격력 계산
            int GetTotalDefense(); // 장비를 포함한 총 방어력 계산
        }

        public abstract class Character : ICharacter
        {
            public string Name { get; set; }    // 플레이어의 이름
            public int Level { get; set; } = 1; //  캐릭터 레벨 (기본값 1)
            public abstract string Job { get; } // 직업
            public abstract int Attack { get; } // 기본 공격력
            public abstract int Defense { get; }// 기본 방어력
            public virtual int BaseHealth => 100; // 기본 체력 설정 가능
            public int Health { get; set; } // 현재 체력
            public int Gold { get; set; } = 15000;   // 보유 골드
            public Inventory Inventory { get; set; }    //인벤토리

            public Character(string name)  // 캐릭터 생성, 기본 체력 설정, 인벤토리 생
            {
                Name = name;
                Health = BaseHealth;
                Inventory = new Inventory(this);
            }

            public int GetTotalAttack() // 총 공격력 계산 (기본 공격력 + 장착 아이템 공격력 보너스)
            {
                int totalAttack = Attack;
                foreach (var item in Inventory.GetEquippedItems())
                    totalAttack += item.AttackBonus;
                return totalAttack;
            }

            public int GetTotalDefense()    // 총 방어력 계산 (기본 방어력 + 장착 아이템 방어력 보너스)
            {
                int totalDefense = Defense;
                foreach (var item in Inventory.GetEquippedItems())
                    totalDefense += item.DefenseBonus;
                return totalDefense;
            }

            public void ShowStatus()    // 캐릭터 상태 출력 (레벨, 직업, 공격력, 방어력, 체력, 골드)
            {
                Console.Clear();
                Console.WriteLine($"Lv. {Level}");
                Console.WriteLine($"{Name} ({Job})");

                int totalAttack = GetTotalAttack();
                int totalDefense = GetTotalDefense();
                int attackBonus = totalAttack - Attack;   // 추가 공격력 (장비 보너스)
                int defenseBonus = totalDefense - Defense; // 추가 방어력 (장비 보너스)

                Console.WriteLine($"공격력 : {totalAttack} {(attackBonus > 0 ? $"(+{attackBonus})" : "")}");
                Console.WriteLine($"방어력 : {totalDefense} {(defenseBonus > 0 ? $"(+{defenseBonus})" : "")}");
                Console.WriteLine($"체  력 : {Health}");
                Console.WriteLine($"Gold : {Gold} G\n");
                Console.WriteLine("0. 나가기\n");

                Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                if (Console.ReadLine() == "0") return;
            }
        }

        public class Warrior : Character
        {
            public override string Job => "전사"; // 직업
            public override int Attack => 10;   // 기본 공격력
            public override int Defense => 5;   // 기본 방어력
            public override int BaseHealth => 120;  //기초 체력
            
            public Warrior(string name) : base(name) { }    // 이름을 받아 부모 클래스 생성자 호출
        }

        public class Wizard : Character
        {
            public override string Job => "마법사";
            public override int Attack => 10;
            public override int Defense => 5;

            public Wizard(string name) : base(name) { }
        }

        public class Rogue : Character
        {
            public override string Job => "도적";
            public override int BaseHealth => 85;

            public override int Attack => 10;
            public override int Defense => 5;

            public Rogue(string name) : base(name) { }
        }
        public class Item   // 아이템 클래스
        {
            public string Name { get; }         // 아이템 이름
            public string Description { get; }  // 설명
            public Item(string name, string description)    // 아이템 이름과 설명 설정
            {
                Name = name;
                Description = description;
            }

            public virtual string GetItemInfo()     // virtual를 이용하여 아이템 정보 출력
            {
                return $"{Name} | {Description}";
            }
        }
        public class EquipItem : Item   // 장비 아이템 클래스 (공격력 or 방어력 보너스)
        {
            public int Price { get; set; }          // 아이템 가격 
            public int AttackBonus { get; }         // 공격력
            public int DefenseBonus { get; }        // 방어력
            public bool IsEquipped { get; set; }    // 장착 여부

            // 생정자 : 이름, 설명, 장비의 공격력과 방어력 설정
            public EquipItem(string name, string description, int attackBonus, int defenseBonus)
                : base(name, description)
            {
                AttackBonus = attackBonus;
                DefenseBonus = defenseBonus;
                IsEquipped = false; // 기본값: 장착 안 됨
            }

            public override string GetItemInfo()
            {
                string equipMarker = IsEquipped ? "[E] " : "";   // 장착한 아이템 표시
                // 공격력 보너스가 0보다 크면 "공격력 +X" 형식으로 출력하고, 그렇지 않으면 "방어력 +X"로 출력
                string statBonus = AttackBonus > 0 ? $"공격력 +{AttackBonus}" : $"방어력 +{DefenseBonus}";
                // 장착 여부, 아이템 이름, 보너스 스탯, 설명을 하나의 문자열로 반환
                return $"{equipMarker}{Name}      | {statBonus}      | {Description}";
            }
        }

        public class Inventory
        {
            private List<Item> items = new List<Item>();    // 인벤토리에 저장할 리스트
            private ICharacter owner;   // 인벤토리의 소유자

            public Inventory(ICharacter character)  // 특정 캐릭터의 인벤토리 생성
            {
                owner = character;
            }
            public void AddItem(Item item)  // 아이템 추가
            {
                items.Add(item);
            }

            public bool HasItem(Item item)  // 아이템이 인벤토리에 있는지 확인
            {
                // 인벤토리에 특정 아이템이 존재하는지 확인 (이름이 같은 아이템이 있는지 검사)
                return items.Any(i => i.Name == item.Name);
            }

            public List<EquipItem> GetEquippedItems()   // 장착된 아이템 목록 반환
            {
                // 장착된 장비 아이템만 필터링하여 리스트로 반환 (OfType<>()로 필터링)
                return items.OfType<EquipItem>().Where(e => e.IsEquipped).ToList();
            }

            public void ShowInventory()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("인벤토리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                    Console.WriteLine("[아이템 목록]\n");

                    if (items.Count == 0)
                    {
                        Console.WriteLine("현재 보유 중인 아이템이 없습니다.");
                    }
                    else
                    {
                        foreach (var item in items) // 보유 중인 아이템 목록 출력
                            Console.WriteLine($"- {item.GetItemInfo()}");
                    }

                    Console.WriteLine("\n1. 장착 관리");
                    Console.WriteLine("0. 나가기\n");
                    Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                    string input = Console.ReadLine();

                    if (input == "0") break; // 0 입력 시 종료
                    else if (input == "1") ManageEquipment();   // 장착 관리 실행
                }
            }
            public void ManageEquipment()   // 인벤토리 - 장착 관리
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("인벤토리 - 장착 관리");
                    Console.WriteLine("보유 중인 장비를 장착하거나 해제할 수 있습니다.\n");

                    // 보유 중인 장비 아이템 목록 가져오기
                    List<EquipItem> equipItems = items.OfType<EquipItem>().ToList();

                    if (equipItems.Count == 0)
                    {
                        Console.WriteLine("장착 가능한 아이템이 없습니다.");
                        Console.WriteLine("아무 키나 눌러 나가기...");
                        Console.ReadKey();
                        return;
                    }
                    // 장비 아이템 출력
                    Console.WriteLine("[아이템 목록]\n");
                    for (int i = 0; i < equipItems.Count; i++)
                    {
                        string equipStatus = equipItems[i].IsEquipped ? "" : "";
                        Console.WriteLine($"{i + 1}.{equipStatus}{equipItems[i].GetItemInfo()}");
                    }

                    Console.WriteLine("\n0. 나가기");
                    Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        if (choice == 0) return;

                        if (choice > 0 && choice <= equipItems.Count)   // 선택지 확인
                        {
                            EquipItem selectedItem = equipItems[choice - 1];
                            selectedItem.IsEquipped = !selectedItem.IsEquipped; // 장착/해제 토글
                            Console.WriteLine($"{selectedItem.Name} {(selectedItem.IsEquipped ? "장착" : "해제")} 완료!");
                        }
                        else
                            Console.WriteLine("올바른 번호를 입력하세요.");
                    }
                    else
                        Console.WriteLine("숫자를 입력해주세요.");
                }
            }
        }

        public class StartGame
        {
            public void StartMenu()
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
            }
        }
        public class CharacterSelection
        {
            public static ICharacter SelectCharacter(string playerName)
            {
                while (true)
                {
                    Console.WriteLine("직업을 선택하세요:");
                    Console.WriteLine("1. 전사");
                    Console.WriteLine("2. 마법사");
                    Console.WriteLine("3. 도적");
                    Console.Write(">> ");

                    if (int.TryParse(Console.ReadLine(), out int jobChoice))
                    {
                        switch (jobChoice)
                        {
                            case 1: return new Warrior(playerName);
                            case 2: return new Wizard(playerName);
                            case 3: return new Rogue(playerName);
                            default:
                                Console.WriteLine(" 잘못된 입력입니다. 1~3 사이의 숫자를 입력하세요.");
                                break;
                        }
                    }
                    else Console.WriteLine("숫자를 입력해주세요.");
                }
            }
        }

        public class Store
        {
            private List<EquipItem> itemsForSale;   // 상점에서 판매하는 아이템 목록
            private ICharacter player;              // 플레이어 정보


            public Store(ICharacter player) // 아이템 목록
            {
                this.player = player;
                itemsForSale = new List<EquipItem>
                {
                    new EquipItem("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 0, 5) { Price = 1000 },
                    new EquipItem("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 9) { Price = 2000 },
                    new EquipItem("스파르타의 갑옷", "스파르타 전사들이 사용한 전설의 갑옷입니다.", 0, 15) { Price = 3500 },
                    new EquipItem("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 2, 0) { Price = 600 },
                    new EquipItem("청동 도끼", "어디선가 사용됐던 도끼입니다.", 5, 0) { Price = 1500 },
                    new EquipItem("스파르타의 창", "스파르타 전사들이 사용한 전설의 창입니다.", 7, 0) { Price = 4000 },
                    // 새로운 아이템 추가
                    new EquipItem("99강 막대기", "한때는 누군가의 장비였을지도 모릅니다.", 12, 0) { Price = 6000 },
                    new EquipItem("눈의 요정의 갑옷", "단단한 얼음으로 만들어진 갑옷입니다.", 0, 7) { Price = 4000 },
                };
            }

            public void ShowStore() // 상점 UI 출력 및 아이템 목록 표시
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다");
                Console.WriteLine();

                Console.WriteLine($"[보유 콜드]");  // 현재 플레이어의 골드 출력
                Console.WriteLine($"{player.Gold} G");
                Console.WriteLine();
                Console.WriteLine($"[아이템 목록]");

                for (int i = 0; i < itemsForSale.Count; i++)    // 상점의 판매 아이템 목록 출력
                {
                    EquipItem item = itemsForSale[i];
                    bool isPurchased = player.Inventory.HasItem(item);  // 플레이어가 이미 구매한 아이템인지 확인
                    string priceDisplay = isPurchased ? "구매완료" : $"{item.Price} G"; // 구매 여부에 따라 가격 표시 변경

                    Console.WriteLine($"{i + 1}. {item.Name} | 공격력 +{item.AttackBonus} | 방어력 +{item.DefenseBonus} | {item.Description} | {priceDisplay}");
                }

                Console.WriteLine();
                Console.WriteLine("0. 나가기\n");
                Console.Write(">> ");
            }

            public void BuyItem()
            {
                while (true)
                {
                    Console.Clear();
                    ShowStore();    // 상점 UI 출력

                    Console.Write("구매할 아이템 번호를 입력하세요 (0: 나가기) >> ");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int choice))   // 입력값이 숫자인지 확인
                    {
                        Console.WriteLine("잘못된 입력입니다. 숫자를 입력해주세요.");
                    }
                    else if (choice == 0)
                    {
                        return; // 나가기
                    }
                    else if (choice < 1 || choice > itemsForSale.Count)
                    {
                        Console.WriteLine("유효한 번호를 입력하세요.");
                    }
                    else
                    {
                        EquipItem selectedItem = itemsForSale[choice - 1];

                        if (player.Inventory.HasItem(selectedItem)) // 이미 구매한 아이템인지 확인
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else if (player.Gold < selectedItem.Price)  // 골드 부족 여부 확인
                        {
                            Console.WriteLine("Gold가 부족합니다.");
                        }
                        else
                        {
                            player.Gold -= selectedItem.Price;  // 골드 차감

                            // 새로운 인스턴스를 생성해서 플레이어 인벤토리에 추가
                            EquipItem newItem = new EquipItem(
                                selectedItem.Name,
                                selectedItem.Description,
                                selectedItem.AttackBonus,
                                selectedItem.DefenseBonus)
                            {
                                Price = selectedItem.Price
                            };

                            player.Inventory.AddItem(newItem); // 새로운 아이템 추가
                            Console.WriteLine($"{newItem.Name}을(를) 구매했습니다!");
                            // 상태 갱신을 위해 상점 UI 다시 출력
                            ShowStore();
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //  1. 플레이어 이름 입력
            Console.Write("플레이어의 이름을 입력하세요: ");
            string name = Console.ReadLine();

            //  2. 직업 선택 (CharacterSelection 클래스로 분리)
            ICharacter player = CharacterSelection.SelectCharacter(name);

            StartGame startGame = new StartGame();
            Store store = new Store(player);

            while (true)
            {
                Console.Clear();
                startGame.StartMenu();

                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == 0)
                    {
                        Console.WriteLine("게임을 종료합니다.");
                        break;
                    }
                    else if (input == 1)    // 상태 보기
                    {
                        player.ShowStatus();
                    }
                    else if (input == 2)    // 인벤토리
                    {
                        player.Inventory.ShowInventory();
                    }
                    else if (input == 3)    // 상점
                    {
                        store.ShowStore();
                        store.BuyItem();
                    }
                    else
                        Console.WriteLine("잘못된 입력입니다. 1~3 사이의 숫자를 입력하세요.");
                }
                else
                    Console.WriteLine("숫자를 입력해주세요.");
                Console.WriteLine(); // 줄 바꿈
            }
        }
    }
}
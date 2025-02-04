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
            string Name { get; }
            int Level { get; }
            string Job { get; }
            int Attack { get; }
            int Defense { get; }
            int Health { get; }
            int Gold { get; set; }
            Inventory Inventory { get; }    // 캐릭터의 인벤토리

            void ShowStatus();  // 상태 창 보기

            int GetTotalAttack();  // 총 공격력
            int GetTotalDefense(); // 총 방어력
        }
        public class Warrior : ICharacter
        {

            public string Name { get; set; }
            public int Level => 1;                  // 초기 레벨
            public string Job => "전사";            // 직업 이름
            public int Attack => 10;                // 기본 공격력
            public int Defense => 5;                // 기본 방어력
            public int Health => 100;               // 기본 체력
            public int Gold { get; set; } = 1500;   // 초기 골드
            public Inventory Inventory { get; }     // 인벤토리 추가

            public Warrior(string name)
            {
                Name = name;
                Inventory = new Inventory(this);
            }

            public int GetTotalAttack()
            {
                int totalAttack = Attack;
                foreach (var item in Inventory.GetEquippedItems())
                    totalAttack += item.AttackBonus;
                return totalAttack;
            }
            public int GetTotalDefense()
            {
                int totalDefense = Defense;
                foreach (var item in Inventory.GetEquippedItems())
                    totalDefense += item.DefenseBonus;
                return totalDefense;

            }

            public void ShowStatus()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Lv. {Level}");
                    Console.WriteLine($"{Name} ({Job})");
                    Console.WriteLine($"공격력 : {Attack} (+{GetTotalAttack() - Attack})");
                    Console.WriteLine($"방어력 : {Defense} (+{GetTotalDefense() - Defense})");
                    Console.WriteLine($"체  력 : {Health}");
                    Console.WriteLine($"Gold : {Gold} G\n");
                    Console.WriteLine("0. 나가기\n");
                    Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                    string input = Console.ReadLine();

                    if (input == "0") break; // 0 입력 시 종료
                }
            }

        }

        public class Wizard : ICharacter
        {

            public string Name { get; set; }
            public int Level => 1;                  // 초기 레벨
            public string Job => "마법사";            // 직업 이름
            public int Attack => 10;                // 기본 공격력
            public int Defense => 5;                // 기본 방어력
            public int Health => 100;               // 기본 체력
            public int Gold { get; set; } = 1500;   // 초기 골드
            public Inventory Inventory { get; }     // 인벤토리 추가

            public Wizard(string name)
            {
                Name = name;
                Inventory = new Inventory(this);
            }

            public int GetTotalAttack()
            {
                int totalAttack = Attack;
                foreach (var item in Inventory.GetEquippedItems())
                    totalAttack += item.AttackBonus;
                return totalAttack;
            }
            public int GetTotalDefense()
            {
                int totalDefense = Defense;
                foreach (var item in Inventory.GetEquippedItems())
                    totalDefense += item.DefenseBonus;
                return totalDefense;

            }

            public void ShowStatus()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Lv. {Level}");
                    Console.WriteLine($"Chad ({Job})");
                    Console.WriteLine($"공격력 : {Attack} (+{GetTotalAttack() - Attack})");
                    Console.WriteLine($"방어력 : {Defense} (+{GetTotalDefense() - Defense})");
                    Console.WriteLine($"체  력 : {Health}");
                    Console.WriteLine($"Gold : {Gold} G\n");
                    Console.WriteLine("0. 나가기\n");
                    Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                    string input = Console.ReadLine();

                    if (input == "0") break; // 0 입력 시 종료
                }
            }

        }
        public class Rogue : ICharacter
        {

            public string Name { get; set; }
            public int Level => 1;                  // 초기 레벨
            public string Job => "도적";            // 직업 이름
            public int Attack => 10;                // 기본 공격력
            public int Defense => 5;                // 기본 방어력
            public int Health => 100;               // 기본 체력
            public int Gold { get; set; } = 1500;   // 초기 골드
            public Inventory Inventory { get; }     // 인벤토리 추가

            public Rogue(string name)
            {
                Name = name;
                Inventory = new Inventory(this);
            }

            public int GetTotalAttack()
            {
                int totalAttack = Attack;
                foreach (var item in Inventory.GetEquippedItems())
                    totalAttack += item.AttackBonus;
                return totalAttack;
            }
            public int GetTotalDefense()
            {
                int totalDefense = Defense;
                foreach (var item in Inventory.GetEquippedItems())
                    totalDefense += item.DefenseBonus;
                return totalDefense;

            }

            public void ShowStatus()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Lv. {Level}");
                    Console.WriteLine($"Chad ({Job})");
                    Console.WriteLine($"공격력 : {Attack} (+{GetTotalAttack() - Attack})");
                    Console.WriteLine($"방어력 : {Defense} (+{GetTotalDefense() - Defense})");
                    Console.WriteLine($"체  력 : {Health}");
                    Console.WriteLine($"Gold : {Gold} G\n");
                    Console.WriteLine("0. 나가기\n");
                    Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                    string input = Console.ReadLine();

                    if (input == "0") break; // 0 입력 시 종료
                }
            }

        }
        public class Item
        {
            public string Name { get; }         // 아이템 이름
            public string Description { get; }  // 설명
            public Item(string name, string description)
            {
                Name = name;
                Description = description;
            }

            public virtual string GetItemInfo()
            {
                return $"{Name} | {Description}";
            }
        }
        // 장비 아이템 클래스 (공격력 or 방어력 보너스)
        public class EquipItem : Item
        {
            public int Price { get; set; }          // 아이템 가격 
            public int AttackBonus { get; }         // 공격력
            public int DefenseBonus { get; }        // 방어력
            public bool IsEquipped { get; set; }    // 장착 여부

            public EquipItem(string name, string description, int attackBonus, int defenseBonus)
                : base(name, description)
            {
                AttackBonus = attackBonus;
                DefenseBonus = defenseBonus;
                IsEquipped = false; // 기본값: 장착 안 됨
            }

            public override string GetItemInfo()
            {
                string equipMarker = IsEquipped ? "[E]" : "";
                string statBonus = AttackBonus > 0 ? $"공격력 +{AttackBonus}" : $"방어력 +{DefenseBonus}";
                return $"{equipMarker}{Name}      | {statBonus}      | {Description}";
            }
        }

        public class Inventory
        {
            private List<Item> items = new List<Item>();
            private ICharacter owner;

            public Inventory(ICharacter character)
            {
                owner = character;
            }
            public void AddItem(Item item)
            {
                items.Add(item);
            }

            public bool HasItem(Item item)
            {
                return items.Any(i => i.Name == item.Name);
            }

            public List<EquipItem> GetEquippedItems()
            {
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
                        Console.WriteLine("[아이템 목록]");
                        foreach (var item in items)
                            Console.WriteLine($"- {item.GetItemInfo()}");
                    }

                    Console.WriteLine("\n1. 장착 관리");
                    Console.WriteLine("0. 나가기\n");
                    Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                    string input = Console.ReadLine();

                    if (input == "0") break; // 0 입력 시 종료
                    else if (input == "1") ManageEquipment();
                }
            }

            public void ManageEquipment()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("인벤토리 - 장착 관리");
                    Console.WriteLine("보유 중인 장비를 장착하거나 해제할 수 있습니다.\n");

                    List<EquipItem> equipItems = items.OfType<EquipItem>().ToList();

                    if (equipItems.Count == 0)
                    {
                        Console.WriteLine("장착 가능한 아이템이 없습니다.");
                        Console.WriteLine("아무 키나 눌러 나가기...");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("[아이템 목록]");
                    for (int i = 0; i < equipItems.Count; i++)
                    {
                        string equipStatus = equipItems[i].IsEquipped ? "" : "";
                        Console.WriteLine($"{i + 1}. {equipStatus}{equipItems[i].GetItemInfo()}");
                    }

                    Console.WriteLine("\n0. 나가기");
                    Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        if (choice == 0) return;

                        if (choice > 0 && choice <= equipItems.Count)
                        {
                            EquipItem selectedItem = equipItems[choice - 1];
                            selectedItem.IsEquipped = !selectedItem.IsEquipped;
                            Console.WriteLine($"{selectedItem.Name} {(selectedItem.IsEquipped ? "장착" : "해제")} 완료!");
                        }
                        else
                        {
                            Console.WriteLine("올바른 번호를 입력하세요.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("숫자를 입력해주세요.");
                    }
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
                    else
                    {
                        Console.WriteLine("숫자를 입력해주세요.");
                    }
                }
            }
        }

        public class Store
        {
            private List<EquipItem> itemsForSale;   // 상점에서 판매하는 아이템 목록
            private ICharacter player;              // 플레이어 정보


            public Store(ICharacter player)
            {
                this.player = player;
                itemsForSale = new List<EquipItem>
                {
                    new EquipItem("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 0, 5) { Price = 1000 },
                    new EquipItem("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 9) { Price = 2000 },
                    new EquipItem("스파르타의 갑옷", "스파르타 전사들이 사용한 전설의 갑옷입니다.", 0, 15) { Price = 3500 },
                    new EquipItem("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 2, 0) { Price = 600 },
                    new EquipItem("청동 도끼", "어디선가 사용됐던 도끼입니다.", 5, 0) { Price = 1500 },
                    new EquipItem("스파르타의 창", "스파르타 전사들이 사용한 전설의 창입니다.", 7, 0) { Price = 4000 }
                };
            }

            public void ShowStore()
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다");
                Console.WriteLine();

                Console.WriteLine($"[보유 콜드]");
                Console.WriteLine($"{player.Gold} G");
                Console.WriteLine();
                Console.WriteLine($"[아이템 목록]");

                for(int i = 0; i < itemsForSale.Count; i++)
                {
                    EquipItem item = itemsForSale[i];
                    bool isPurchased = player.Inventory.HasItem(item);
                    string priceDisplay = isPurchased ? "구매완료" : $"{item.Price} G";

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
                    ShowStore();

                    Console.Write("구매할 아이템 번호를 입력하세요 (0: 나가기) >> ");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int choice))
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

                        if (player.Inventory.HasItem(selectedItem))
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else if (player.Gold < selectedItem.Price)
                        {
                            Console.WriteLine("Gold가 부족합니다.");
                        }
                        else
                        {
                            player.Gold -= selectedItem.Price;

                            // 새로운 인스턴스를 생성해서 추가
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
                            // 상태 갱신을 위해 다시 출력
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
            //Inventory inventoty = new Inventory(player);
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
                    else if (input == 1)  // 상태 보기
                    {
                        player.ShowStatus();
                    }
                    else if (input == 2) // 인벤토리
                    {
                        player.Inventory.ShowInventory();
                    }
                    else if(input == 3)
                    {
                        store.ShowStore();
                        store.BuyItem();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 1~3 사이의 숫자를 입력하세요.");
                    }
                }
                else
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                }

                Console.WriteLine(); // 줄 바꿈
            }
        }
    }
}
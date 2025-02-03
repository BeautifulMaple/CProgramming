using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPGTextGame
{
    // 캐릭터 인터페이스 (모든 캐릭터는 이 인터페이스를 구현해야 함)
    public interface ICharacter // 접근 수준을 public으로 변경
    {
        string Name { get; }
        int Health { get; set; }
        int Attack { get; }
        bool IsDead { get; }
        void TakeDamage(int damage);
    }


    /// 전사 클래스 (플레이어 캐릭터)
    public class Warrior : ICharacter
    {
        public string Name { get; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public bool IsDead => Health <= 0;
        public int Attack => new Random().Next(10, AttackPower); // 공격력 랜덤 값 반환

        public Warrior(string name)
        {
            Name = "전사";
            Health = 100;   // 초기 체력 설정
            AttackPower = 20; // 초기 공격력 설정
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else
            {
                Console.WriteLine($"{Name}이(가) {damage}의 데미지를 입었습니다.");
                Console.WriteLine($"남은 체력: {Health}");
            }
        }
    }
    // 몬스터 클래스
    public class Monster : ICharacter
    {
        public string Name { get; }
        public int Health { get; set; }
        public int Attack { get; set; }

        public bool IsDead => Health <= 0;

        public Monster(string name, int health, int attack)
        {
            Name = name;
            Health = health;
            Attack = attack;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {Health}");
        }
    }

    public class Goblin : Monster
    {
        public Goblin(string name) : base(name, 50, 10) { } // 공격력 값 추가
    }
    public class Dragon : Monster
    {
        public Dragon(string name) : base(name, 100, 20) { } // 공격력 값 추가
    }


    // Item interface
    public interface IItem
    {
        string Name { get; }
        void Use(Warrior warrior); // 전사에게 아이템을 사용하는 메서드
    }

    // 체력 포션 클래스
    public class HealthPotion : IItem
    {
        public string Name => "체력 포션";

        public void Use(Warrior warrior)
        {
            Console.WriteLine("체력 포션을 사용합니다. 체력이 50 증가합니다.");
            Console.WriteLine();
            warrior.Health += 50;
            if (warrior.Health > 100) warrior.Health = 100;
        }
    }
    // 공격력 포션 클래스
    public class StrengthPotion : IItem
    {
        public string Name => "공격력 포션";

        public void Use(Warrior warrior)
        {
            Console.WriteLine("공격력 포션을 사용합니다. 공격력이 10 증가합니다.");
            warrior.AttackPower += 10;
        }
    }

    public class Stage
    {
        private ICharacter player; // 플레이어
        private ICharacter monster; // 몬스터
        private List<IItem> rewards; // 보상 아이템들

        // 이벤트 델리게이트 정의
        public delegate void GameEvent(ICharacter character);
        public event GameEvent OnCharacterDeath; // 캐릭터가 죽었을 때 발생하는 이벤트

        public Stage(ICharacter player, ICharacter monster, List<IItem> rewards)
        {
            this.player = player;
            this.monster = monster;
            this.rewards = rewards;
            OnCharacterDeath += StageClear; // 캐릭터가 죽었을 때 StageClear 메서드 호출
        }

        // 스테이지 시작 메서드
        public void Start()
        {
            Console.WriteLine($"스테이지 시작! 플레이어 정보: 체력({player.Health}), 공격력({player.Attack})");
            Console.WriteLine($"몬스터 정보: 이름({monster.Name}), 체력({monster.Health}), 공격력({monster.Attack})");
            Console.WriteLine("----------------------------------------------------");

            while (!player.IsDead && !monster.IsDead) // 플레이어나 몬스터가 죽을 때까지 반복
            {
                // 플레이어의 턴
                Console.WriteLine($"{player.Name}의 턴!");
                monster.TakeDamage(player.Attack);
                Console.WriteLine();
                Thread.Sleep(1000);  // 턴 사이에 1초 대기

                if (monster.IsDead) break;  // 몬스터가 죽었다면 턴 종료

                // 몬스터의 턴
                Console.WriteLine($"{monster.Name}의 턴!");
                player.TakeDamage(monster.Attack);
                Console.WriteLine();
                Thread.Sleep(1000);  // 턴 사이에 1초 대기
            }

            // 플레이어나 몬스터가 죽었을 때 이벤트 호출
            if (player.IsDead)
            {
                OnCharacterDeath?.Invoke(player);
            }
            else if (monster.IsDead)
            {
                OnCharacterDeath?.Invoke(monster);
            }
        }

        // 스테이지 클리어 메서드
        private void StageClear(ICharacter character)
        {
            if (character is Monster)
            {
                Console.WriteLine($"스테이지 클리어! {character.Name}를 물리쳤습니다!");

                //  보상 목록 출력
                if (rewards != null && rewards.Count > 0)
                {
                    Console.WriteLine("아래의 보상 아이템 중 하나를 선택할 수 있습니다:");
                    for (int i = 0; i < rewards.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {rewards[i].Name}");
                    }

                    //  보상 선택
                    int choice;
                    while (true)
                    {
                        Console.Write("사용할 아이템 번호를 입력하세요: ");
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out choice) && choice >= 1 && choice <= rewards.Count)
                        {
                            break;
                        }
                        Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
                    }

                    //  선택한 아이템 사용
                    IItem selectedItem = rewards[choice - 1];
                    selectedItem.Use((Warrior)player);
                }

                // 체력 회복
                player.Health = 100;
            }
            else
            {
                Console.WriteLine("게임 오버! 패배했습니다...");
            }
        }


        static void Main(string[] args)
        {
            Warrior player = new Warrior("Player"); // 플레이어 생성
            Goblin goblin = new Goblin("Goblin"); // 고블린 생성
            Dragon dragon = new Dragon("Dragon"); // 드래곤 생성

            // 각 스테이지의 보상 아이템들
            List<IItem> stage1Rewards = new List<IItem> { new HealthPotion(), new StrengthPotion() };
            List<IItem> stage2Rewards = new List<IItem> { new StrengthPotion(), new HealthPotion() };

            // 스테이지 1
            Stage stage1 = new Stage(player, goblin, stage1Rewards);
            stage1.Start();

            // 스테이지 1이 끝난 후 플레이어가 죽었는지 확인
            if (player.IsDead) return;

            // 스테이지 2
            Stage stage2 = new Stage(player, dragon, stage2Rewards);
            stage2.Start();

            // 스테이지 2가 끝난 후 플레이어가 죽었는지 확인
            if (player.IsDead) return;

            // 게임 클리어
            Console.WriteLine("축하합니다! 모든 스테이지를 클리어했습니다!");
        }
    }
}

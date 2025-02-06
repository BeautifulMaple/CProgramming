using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class Player
    {
        public int Level { get; }    // 캐릭터 레벨
        public string Name { get; }  // 캐릭터 이름
        public string Job { get; }   // 캐릭터 직업
        public int Attack { get; }   // 기본 공격력
        public int EquiAttack { get; set; }   // 기본 공격력
        public int Defense { get; }  // 기본 방어력
        public int EquiDefense { get; set; }  // 기본 방어력
        public int Health { get; set; }   // 체력
        public int MaxHealth { get; set; }   // 체력

        public int Gold { get; set; }  // 보유 골드

        public Player(int level, string name, string job, int attack, int equiAttack, int defense, int equiDefense, int health, int maxHealth, int gold)
        {
            Level = level;
            Name = name;
            Job = job;
            Attack = attack;
            EquiAttack = equiAttack;
            Defense = defense;
            EquiDefense = equiDefense;
            Health = health;
            MaxHealth = maxHealth;
            Gold = gold;
        }
    }
}

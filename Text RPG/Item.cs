using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    public enum ItemType
    {
        Weapon,
        Amor
    }
    internal class Item
    {
        public string Name { get; }
        public ItemType Typr { get; }
        public int Value { get; } // 아이템의 수치
        public string Description { get; }
        public int Cost { get; }
        public bool ISPuerchase { get; set; }
        public bool IsEquip {  get; set; }

        public Item(string name, ItemType type, int valuem, string description, int cost)
        {
            Name = name;
            Typr = type;
            Value = valuem;
            Description = description;
            Cost = cost;
            ISPuerchase = false;
            IsEquip = false;

        }
    }
}

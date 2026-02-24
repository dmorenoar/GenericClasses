using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClasses.Core.Models.Items
{
    public class Weapon: Item
    {
        public int Damage { get; set; }
        public WeaponType Type { get;}

        public Weapon(string name, int damage, WeaponType type) : base(name)
        {
            Damage = damage;
            Type = type;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Weapon: {Name}, Damage: {Damage}, Type: {Type}";
        }

    }
}

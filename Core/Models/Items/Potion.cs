using GenericClasses.Core.Inferfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClasses.Core.Models.Items
{
    public class Potion: Item, IBuy
    {
        public PotionType Type { get; }
        public int EffectValue { get; }

        public int MinPrice => 10;

        public Potion(string name, int effectValue, PotionType type) : base(name)
        {
            EffectValue = effectValue;
            Type = type;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Potion: {Name}, Effect Value: {EffectValue}, Type: {Type}";
        }

        public int CalcPrice()
        {
            return MinPrice * 10;
        }
    }
}

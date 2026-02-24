using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClasses.Core.Models.Items
{
    public class Potion: Item
    {
        public PotionType Type { get; }
        public int EffectValue { get; }

        public Potion(string name, int effectValue, PotionType type) : base(name)
        {
            EffectValue = effectValue;
            Type = type;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Potion: {Name}, Effect Value: {EffectValue}, Type: {Type}";
        }

    }
}

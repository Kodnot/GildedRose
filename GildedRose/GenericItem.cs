using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class GenericItem
    {
        private int quality;

        public string Name { get; protected set; }
        public virtual int SellIn { get; set; }
        public virtual int Quality { get => quality; set => quality = Math.Max(0, Math.Min(value, 50)); }

        protected int DegradationRate { get; set; }

        public GenericItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            DegradationRate = 1;
        }

        public virtual void Age()
        {
            Quality -= SellIn < 0 ? DegradationRate * 2 : DegradationRate;
            SellIn -= 1;
        }
    }
}

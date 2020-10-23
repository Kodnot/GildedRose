using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    class Sulfuras : GenericItem
    {
        public Sulfuras(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override int SellIn
        {
            get => base.SellIn; 
            set
            {
                // Do nothing, the quality of Sulfuras never changes. TODO: Maybe there is a better way to do this, this approach seems a bit shady
            }
        }
    }
}

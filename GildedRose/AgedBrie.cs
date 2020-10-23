using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    class AgedBrie : GenericItem
    {
        public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            DegradationRate = -1; // Aged Brie increases in quality as it ages
        }
    }
}

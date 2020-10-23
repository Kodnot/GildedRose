namespace GildedRose.Items
{
    // NOTE: A separate class may not really be needed in this case, but I prefer it for future exensibility
    class AgedBrie : GenericItem
    {
        public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            DegradationRate = -1; // Aged Brie increases in quality as it ages
        }
    }
}

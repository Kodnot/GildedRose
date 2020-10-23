namespace GildedRose.Items
{
    // TODO: A separate class may not really be needed in this case, but I'll keep it for consistency & future exensibility
    class AgedBrie : GenericItem
    {
        public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            DegradationRate = -1; // Aged Brie increases in quality as it ages
        }
    }
}

namespace GildedRose.Items
{
    class BackstagePass : GenericItem
    {
        public BackstagePass(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            DegradationRate = -1;
        }

        public override void Age()
        {
            if (SellIn <= 0)
            {
                DegradationRate = 0;
                Quality = 0;
            }
            else if (SellIn < 6)
            {
                DegradationRate = -3;
            }
            else if (SellIn < 11)
            {
                DegradationRate = -2;
            }

            base.Age();
        }
    }
}

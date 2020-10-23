namespace GildedRose.Items
{
    class Sulfuras : GenericItem
    {
        private int initialSellIn;
        private int initialQuality;

        public Sulfuras(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            initialSellIn = sellIn;
            initialQuality = quality;
        }

        public override int SellIn
        {
            get => initialSellIn;
            protected set
            {
                // Do nothing. Sulfuras never has to be sold.
            }
        }

        public override int Quality
        {
            get => initialQuality; 
            protected set
            {
                // Do nothing, the quality of Sulfuras never changes.TODO: Maybe there is a better way to do this, this approach seems a bit shady
            }
        }
    }
}

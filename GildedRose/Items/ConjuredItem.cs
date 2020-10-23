namespace GildedRose.Items
{
    class ConjuredItem : GenericItem
    {
        public ConjuredItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            DegradationRate = 2;
            // NOTE: It wasn't quite clear to me what the requirements for this type of item were.
            // At first, I thought that any item could be conjured, and planned to use a decorator
            // But the sample just gives an independent conjured item, and i.e. a conjured backstage
            // pass wouldn't really make sense. In a real scenario, I'd ask the client to clarify,
            // but since that's not an option during this exercise, I assumed the different types of 
            // items do not overlap (no conjured aged bries, no conjured sulfuras etc)
        }
    }
}

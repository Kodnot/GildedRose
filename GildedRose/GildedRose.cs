using GildedRose.Items;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            // NOTE: If the list of items was huge, this approach may not be viable due to performance concerns, but performance testing would be needed to check whether that's a problem we need to worry about
            // The sample program does not add new items to the list, but it would make sense if that was a required option. If it is, I need to re-initialize the converted item list every time in case Items has changed.
            // Could also cache the list and only update it if it has actually changed for performance improvements
            var genericItems = Items.Select(x => ConvertItem(x)).ToList();
            foreach (var item in genericItems)
            {
                item.Age();
            }
            MapUpdatesToLegacyItems(genericItems);
        }

        private GenericItem ConvertItem(Item oldItem)
        {
            // NOTE: From the old implementation, I assumed that the sample Items contain all the possible exact names. 
            // If that is not the case, some pattern maching should be added (Does name start with / contain Backstage, maybe case insensitive / fuzzy matching etc)
            // Also, there could be some validation for whether the name passed to ctor actually fits the class type
            switch (oldItem.Name)
            {
                case "Aged Brie":
                    return new AgedBrie(oldItem.Name, oldItem.SellIn, oldItem.Quality);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePass(oldItem.Name, oldItem.SellIn, oldItem.Quality);
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras(oldItem.Name, oldItem.SellIn, oldItem.Quality);
                case "Conjured Mana Cake":
                    return new ConjuredItem(oldItem.Name, oldItem.SellIn, oldItem.Quality);
                default:
                    return new GenericItem(oldItem.Name, oldItem.SellIn, oldItem.Quality);
            }
        }

        private void MapUpdatesToLegacyItems(IList<GenericItem> genericItems)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i].Quality = genericItems[i].Quality;
                Items[i].SellIn = genericItems[i].SellIn;
            }
        }
    }
}

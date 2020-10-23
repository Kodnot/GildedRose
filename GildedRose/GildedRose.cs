using GildedRose.Items;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> Items; // NOTE: If I was allowed to, I'd rename this to ~legacyItems

        private IList<GenericItem> genericItems;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            this.genericItems = Items.Select(x => ConvertItem(x)).ToList();
        }

        public void UpdateQuality()
        {
            foreach (var item in genericItems)
            {
                item.Age();
            }
            MapUpdatesToLegacyItems();
        }

        private GenericItem ConvertItem(Item oldItem)
        {
            // NOTE: From the old implementation, I assumed that the sample Items contain all the possible exact names. 
            // If that is not the case, some pattern maching should be added (Does name start with / contain Backstage, maybe case insensitive / fuzzy matching etc)
            switch (oldItem.Name)
            {
                case "Aged Brie":
                    return new AgedBrie(oldItem.Name, oldItem.SellIn, oldItem.Quality);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePass(oldItem.Name, oldItem.SellIn, oldItem.Quality);
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras(oldItem.Name, oldItem.SellIn, oldItem.Quality);
                default:
                    return new GenericItem(oldItem.Name, oldItem.SellIn, oldItem.Quality);
            }
        }

        private void MapUpdatesToLegacyItems()
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i].Quality = genericItems[i].Quality;
                Items[i].SellIn = genericItems[i].SellIn;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> items_old;

        public readonly IList<GenericItem> Items;

        public GildedRose(IList<Item> Items)
        {
            this.items_old = Items;
            // I'm not sure if I'm allowed to do this - this isn't modifying Item class or Items property, so it should be fine.
            // If need be, I could also map the changes to the old items list after every update, making the refactoring completely transparent from the perspective of Program.cs
            this.Items = items_old.Select(x => ConvertItem(x)).ToList();
        }

        private GenericItem ConvertItem(Item oldItem)
        {
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

        public void UpdateQuality()
        {
            //foreach (var item in items_old)
            //{
            //    UpdateItem(item);
            //}
            foreach (var item in Items)
            {
                item.Age();
            }
        }

        private void UpdateDefaultItem(Item item)
        {
            item.Quality = Math.Max(item.Quality - 1, 0);
            item.SellIn -= 1;
        }

        public void UpdateItem(Item item)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }
}

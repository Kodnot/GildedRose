using Xunit;
using System.Collections.Generic;
using Shouldly;

namespace GildedRose
{
    public class GildedRoseTests
    {
        [Fact]
        public void UpdateQuality_WhenCalled_ShouldAgeAllItemsCorrectly()
        {
            // Arrange
            var items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
            };
            var expectedItems = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19},
                new Item {Name = "Aged Brie", SellIn = 1, Quality = 1},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 14,
                    Quality = 21
                },
            };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            // Assert
            for (int i = 0; i < items.Count; ++i)
            {
                items[i].Name.ShouldBe(expectedItems[i].Name);
                items[i].Quality.ShouldBe(expectedItems[i].Quality);
                items[i].SellIn.ShouldBe(expectedItems[i].SellIn);
            }
            // NOTE: This is closer to an integration test. Could be improved by passing the data through xUnit's attributes instead of inlining it in the test.
        }

        [Fact]
        public void UpdateQuality_WhenCalledAfterANewItemWasAddedToList_ShouldAgeNewItemCorrectly()
        {
            // Arrange
            var items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
            };
            var expectedItems = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 8, Quality = 18},
                new Item {Name = "Aged Brie", SellIn = 0, Quality = 2},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 13,
                    Quality = 22
                },
                new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = 4 }
            };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            items.Add(new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 });
            app.UpdateQuality();
            // Assert
            for (int i = 0; i < items.Count; ++i)
            {
                items[i].Name.ShouldBe(expectedItems[i].Name);
                items[i].Quality.ShouldBe(expectedItems[i].Quality);
                items[i].SellIn.ShouldBe(expectedItems[i].SellIn);
            }
        }

        [Fact]
        public void UpdateQuality_WhenCalledAfterAnItemWasRemoved_ShouldAgeItemsCorrectly()
        {
            // Arrange
            var items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
            };
            var expectedItems = new List<Item>{
                new Item {Name = "Aged Brie", SellIn = 0, Quality = 2},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 13,
                    Quality = 22
                },
            };
            var app = new GildedRose(items);
            // Act
            app.UpdateQuality();
            items.RemoveAt(0);
            app.UpdateQuality();
            // Assert
            for (int i = 0; i < items.Count; ++i)
            {
                items[i].Name.ShouldBe(expectedItems[i].Name);
                items[i].Quality.ShouldBe(expectedItems[i].Quality);
                items[i].SellIn.ShouldBe(expectedItems[i].SellIn);
            }
        }
    }
}
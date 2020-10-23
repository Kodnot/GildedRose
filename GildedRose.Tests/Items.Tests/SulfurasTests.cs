using GildedRose.Items;
using Shouldly;
using Xunit;

namespace GildedRose.Tests.Items.Tests
{
    public class SulfurasTests
    {
        [Theory]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 80)]
        [InlineData("Sulfuras, Hand of Ragnaros", -1, 80)]
        public void Ctor_WhenCalled_ShouldSetUpPropertiesCorrectly(string name, int sellIn, int quality)
        {
            // Arrange, Act
            var item = new Sulfuras(name, sellIn, quality);
            // Assert
            item.Name.ShouldBe(name);
            item.SellIn.ShouldBe(sellIn);
            item.Quality.ShouldBe(quality);
            // Degradation rate does not matter
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(3)]
        public void Age_WhenCalled_ShouldNotChangeQuality(int sellIn)
        {
            // Arrange
            var item = new Sulfuras("", sellIn, 80);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(80);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(3)]
        public void Age_WhenCalled_ShouldNotChangeSellIn(int sellIn)
        {
            // Arrange
            var item = new Sulfuras("", sellIn, 80);
            // Act
            item.Age();
            // Assert
            item.SellIn.ShouldBe(sellIn);
        }
    }
}

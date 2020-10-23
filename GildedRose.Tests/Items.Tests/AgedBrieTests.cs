using GildedRose.Items;
using Shouldly;
using Xunit;

namespace GildedRose.Tests.Items.Tests
{
    public class AgedBrieTests
    {
        [Theory]
        [InlineData("Aged Brie", 2, 0)]
        public void Ctor_WhenCalled_ShouldSetUpPropertiesCorrectly(string name, int sellIn, int quality)
        {
            // Arrange, Act
            var item = new AgedBrie(name, sellIn, quality);
            // Assert
            item.Name.ShouldBe(name);
            item.SellIn.ShouldBe(sellIn);
            item.Quality.ShouldBe(quality);
            item.DegradationRate.ShouldBe(-1);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void Age_WhenSellInIsPositive_ShouldIncreaseQualityByOne(int sellIn)
        {
            // Arrange
            var initialQuality = 10;
            var item = new AgedBrie("", sellIn, initialQuality);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(initialQuality + 1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void Age_WhenSellInIsNegativeOrZero_ShouldIncreaseQualityByTwo(int sellIn)
        {
            // Arrange
            var initialQuality = 10;
            var item = new AgedBrie("", sellIn, initialQuality);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(initialQuality + 2);
        }

        [Fact]
        public void Age_WhenQualityIsFifty_ShouldNotIncreaseQuality()
        {
            // Arrange
            var item = new AgedBrie("", 4, 50);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(50);
        }
    }
}

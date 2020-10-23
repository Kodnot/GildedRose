using GildedRose.Items;
using Shouldly;
using Xunit;

namespace GildedRose.Tests.Items.Tests
{
    public class ConjuredItemTests
    {
        [Theory]
        [InlineData("Conjured Mana Cake", 3, 6)]
        public void Ctor_WhenCalled_ShouldSetUpPropertiesCorrectly(string name, int sellIn, int quality)
        {
            // Arrange, Act
            var item = new ConjuredItem(name, sellIn, quality);
            // Assert
            item.Name.ShouldBe(name);
            item.SellIn.ShouldBe(sellIn);
            item.Quality.ShouldBe(quality);
            item.DegradationRate.ShouldBe(2);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void Age_WhenSellInIsPositive_ShouldDecreaseQualityByTwo(int sellIn)
        {
            // Arrange
            var initialQuality = 10;
            var item = new ConjuredItem("", sellIn, initialQuality);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(initialQuality - 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void Age_WhenSellInIsNegativeOrZero_ShouldDecreaseQualityByFour(int sellIn)
        {
            // Arrange
            var initialQuality = 10;
            var item = new ConjuredItem("", sellIn, initialQuality);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(initialQuality - 4);
        }

        [Fact]
        public void Age_WhenQualityWouldFallBelowZero_ShouldSetQualityToZero()
        {
            // Arrange
            var item = new ConjuredItem("", -2, 2);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(0);
        }
    }
}

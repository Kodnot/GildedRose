using GildedRose.Items;
using Shouldly;
using Xunit;

namespace GildedRose.Tests.Items.Tests
{
    public class GenericItemTests
    {
        [Theory]
        [InlineData("+5 Dexterity Vest", 10, 20)]
        [InlineData("Aged Brie", 2, 0)]
        public void Ctor_WhenCalled_ShouldSetUpPropertiesCorrectly(string name, int sellIn, int quality)
        {
            // Arrange, Act
            var item = new GenericItem(name, sellIn, quality);
            // Assert
            item.Name.ShouldBe(name);
            item.SellIn.ShouldBe(sellIn);
            item.Quality.ShouldBe(quality);
            item.DegradationRate.ShouldBe(1);
            // NOTE: When writing the tests, I would first write a test, then modify the code to check if the test fails, and then revert the changes to check if it passes
        }

        [Fact]
        public void Age_WhenSellInIsPositive_ShouldDecreaseQualityByOne()
        {
            // Arrange
            var initialQuality = 8;
            var item = new GenericItem("", 10, initialQuality);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(initialQuality - 1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-4)]
        public void Age_WhenSellInIsNegativeOrZero_ShouldDecreaseQualityByTwo(int sellIn)
        {
            // Arrange
            var initialQuality = 8;
            var item = new GenericItem("", sellIn, initialQuality);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(initialQuality - 2);
        }


        [Fact]
        public void Age_WhenCalled_ShouldDecreaseSellInByOne()
        {
            // Arrange
            var item = new GenericItem("", 10, 0);
            // Act
            item.Age();
            // Assert
            item.SellIn.ShouldBe(9);
        }
    }
}

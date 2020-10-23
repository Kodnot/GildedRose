using GildedRose.Items;
using Shouldly;
using Xunit;

namespace GildedRose.Tests.Items.Tests
{
    public class BackstagePassTests
    {
        [Theory]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 20)]
        public void Ctor_WhenCalled_ShouldSetUpPropertiesCorrectly(string name, int sellIn, int quality)
        {
            // Arrange, Act
            var item = new BackstagePass(name, sellIn, quality);
            // Assert
            item.Name.ShouldBe(name);
            item.SellIn.ShouldBe(sellIn);
            item.Quality.ShouldBe(quality);
            item.DegradationRate.ShouldBe(-1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        public void Age_WhenSellInIsZeroOrNegative_ShouldSetDegradationRateAndQualityToZero(int sellIn)
        {
            // Arrange
            var item = new BackstagePass("", sellIn, 10);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(0);
            item.DegradationRate.ShouldBe(0);
        }

        [Theory]
        [InlineData(13)]
        [InlineData(11)]
        public void Age_WhenSellInIsAboveTen_ShouldIncreaseQualityByOne(int sellIn)
        {
            // Arrange
            var initialQuality = 10;
            var item = new BackstagePass("", sellIn, initialQuality);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(initialQuality + 1);
            item.DegradationRate.ShouldBe(-1);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(8)]
        [InlineData(7)]
        [InlineData(6)]
        public void Age_WhenSellInIsBetweenSixAndTen_ShouldIncreaseQualityByTwo(int sellIn)
        {
            // Arrange
            var initialQuality = 10;
            var item = new BackstagePass("", sellIn, initialQuality);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(initialQuality + 2);
            item.DegradationRate.ShouldBe(-2);
        }

        // NOTE: Normally I wouldn't test with all the possible data configurations, but in this case the tests are fast
        // and the pool of possible cases is small, so it should be fine
        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void Age_WhenSellInIsBetweenOneAndFive_ShouldIncreaseQualityByThree(int sellIn)
        {
            // Arrange
            var initialQuality = 10;
            var item = new BackstagePass("", sellIn, initialQuality);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(initialQuality + 3);
            item.DegradationRate.ShouldBe(-3);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(3)]
        public void Age_WhenCalled_ShouldDecreaseSellInByOne(int sellIn)
        {
            // Arrange
            var item = new BackstagePass("", sellIn, 0);
            // Act
            item.Age();
            // Assert
            item.SellIn.ShouldBe(sellIn - 1);
        }

        [Fact]
        public void Age_WhenQualityIsFifty_ShouldNotIncreaseQuality()
        {
            // Arrange
            var item = new BackstagePass("", 4, 50);
            // Act
            item.Age();
            // Assert
            item.Quality.ShouldBe(50);
        }
    }
}
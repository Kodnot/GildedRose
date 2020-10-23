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
    }
}

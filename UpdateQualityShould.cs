using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace GildedRoseKata
{
    public class UpdateQualityShould
    {
        [Fact]
        public void DecreaseSellInBy1()
        {
            var items = new List<Item>()
            {
                new Item { Name = "TesetIten", SellIn = 5, Quality = 5 }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.True(items[0].SellIn == 4);
        }

        [Fact]
        public void ReducesQualityBy1_GivenSellinGreaterThan1()
        {
            var items = new List<Item>()
            {
                new Item { Name = "TestItem", SellIn = 1, Quality = 4 }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.True(items[0].Quality == 3);
        }

        [Fact]
        public void ReducesQualityBy2_GivenSellinOf0()
        {
            var items = new List<Item>()
            {
                new Item { Name = "TestItem", SellIn = 0, Quality = 5 }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.True(items[0].Quality == 3);
        }

        [Fact]
        public void NotReduceQualityBelow0_GivenQualityOf0()
        {
            var items = new List<Item>()
            {
                new Item { Name = "TestItem", SellIn = 0, Quality = 0 }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.True(items[0].Quality == 0);
        }

       

        


        [Fact]
        public void DoNothingGivenSulfuras()
        {
            var items = new List<Item> {
                                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},

            };
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();
            
            Assert.Equal(80, items.First().Quality);
        }
    }
}

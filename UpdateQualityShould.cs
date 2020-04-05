using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GuildedRoseKata;
using Xunit;

namespace GildedRoseKata
{
    public class UpdateQualityShould
    {
        private int _defaultSellin = 5;
        private int _defaultQuality = 5;
        private string _defaultItemName = "Test Item";
        private List<Item> _items = new List<Item>();
        
        private void RunApp()
        {
            var app = new GildedRose(_items);
            app.UpdateQuality();
        }

        private Item GetItem()
        {
            return new Item() 
            { 
                Name = _defaultItemName , 
                SellIn = _defaultSellin, 
                Quality = _defaultQuality 
            };
        }
        
        [Fact]
        public void ReduceSellInBy1()
        {
            _items.Add(GetItem());
            RunApp();
            Assert.True(_items[0].SellIn == _defaultSellin -1);
        }

        [Fact]
        public void ReduceSellInBy1_GivenSellinOf0()
        {
            _defaultSellin = 0;
            _items.Add(GetItem());
            RunApp();
            Assert.True(_items[0].SellIn == _defaultSellin -1);
        }

        [Fact]
        public void ReduceQualityBy1_GivenSellinGreaterThan1()
        {
            _items.Add(GetItem());
            RunApp();
            Assert.True(_items[0].Quality == _defaultQuality - 1);
        }

        [Fact]
        public void ReduceQualityBy2_GivenSellinOf0()
        {
           _defaultSellin = 0;
            _items.Add(GetItem());
            RunApp();
            Assert.True(_items[0].Quality == 3);
        }

        [Fact]
        public void NotReduceQualityBelow0_GivenQualityOf0()
        {
           _defaultQuality = 0;
            _items.Add(GetItem());
            RunApp();
            Assert.True(_items[0].Quality == 0);
        }

        [Fact]
        public void IncreaseQuality_GivenAgedBrie()
        {
           _defaultItemName = Constants.AGED_BRIE;
            _items.Add(GetItem());
            RunApp();
            Assert.True(_items[0].Quality == _defaultQuality + 1);
        }
       
       [Fact]
        public void NotIncreaseQuality_GivenQualityOf50()
        {
            _defaultQuality = 50;
             _defaultItemName = Constants.AGED_BRIE;
            _items.Add(GetItem());
            RunApp();
            Assert.True(_items[0].Quality == _defaultQuality);
        }

        [Fact]
        public void DoNothingGivenSulfuras()
        {
            _defaultQuality = 80;
            _defaultItemName = Constants.SULFURAS;
            _items.Add(GetItem());
            RunApp();
            Assert.True(_items[0].SellIn == _defaultSellin);
            Assert.True(_items[0].Quality == _defaultQuality);
        }

        [Fact]
        public void IncreaseQualityBy2_GivenBackStagesPassesAndSellinBetween5And10()
        {
            _defaultItemName = Constants.BACKSTAGE_PASSES;
            _defaultSellin = 9;
            _items.Add(GetItem());
            RunApp();
            Assert.True(_items[0].Quality == _defaultQuality + 2);
        }

        [Fact]
        public void IncreaseQualityBy2_GivenBackStagesPassesAndSellinLessThan5()
        {
            _defaultItemName = Constants.BACKSTAGE_PASSES;
            _defaultSellin = 4;
            _items.Add(GetItem());
            RunApp();
            Assert.True(_items[0].Quality == _defaultQuality + 3);
        }

          [Fact]
        public void IncreaseQualityBy1_GivenBackStagesPassesAndSellinMoreThan10()
        {
            _defaultItemName = Constants.BACKSTAGE_PASSES;
            _defaultSellin = 11;
            _items.Add(GetItem());
            RunApp();
            Assert.True(_items[0].Quality == _defaultQuality + 1);
        }

         [Fact]
        public void SetQualityTo0_GivenBackStagesPassesAndSellin0()
        {
            _defaultItemName = Constants.BACKSTAGE_PASSES;
            _defaultSellin = 0;
            _items.Add(GetItem());
            RunApp();
            Assert.True(_items[0].Quality == 0);
        }

        //  [Fact]
        // public void DecreaseQualityBy2_GivenConjuredItem()
        // {
        //     _defaultItemName = "Conjured Mana Biscuits";
        //     _items.Add(GetItem());
        //     RunApp();
        //     Assert.True(_items[0].Quality == _defaultQuality - 2);
        // }


    }
}

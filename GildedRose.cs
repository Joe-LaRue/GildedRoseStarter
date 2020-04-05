using System.Collections.Generic;
using GildedRoseKata.ItemUpdaters;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == Constants.SULFURAS)
                {
                    var itemUpdater = ItemUpdaterFactory.GetItemUpdater(Items[i]);
                    itemUpdater.UpdateItem();
                    continue;
                }

                if (Items[i].Name == Constants.AGED_BRIE)
                {
                    var itemUpdater = ItemUpdaterFactory.GetItemUpdater(Items[i]);
                    itemUpdater.UpdateItem();
                    continue;
                }

                 if (Items[i].Name == Constants.BACKSTAGE_PASSES)
                {
                    var itemUpdater = ItemUpdaterFactory.GetItemUpdater(Items[i]);
                    itemUpdater.UpdateItem();
                    continue;
                }
                UpdateItem(Items[i]);
            }
        }

        private void UpdateItem(Item item)
        {
            if (item.Name == Constants.BACKSTAGE_PASSES)
            {
                IncrementQuality(item);
                if (item.SellIn < 11)
                {
                    IncrementQuality(item);
                }

                if (item.SellIn < 6)
                {
                    IncrementQuality(item);
                }

            }
            else
            {
                DecrementQuality(item);
            }

            DecrementSellIn(item);

            if (item.SellIn < 0)
            {
                switch (item.Name)
                {
                    case Constants.BACKSTAGE_PASSES:
                        ZeroOutQuality(item);
                        return;
                    default:
                        DecrementQuality(item);
                        return;
                }
            }
        }

        private void DecrementSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private void ZeroOutQuality(Item item)
        {
            item.Quality = 0;
        }

        private void IncrementQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        private void DecrementQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }
    }





}




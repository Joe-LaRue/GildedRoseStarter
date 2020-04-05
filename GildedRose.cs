using System.Collections.Generic;
using GuildedRoseKata;

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
                UpdateItem(Items[i]);
            }
        }

        private void UpdateQualityForBackstagePass(Item item)
        {
            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }

            if (item.SellIn < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }

        public bool ItemAppreciatesInQuality(Item item)
        {
            switch (item.Name)
            {
                case Constants.AGED_BRIE:
                case Constants.BACKSTAGE_PASSES:
                    return true;

                default:
                    return false;
            }
        }

        public void AppreciateQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;

                if (item.Name == Constants.BACKSTAGE_PASSES)
                {
                    UpdateQualityForBackstagePass(item);
                }
            }
        }

        private void DepreciateQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        private void UpdateOutOfDateItem(Item item)
        {
            switch (item.Name)
            {
                case Constants.AGED_BRIE:
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                    return;
                case Constants.BACKSTAGE_PASSES:
                    item.Quality = item.Quality - item.Quality;
                    return;
                default:
                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }
                    return;
            }

        }

        private void UpdateItem(Item item)
        {
            if (item.Name == Constants.SULFURAS)
            {
                return;
            }

            if (ItemAppreciatesInQuality(item))
            {
                AppreciateQuality(item);
            }
            else
            {
                DepreciateQuality(item);
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                UpdateOutOfDateItem(item);
            }
        }
    }


}

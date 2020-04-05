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

        private void UpdateItem(Item item)
        {            
            if (item.Name == Constants.SULFURAS)
            {
                return;
            }

            if (ItemAppreciatesInQuality(item))
            {
                IncrementQuality(item);
                if (item.Name == Constants.BACKSTAGE_PASSES)
                {
                    UpdateQualityForBackstagePass(item);
                }
            }
            else
            {
                DecrementQuality(item);
            }

           DecrementSellIn(item);

            if (item.SellIn < 0)
            {
                UpdateOutOfDateItem(item);
            }
        }      

        private void UpdateQualityForBackstagePass(Item item)
        {
            if (item.SellIn < 11)
            {
                IncrementQuality(item);
            }

            if (item.SellIn < 6)
            {
                IncrementQuality(item);
            }
        }

        private bool ItemAppreciatesInQuality(Item item)
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

        private void UpdateOutOfDateItem(Item item)
        {
            switch (item.Name)
            {
                case Constants.AGED_BRIE:
                    IncrementQuality(item);
                    return;
                case Constants.BACKSTAGE_PASSES:
                    ZeroOutQuality(item);
                    return;
                default:
                    DecrementQuality(item);
                    return;
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




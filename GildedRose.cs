﻿using System.Collections.Generic;
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
                UpdateItem(Items[i]);
            }
        }
        
        private void UpdateItem(Item item)
        {
            var itemUpdater = ItemUpdaterFactory.GetItemUpdater(item);
            itemUpdater.UpdateItem();
        }

       
    }





}




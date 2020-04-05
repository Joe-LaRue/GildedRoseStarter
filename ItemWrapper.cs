namespace GildedRoseKata
{
    public class ItemWrapper
    {
        public Item Item { get; set; }
        public ItemWrapper(Item item)
        {
            Item = item;
        }

        private void ZeroOutQuality()
        {
            Item.Quality = 0;
        }

        private void IncrementQuality()
        {
            if (Item.Quality < 50)
            {
                Item.Quality = Item.Quality + 1;
            }
        }

        private void DecrementQuality()
        {
            if (Item.Quality > 0)
            {
                Item.Quality = Item.Quality - 1;
            }
        }

        private void DecrementSellIn()
        {
             Item.SellIn = Item.SellIn - 1;
        }


    }
}
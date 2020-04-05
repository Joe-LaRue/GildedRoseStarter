using GildedRoseKata;

namespace GildedRoseKata.ItemUpdaters
{
    public abstract class ItemUpdater
    {
        public Item _item { get; set; }

        public ItemUpdater(Item item)
        {
            _item = item;
        }
        protected void ZeroOutQuality()
        {
            _item.Quality = 0;
        }

        protected void IncrementQuality()
        {
            if (_item.Quality < 50)
            {
                _item.Quality = _item.Quality + 1;
            }
        }

        protected void DecrementQuality()
        {
            if (_item.Quality > 0)
            {
                _item.Quality = _item.Quality - 1;
            }
        }

        protected void DecrementSellIn()
        {
            _item.SellIn = _item.SellIn - 1;
        }

        public abstract void UpdateItem();
    }
}
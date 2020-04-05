namespace GildedRoseKata.ItemUpdaters
{
    public class BackstagePassItemUpdater : ItemUpdater
    {
        public BackstagePassItemUpdater(Item item) : base(item)
        {

        }

        public override void UpdateItem()
        {
            IncrementQuality();
            if (_item.SellIn < 11)
            {
                IncrementQuality();
            }

            if (_item.SellIn < 6)
            {
                IncrementQuality();
            }
            DecrementSellIn();

            if (ItemIsExpired())
            {
                ZeroOutQuality();
            }
        }
    }
}
namespace GildedRoseKata.ItemUpdaters
{
    public class DefaultItemUpdater : ItemUpdater
    {
        public DefaultItemUpdater(Item item) : base(item)
        {
            
        }


        public override void UpdateItem()
        {
            DecrementQuality();
            DecrementSellIn();
            if (ItemIsExpired())
            {
                DecrementQuality();
            }
        }
    }
}

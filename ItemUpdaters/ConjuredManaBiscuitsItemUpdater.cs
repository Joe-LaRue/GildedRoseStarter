namespace GildedRoseKata.ItemUpdaters
{
    public class ConjuredManaBiscuitsItemUpdater : ItemUpdater
    {
        public ConjuredManaBiscuitsItemUpdater(Item item) : base(item)
        {
            
        }

        public override void UpdateItem()
        {
            DecrementQuality();
            DecrementQuality();

            DecrementSellIn();

            if (ItemIsExpired())
            {
                DecrementQuality();
                DecrementQuality();
            }
        }
    }
}

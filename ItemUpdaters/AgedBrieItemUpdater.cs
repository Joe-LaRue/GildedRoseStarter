namespace GildedRoseKata.ItemUpdaters
{
    public class AgedBrieItemUpdater : ItemUpdater
    {
        public AgedBrieItemUpdater(Item item) : base(item)
        {

        }

        public override void UpdateItem()
        {
            IncrementQuality();
            DecrementSellIn();
            if (ItemIsExpired())
            {
                IncrementQuality();
            }
        }
    }
}

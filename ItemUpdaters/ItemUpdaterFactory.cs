namespace GildedRoseKata.ItemUpdaters
{
    public class ItemUpdaterFactory
    {
        public static ItemUpdater GetItemUpdater(Item item)
        {
            return new DefaultItemUpdater(item);
        }
    }
}
using GildedRoseKata;

namespace GildedRoseKata.ItemUpdaters
{
    public class ItemUpdaterFactory
    {
        public static ItemUpdater GetItemUpdater(Item item)
        {
            switch (item.Name)
            {
                case Constants.SULFURAS:
                    return new SulfurasItemUpdater(item);
                case Constants.AGED_BRIE:
                    return new AgedBrieItemUpdater(item);
                case Constants.BACKSTAGE_PASSES:
                    return new BackstagePassItemUpdater(item);
                default:
                    return new DefaultItemUpdater(item);
            }

        }
    }
}
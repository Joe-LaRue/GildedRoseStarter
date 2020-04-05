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

                default:
                    return new DefaultItemUpdater(item);
            }

        }
    }
}
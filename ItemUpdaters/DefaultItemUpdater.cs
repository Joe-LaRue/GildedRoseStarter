namespace GildedRoseKata.ItemUpdaters
{
    public class DefaultItemUpdater : IItemUpdater
    {
        public ItemWrapper _itemWrapper;
        public void UpdateItem(Item item)
        {
            _itemWrapper = new ItemWrapper(item);

        }
    }
}

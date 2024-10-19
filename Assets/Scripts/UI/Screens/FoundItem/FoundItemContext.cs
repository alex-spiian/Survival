using Survival.Item;

namespace Survival.UI
{
    public class FoundItemContext
    {
        public ItemConfig ItemConfig { get; }
        public Item.Item Item { get; }

        public FoundItemContext(ItemConfig itemConfig, Item.Item item)
        {
            ItemConfig = itemConfig;
            Item = item;
        }
    }
}
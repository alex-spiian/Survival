using Survival.Item;

namespace Survival.Events
{
    public struct ItemPickedUpEvent
    {
        public ItemConfig ItemConfig { get; }
        public Item.Item Item { get; }

        public ItemPickedUpEvent(ItemConfig config, Item.Item item)
        {
            ItemConfig = config;
            Item = item;
        }
    }
}
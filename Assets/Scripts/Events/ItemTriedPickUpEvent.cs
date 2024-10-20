using Survival.Item;

namespace Survival.Events
{
    public struct ItemTriedPickUpEvent
    {
        public ItemConfig ItemConfig { get; }
        public Item.Item Item { get; }

        public ItemTriedPickUpEvent(ItemConfig config, Item.Item item)
        {
            ItemConfig = config;
            Item = item;
        }
    }
}
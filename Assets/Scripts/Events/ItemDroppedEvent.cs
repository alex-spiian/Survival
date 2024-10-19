using Survival.Item;

namespace Survival.Events
{
    public struct ItemDroppedEvent
    {
        public ItemConfig ItemConfig { get; }

        public ItemDroppedEvent(ItemConfig itemConfig)
        {
            ItemConfig = itemConfig;
        }
    }
}
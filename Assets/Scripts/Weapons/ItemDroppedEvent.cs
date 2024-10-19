using Survival.Item;

namespace Survival.Weapons
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
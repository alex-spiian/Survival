using Survival.Item;

namespace Survival.UI
{
    public struct ItemPickedUpEvent
    {
        public ItemConfig ItemConfig { get; }
        public Weapons.Item Item { get; }

        public ItemPickedUpEvent(ItemConfig config, Weapons.Item item)
        {
            ItemConfig = config;
            Item = item;
        }
    }
}
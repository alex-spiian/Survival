using Survival.Item;
using Survival.Weapons;

namespace Survival.UI
{
    public class FoundItemContext
    {
        public ItemConfig ItemConfig { get; }
        public Weapon Weapon { get; }

        public FoundItemContext(ItemConfig itemConfig, Weapon weapon)
        {
            ItemConfig = itemConfig;
            Weapon = weapon;
        }
    }
}
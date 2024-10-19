using Survival.Item;

namespace Survival.UI
{
    public struct WeaponPickedUpEvent
    {
        public WeaponConfig WeaponConfig { get; }

        public WeaponPickedUpEvent(WeaponConfig config)
        {
            WeaponConfig = config;
        }
    }
}
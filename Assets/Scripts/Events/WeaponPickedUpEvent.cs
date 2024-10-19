using Survival.Weapons;

namespace Survival.Events
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
using Survival.Weapons;

namespace Survival.Events
{
    public struct WeaponDroppedEvent
    {
        public WeaponConfig WeaponConfig { get; }

        public WeaponDroppedEvent(WeaponConfig weaponConfig)
        {
            WeaponConfig = weaponConfig;
        }
    }
}
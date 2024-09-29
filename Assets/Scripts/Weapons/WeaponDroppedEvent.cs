using Survival;

namespace Survival.Weapons
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
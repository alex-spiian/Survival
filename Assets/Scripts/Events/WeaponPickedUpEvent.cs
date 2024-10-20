using Survival.Weapons;

namespace Survival.Events
{
    public struct WeaponPickedUpEvent
    {
        public WeaponConfig WeaponConfig { get; }
        public Weapon Weapon { get; }

        public WeaponPickedUpEvent(WeaponConfig config, Weapon weapon)
        {
            WeaponConfig = config;
            Weapon = weapon;
        }
    }
}
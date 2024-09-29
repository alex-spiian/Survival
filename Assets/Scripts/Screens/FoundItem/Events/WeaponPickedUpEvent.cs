using Survival.Weapons;

namespace Survival.UI
{
    public struct WeaponPickedUpEvent
    {
        public Weapon Weapon { get; }

        public WeaponPickedUpEvent(Weapon weapon)
        {
            Weapon = weapon;
        }
    }
}
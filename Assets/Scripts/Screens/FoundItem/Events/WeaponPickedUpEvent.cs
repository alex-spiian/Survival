using Weapons;

namespace FoundItem
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
using Weapons;

namespace FoundItemScreen
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
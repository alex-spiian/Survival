using System.Linq;
using UnityEngine;

namespace Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        [SerializeField]
        private WeaponSlot[] _weaponSlots;

        public bool TrySetWeapon(Weapon weapon)
        {
            if (CanPickUp())
            {
                var slot = GetFreeSlot();
                slot.SetWeapon(weapon);
                return true;
            }
            return false;
        }

        private bool CanPickUp()
        {
            return _weaponSlots.Any(slot => !slot.IsBusy);
        }

        private WeaponSlot GetFreeSlot()
        {
            return _weaponSlots.FirstOrDefault(slot => !slot.IsBusy);
        }
    }
}
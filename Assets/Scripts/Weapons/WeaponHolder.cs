using System.Linq;
using Item;
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

        public void RemoveWeapon(WeaponConfig weaponConfig)
        {
            var neededSlot = _weaponSlots.FirstOrDefault(weapon => weapon.CurrentWeapon.WeaponConfig.Name == weaponConfig.Name);
            neededSlot.RemoveWeapon();
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
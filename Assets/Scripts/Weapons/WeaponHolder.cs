using System.Linq;
using UnityEngine;

namespace Survival.Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        [SerializeField]
        private WeaponSlot[] _weaponSlots;

        public bool TrySetWeapon(WeaponConfig weaponConfig)
        {
            if (CanPickUp())
            {
                var slot = GetFreeSlot();
                slot.SetWeapon(weaponConfig);
                return true;
            }
            return false;
        }

        public void TryRemoveWeapon(WeaponConfig weaponConfig)
        {
            var neededSlot = _weaponSlots.FirstOrDefault(weapon => weapon.CurrentWeapon.ItemConfig.Name == weaponConfig.Name);
            if (neededSlot != null)
            {
                neededSlot.RemoveWeapon();
                return;
            }
            
            Debug.Log("Dropped weapon is not in hands");
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
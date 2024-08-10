using System.Linq;
using UnityEngine;

namespace Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        [SerializeField]
        private WeaponSlot[] _weaponSlots;

        public void SetWeapon(Weapon weapon)
        {
            if (CanPickUp())
            {
                var slot = GetFreeSlot();
                slot.SetWeapon(weapon);
                return;
            }

            // event there are no free slots
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
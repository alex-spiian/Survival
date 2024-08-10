using UnityEngine;

namespace Weapons
{
    public class WeaponSlot : MonoBehaviour
    {
        public bool IsBusy { get; private set; }
        public Weapon CurrentWeapon { get; private set; }

        public void SetWeapon(Weapon weapon)
        {
            weapon.transform.SetParent(transform);
            weapon.transform.rotation = Quaternion.identity;
            weapon.OnWeaponPickedUp();
            CurrentWeapon = weapon;
            IsBusy = true;
        }

        public void RemoveWeapon()
        {
            CurrentWeapon.transform.SetParent(null);
            CurrentWeapon.OnWeaponDropped();
            IsBusy = false;
        }
    }
}
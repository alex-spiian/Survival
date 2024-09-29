using UnityEngine;

namespace Survival.Weapons
{
    public class WeaponSlot : MonoBehaviour
    {
        public bool IsBusy { get; private set; }
        public Weapon CurrentWeapon { get; private set; }

        public void SetWeapon(Weapon weapon)
        {
            weapon.transform.SetParent(transform);
            weapon.transform.localPosition = Vector3.zero;
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
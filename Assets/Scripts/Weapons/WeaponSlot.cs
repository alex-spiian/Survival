using UnityEngine;

namespace Survival.Weapons
{
    public class WeaponSlot : MonoBehaviour
    {
        public bool IsBusy { get; private set; }
        public Weapon CurrentWeapon { get; private set; }

        public void SetWeapon(WeaponConfig config)
        {
            var weapon = Instantiate(config.Prefab, transform);
            CurrentWeapon = weapon;

            CurrentWeapon.transform.localPosition = Vector3.zero;
            CurrentWeapon.transform.rotation = Quaternion.identity;
            CurrentWeapon.OnWeaponPickedUp();
            CurrentWeapon.MarkAsInHands();
            IsBusy = true;
            
            Debug.Log("SetWeapon");
        }

        public void RemoveWeapon()
        {
            Destroy(CurrentWeapon.gameObject);
            IsBusy = false;
        }
    }
}
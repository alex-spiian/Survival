using FoundItem;
using UnityEngine;
using Weapons;

namespace Player
{
    public class WeaponDetector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("OnTriggerEnter2D");
            if (collider.TryGetComponent<Weapon>(out var weapon))
            {
                ScreensManager.OpenScreen<FoundItemScreen, FoundItemContext>(new FoundItemContext(weapon.WeaponConfig, weapon));
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            Debug.Log("OnTriggerExit2D");
            if (collider.TryGetComponent<Weapon>(out var weapon))
            {
                ScreensManager.CloseScreen<FoundItemScreen>();
            }
        }
    }
}
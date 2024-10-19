using Survival.Item;
using UnityEngine;

namespace Survival.Weapons
{
    [RequireComponent(typeof(Collider2D))]
    public class Item : MonoBehaviour
    {
        [field:SerializeField]
        public ItemConfig ItemConfig { get; private set; }
        
        private Collider2D _collider;
        
        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        public void OnWeaponPickedUp()
        {
            _collider.enabled = false;
        }
        
        public void OnWeaponDropped()
        {
            _collider.enabled = true;
        }
    }
}
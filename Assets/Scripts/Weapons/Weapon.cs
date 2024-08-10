using System;
using Item;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Collider2D))]
    public class Weapon : MonoBehaviour
    {
        [field:SerializeField]
        public WeaponConfig WeaponConfig { get; private set; }

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
using Item;
using UnityEngine;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        [field:SerializeField]
        public WeaponConfig WeaponConfig { get; private set; }
    }
}
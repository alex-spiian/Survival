using Survival.Item;
using UnityEngine;

namespace Survival.Weapons
{
    [CreateAssetMenu(menuName = "ScriptableObject/WeaponConfig", fileName = "WeaponConfig")]
    public class WeaponConfig : ItemConfig
    {
        [field:SerializeField] public float Damage { get; private set; }
        [field:SerializeField] public Weapon Prefab { get; private set; }
    }
}
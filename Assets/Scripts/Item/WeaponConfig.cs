using UnityEngine;

namespace Survival.Item
{
    [CreateAssetMenu(menuName = "ScriptableObject/WeaponConfig", fileName = "WeaponConfig")]
    public class WeaponConfig : ItemConfig
    {
        [field:SerializeField] public float Damage { get; private set; }
    }
}
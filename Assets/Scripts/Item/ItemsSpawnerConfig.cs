using UnityEngine;

namespace Survival.Item
{
    [CreateAssetMenu(menuName = "ScriptableObject/ItemsSpawnerConfig", fileName = "ItemsSpawnerConfig")]
    public class ItemsSpawnerConfig : ScriptableObject
    {
        [field:SerializeField] public Item[] ItemPrefabs { get; private set; }
        [field:SerializeField] public float SpawnRadius { get; private set; }
        [field:SerializeField] public int WeaponCount { get; private set; }
    }
}
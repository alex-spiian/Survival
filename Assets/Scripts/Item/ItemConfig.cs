using UnityEngine;

namespace Survival
{
    [CreateAssetMenu(menuName = "ScriptableObject/ItemConfig", fileName = "ItemConfig")]
    public class ItemConfig : ScriptableObject
    {
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public Sprite Icon { get; private set; }
    }
}
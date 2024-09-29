using Survival;
using Survival.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Survival.UI
{
    public class InventoryItem : MonoBehaviour, IItem
    {
        public ItemConfig ItemConfig { get; private set; }
        public Transform Transform => transform;
        
        [SerializeField]
        private Image _itemIcon;

        public void Initialize(ItemConfig itemConfig)
        {
            ItemConfig = itemConfig;
            _itemIcon.sprite = ItemConfig.Icon;
        }
    }
}
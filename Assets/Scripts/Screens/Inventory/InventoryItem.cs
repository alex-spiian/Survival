using UnityEngine;
using UnityEngine.UI;

namespace Screens.Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField]
        private Image _itemIcon;

        public void Initialize(Sprite itemSprite)
        {
            _itemIcon.sprite = itemSprite;
        }
    }
}
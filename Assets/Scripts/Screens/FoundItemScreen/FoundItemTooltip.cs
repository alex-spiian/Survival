using Item;
using Screens.Tooltip;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FoundItemScreen
{
    public class FoundItemTooltip : MonoBehaviour, ITooltip
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _name;
        
        public void Initialize(ItemConfig itemConfig)
        {
            _icon.sprite = itemConfig.Icon;
            _name.text = itemConfig.Name;
        }
    }
}
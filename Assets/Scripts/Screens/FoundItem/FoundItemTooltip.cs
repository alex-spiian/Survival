using Item;
using Screens.Tooltip;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FoundItem
{
    public class FoundItemTooltip : MonoBehaviour, ITooltip
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _damage;
        
        public void Initialize(ItemConfig itemConfig)
        {
            var weaponConfig = (WeaponConfig)itemConfig;
            _icon.sprite = itemConfig.Icon;
            _name.text = itemConfig.Name;
            _damage.text = $"Damage: {weaponConfig.Damage}";
        }
    }
}
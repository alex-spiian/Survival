using Survival.Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Survival.UI
{
    public class ItemInfo : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _nameLabel;
        [SerializeField] private TextMeshProUGUI _damageLabel;

        [SerializeField] private TextMeshProUGUI[] _characteristics;

        public void SetInfo(ItemConfig itemConfig)
        {
            var weaponConfig = (WeaponConfig)itemConfig;
            _icon.sprite = itemConfig.Icon;
            _nameLabel.text = itemConfig.Name;
            _damageLabel.text = $"Damage: {weaponConfig.Damage}";
        }
    }
}
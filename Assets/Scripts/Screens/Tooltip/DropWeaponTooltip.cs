using Item;
using JetBrains.Annotations;
using Screens.Inventory;
using TMPro;
using UniTaskPubSub;
using UnityEngine;
using VContainer;
using Weapons;

namespace Screens.Tooltip
{
    public class DropWeaponTooltip : ItemTooltip
    {
        [SerializeField] private TextMeshProUGUI _damage;
        private IAsyncPublisher _publisher;
        private ItemConfig _itemConfig;

        [Inject]
        public void Construct(IAsyncPublisher publisher)
        {
            _publisher = publisher;
        }
        
        public override void Initialize(ItemConfig itemConfig, RectTransform rectTransform)
        {
            _itemConfig = itemConfig;
            SetValue(itemConfig);
            var offset = new Vector2(0, rectTransform.sizeDelta.y / 2);
            SetPosition(rectTransform, offset);
        }
        
        [UsedImplicitly]
        public void OnWeaponDropped()
        {
            _publisher.Publish(new WeaponDroppedEvent((WeaponConfig)_itemConfig));
            ScreensManager.CloseScreen<InventoryScreen>();
        }
        
        protected override void SetValue(ItemConfig itemConfig)
        {
            base.SetValue(itemConfig);
            var weaponConfig = (WeaponConfig)itemConfig;
            _damage.text = $"Damage: {weaponConfig.Damage}";
        }
    }
}
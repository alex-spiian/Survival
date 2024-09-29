using Survival;
using ScreenManager.Core;
using UnityEngine;

namespace Survival.UI
{
    public class InventoryScreen : UIScreen<InventoryContext>
    {
        [SerializeField]
        private Transform _itemsContainer;
        
        [SerializeField]
        private InventoryItem _inventoryItemPrefab;

        public override void Initialize(InventoryContext context)
        {
            GenerateInventory(context.InventoryModel);
        }

        private void GenerateInventory(InventoryModel inventory)
        {
            var weapons = inventory.Weapons;

            foreach (var weapon in weapons)
            {
                var inventoryItem = Instantiate(_inventoryItemPrefab, _itemsContainer);
                inventoryItem.Initialize(weapon.WeaponConfig);
            }
        }
    }
}
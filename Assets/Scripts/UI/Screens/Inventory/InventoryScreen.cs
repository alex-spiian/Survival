using System.Collections.Generic;
using System.Linq;
using ScreenManager.Core;
using Survival.Events;
using Survival.Inventory;
using Survival.Item;
using UniTaskPubSub;
using UnityEngine;
using VContainer;

namespace Survival.UI
{
    public class InventoryScreen : UIScreen<InventoryContext>
    {
        [SerializeField]
        private Transform _itemsContainer;
        
        [SerializeField]
        private InventoryItem _inventoryItemPrefab;

        [SerializeField]
        private ItemInfo _itemInfo;

        private readonly List<InventoryItem> _items = new();
        private IAsyncPublisher _publisher;
        private ItemConfig _selectedItemConfig;

        [Inject]
        public void Construct(IAsyncPublisher publisher)
        {
            _publisher = publisher;
        }
        public override void Initialize(InventoryContext context)
        {
            GenerateInventory(context.InventoryModel);
        }

        private void GenerateInventory(InventoryModel inventory)
        {
            var items = inventory.Items;

            foreach (var itemConfig in items)
            {
                var inventoryItem = Instantiate(_inventoryItemPrefab, _itemsContainer);
                inventoryItem.Initialize(itemConfig);
                inventoryItem.Selected += OnItemSelected;
                _items.Add(inventoryItem);
            }
        }

        private void OnItemSelected(InventoryItem selectedItem)
        {
            _selectedItemConfig = selectedItem.ItemConfig;
            _itemInfo.SetInfo(_selectedItemConfig);
            
            foreach (var item in _items)
            {
                if (item == selectedItem)
                {
                    item.OnSelected();
                    continue;
                }
                
                item.OnDeSelected();
            }
        }

        public void OnWeaponDropped()
        {
            _publisher.Publish(new ItemDroppedEvent(_selectedItemConfig));
            var droppedItem = _items.FirstOrDefault(item => item.ItemConfig.Name == _selectedItemConfig.Name);
            _items.Remove(droppedItem);
            Destroy(droppedItem.gameObject);
        }
        
        private void OnDisable()
        {
            foreach (var item in _items)
            {
                item.Selected -= OnItemSelected;
            }
        }
    }
}
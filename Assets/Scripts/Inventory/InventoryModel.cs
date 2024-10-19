using System;
using System.Collections.Generic;
using System.Linq;
using SimpleEventBus.Disposables;
using Survival.Events;
using Survival.Item;
using Survival.Weapons;
using UniTaskPubSub;
using UnityEngine;
using VContainer;

namespace Survival.Inventory
{
    public class InventoryModel : IDisposable
    {
        public List<ItemConfig> Items { get; } = new();

        private AsyncMessageBus _messageBus;
        private readonly CompositeDisposable _subscriptions = new();

        [Inject]
        public void Construct(AsyncMessageBus messageBus)
        {
            _messageBus = messageBus;
            _subscriptions.Add(_messageBus.Subscribe<ItemDroppedEvent>(OnItemDropped));
            _subscriptions.Add(_messageBus.Subscribe<ItemPickedUpEvent>(OnItemPickedUp));
        }
        
        private void OnItemPickedUp(ItemPickedUpEvent eventData)
        {
            var pickedUpItem = eventData.ItemConfig;
            if (Items.Contains(pickedUpItem))
            {
                Debug.Log("Item is already added");
                return;
            }
            
            eventData.Item.gameObject.SetActive(false); // temp
            
            Items.Add(pickedUpItem);
            if (pickedUpItem.GetType() == typeof(WeaponConfig))
            {
                _messageBus.Publish(new WeaponPickedUpEvent((WeaponConfig)pickedUpItem));
            }
        }

        private void OnItemDropped(ItemDroppedEvent eventData)
        {
            var droppedUpItem = eventData.ItemConfig;
            var item = Items.FirstOrDefault(config => config.Name == droppedUpItem.Name);
            Items.Remove(item);
            
            if (droppedUpItem.GetType() == typeof(WeaponConfig))
            {
                _messageBus.Publish(new WeaponDroppedEvent((WeaponConfig)droppedUpItem));
            }
        }

        public void Dispose()
        {
            _subscriptions?.Dispose();
        }
    }
}
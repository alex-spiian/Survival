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
        public List<ItemConfig> AllItems { get; } = new();
        public List<ItemConfig> ItemsOnPlayer { get; } = new();

        private AsyncMessageBus _messageBus;
        private readonly CompositeDisposable _subscriptions = new();

        [Inject]
        public void Construct(AsyncMessageBus messageBus)
        {
            _messageBus = messageBus;
            _subscriptions.Add(_messageBus.Subscribe<ItemDroppedEvent>(OnItemDropped));
            _subscriptions.Add(_messageBus.Subscribe<ItemTriedPickUpEvent>(OnItemPickedUp));
        }
        
        private void OnItemPickedUp(ItemTriedPickUpEvent eventData)
        {
            var pickedUpItem = eventData.ItemConfig;
            if (AllItems.Contains(pickedUpItem))
            {
                Debug.Log("Item is already added");
                return;
            }

            AllItems.Add(pickedUpItem);
            var isWeapon = pickedUpItem.GetType() == typeof(WeaponConfig);
            if (isWeapon)
            {
                var weaponConfig = (WeaponConfig)pickedUpItem;
                var weapon = (Weapon)eventData.Item;
                
                _messageBus.Publish(new WeaponPickedUpEvent(weaponConfig, weapon));
            }
            
            _messageBus.Publish(new ItemPickedUpEvent(pickedUpItem, eventData.Item));
        }

        private void OnItemDropped(ItemDroppedEvent eventData)
        {
            var droppedUpItem = eventData.ItemConfig;
            var item = AllItems.FirstOrDefault(config => config.Name == droppedUpItem.Name);
            AllItems.Remove(item);
            
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
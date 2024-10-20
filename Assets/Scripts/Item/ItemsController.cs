using System.Collections.Generic;
using SimpleEventBus.Disposables;
using Survival.Events;
using Survival.GameField;
using Survival.Player;
using UniTaskPubSub;
using UnityEngine;
using VContainer;

namespace Survival.Item
{
    public class ItemsController : MonoBehaviour
    {
        [SerializeField] private GameFieldProvider _gameFieldProvider;
        [SerializeField] private ItemsSpawnerConfig _itemsSpawnerConfig;
        
        private ItemsSpawner _itemsSpawner;
        private List<Item> _spawnedItems = new();
        private readonly CompositeDisposable _subscriptions = new();
        private IPlayerTransformProvider _playerTransformProvider;

        private void Awake()
        {
            _itemsSpawner = new ItemsSpawner(_itemsSpawnerConfig, _gameFieldProvider);
            _spawnedItems = _itemsSpawner.SpawnItems();
        }
        
        private void OnDisable()
        {
            _subscriptions?.Dispose();
        }
        
        [Inject]
        public void Construct(IAsyncSubscriber subscriber, IPlayerTransformProvider playerTransformProvider)
        {
            _playerTransformProvider = playerTransformProvider;
            _subscriptions.Add(subscriber.Subscribe<ItemPickedUpEvent>(OnItemPickedUp));
            _subscriptions.Add(subscriber.Subscribe<WeaponDroppedEvent>(OnWeaponDropped));
        }

        private void OnItemPickedUp(ItemPickedUpEvent eventData)
        {
            var pickedUpItem = eventData.Item;
            _spawnedItems.Remove(pickedUpItem);
            Destroy(pickedUpItem.gameObject);
        }
        
        private void OnWeaponDropped(WeaponDroppedEvent eventData)
        {
            var spawnPosition = _playerTransformProvider.Transform.position;
            var item = Instantiate(eventData.WeaponConfig.Prefab, spawnPosition, Quaternion.identity);
            _spawnedItems.Add(item);
        }
    }
}
using System.Collections.Generic;
using Survival.GameField;
using UnityEngine;

namespace Survival.Item
{
    public class ItemsSpawner
    {
        private readonly GameFieldProvider _gameFieldProvider;
        private readonly ItemsSpawnerConfig _itemsSpawnerConfig;
        private const int MaxSpawnAttempts = 100;
        
        public ItemsSpawner(ItemsSpawnerConfig itemsSpawnerConfig, GameFieldProvider gameFieldProvider)
        {
            _itemsSpawnerConfig = itemsSpawnerConfig;
            _gameFieldProvider = gameFieldProvider;
        }
        
        public List<Item> SpawnItems()
        {
            List<Item> spawnedItems = new List<Item>();
            
            for (int i = 0; i < _itemsSpawnerConfig.WeaponCount; i++)
            {
                bool weaponSpawned = false;
                int attempts = 0;
                
                while (!weaponSpawned && attempts < MaxSpawnAttempts)
                {
                    var fieldMin = _gameFieldProvider.FieldMin;
                    var fieldMax = _gameFieldProvider.FieldMax;

                    var randomPosition = new Vector2(
                        Random.Range(fieldMin.x, fieldMax.x),
                        Random.Range(fieldMin.y, fieldMax.y)
                    );

                    var randomWeaponIndex = Random.Range(0, _itemsSpawnerConfig.ItemPrefabs.Length);
                    var item = Object.Instantiate(_itemsSpawnerConfig.ItemPrefabs[randomWeaponIndex], randomPosition, Quaternion.identity);
                    spawnedItems.Add(item);
                    weaponSpawned = true;
                    
                    attempts++;
                }

                if (!weaponSpawned)
                {
                    Debug.LogWarning("Не удалось заспавнить предмет после максимального количества попыток.");
                }
            }
            
            return spawnedItems;
        }
    }
}
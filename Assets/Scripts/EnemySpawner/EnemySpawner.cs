using UnityEngine;

namespace Survival
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private Enemy _enemyPrefab;

        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private int initialEnemiesCount = 5;

        [SerializeField]
        private Transform _targetTransform;

        public void Spawn()
        {
            for (int i = 0; i < initialEnemiesCount; i++)
            {
                var enemy = Instantiate(_enemyPrefab, _spawnPoint);
                enemy.Initialize(_targetTransform);
            }
        }
    }
}
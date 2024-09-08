using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        public void Move(Transform targetTransform)
        {
            Vector3 direction = (targetTransform.position - transform.position).normalized;
            transform.position += direction * _speed * Time.deltaTime;
        }
    }
}
using UnityEngine;

namespace Survival
{
    public class MoveToPoint
    {
        private readonly Transform _enemyTransform;
        private readonly Transform _targetTransform;
        private Animator _animator;
        private float _speed;

        public MoveToPoint(Transform enemyTransform, Transform targetTransform, Animator animator, float speed)
        {
            _targetTransform = targetTransform;
            _enemyTransform = enemyTransform;
            _animator = animator;
            _speed = speed;
        }

        public void Move()
        {
            var direction = _targetTransform.position - _enemyTransform.position;
            direction.Normalize();
            _enemyTransform.position = direction * Time.deltaTime * _speed;
            //_animator.SetFloat("Speed", _speed);
        }

        public void RefreshSpeed(float speed)
        {
            _speed = speed;
        }
    }
}
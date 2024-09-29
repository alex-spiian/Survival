using UnityEngine;

namespace Survival
{
    public class Idle
    {
        private Animator _animator;
        private Rigidbody2D _rigidbody;

        public Idle(Animator animator, Rigidbody2D rigidbody)
        {
            _animator = animator;
            _rigidbody = rigidbody;
        }

        public void Start()
        {
            _animator.SetTrigger("Idle");
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
using UnityEngine;

namespace Survival.Enemy
{
    public class Idle
    {
        private Animator _animator;

        public Idle(Animator animator)
        {
            _animator = animator;
        }

        public void Start()
        {
            _animator.SetTrigger("Idle");
        }
    }
}
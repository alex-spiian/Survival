using UnityEngine;

namespace Survival
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
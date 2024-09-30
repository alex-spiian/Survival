using UnityEngine;

namespace Survival.Enemy
{
    public class Idle
    {
        private Animator _animator;
        private static readonly int _idle = Animator.StringToHash("Idle");

        public Idle(Animator animator)
        {
            _animator = animator;
        }

        public void Start()
        {
            _animator.SetTrigger(_idle);
        }
    }
}
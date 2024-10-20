using UnityEngine;

namespace Survival.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationHandler : MonoBehaviour
    {
        private Animator _animator;
        private readonly int Speed = Animator.StringToHash("Speed");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void HandleAnimations(float speed)
        {
            _animator.SetFloat(Speed, speed);
        }
    }
}
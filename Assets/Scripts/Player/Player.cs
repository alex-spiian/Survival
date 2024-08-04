using DefaultNamespace;
using InputHandler;
using UnityEngine;
using VContainer;

namespace Player
{
    [RequireComponent(typeof(PlayerAnimationHandler))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private PlayerAnimationHandler _animationHandler;
        private MovementController _movementController;
        private IInputHandler _inputHandler;

        private bool _canMove;

        private void Start()
        {
            _movementController = new MovementController();
            _animationHandler = GetComponent<PlayerAnimationHandler>();
        }

        [Inject]
        public void Construct(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            _canMove = true;
        }

        private void FixedUpdate()
        {
            if (!_canMove) return;
            var input = _inputHandler.GetInput();
            var currentSpeed = _movementController.Move(input, transform, _speed);
            _animationHandler.HandleAnimations(currentSpeed);
        }
    }
}
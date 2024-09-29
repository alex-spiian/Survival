using Survival;
using UnityEngine;
using VContainer;

namespace Survival
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private PlayerAnimationHandler _animationHandler;
        
        private MovementController _movementController;
        private IInputHandler _inputHandler;

        private void Start()
        {
            _movementController = new MovementController();
        }

        [Inject]
        public void Construct(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private void FixedUpdate()
        {
            var input = _inputHandler.GetInput();
            var currentSpeed = _movementController.Move(input, transform, _speed);
            _animationHandler.HandleAnimations(currentSpeed);
        }
    }
}
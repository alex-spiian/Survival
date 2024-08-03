using System;
using DefaultNamespace;
using InputHandler;
using UnityEngine;
using VContainer;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private MovementController _movementController;
    private IInputHandler _inputHandler;

    private bool _canMove;

    private void Start()
    {
        _movementController = new MovementController();
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
        _movementController.Move(input, transform, _speed);
    }
}

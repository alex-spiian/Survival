using UnityEngine;

namespace InputHandler
{
    public class StandaloneInputHandler : IInputHandler
    {
        public Vector2 GetInput()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}
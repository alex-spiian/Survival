using UnityEngine;

namespace DefaultNamespace
{
    public class MovementController
    {
        public void Move(Vector2 input, Transform transform, float speed)
        {
            var velocity = input.normalized * speed;
            transform.position += (Vector3)velocity * Time.deltaTime;
        }
    }
}
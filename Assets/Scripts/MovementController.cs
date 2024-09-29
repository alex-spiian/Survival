using UnityEngine;

namespace Survival
{
    public class MovementController
    {
        private float _leftSide = -1;
        private float _rightSide = 1;

        public float Move(Vector2 input, Transform transform, float speed)
        {
            var velocity = input.normalized * speed;
            transform.position += (Vector3)velocity * Time.deltaTime;

            LookAt(input.x, transform);
            return CalculateSpeed(input, speed);
        }
        
        private float CalculateSpeed(Vector2 input, float speed)
        {
            return Mathf.Max(Mathf.Abs(input.x), Mathf.Abs(input.y)) * speed;
        }

        private void LookAt(float x, Transform transform)
        {
            if (x < 0)
            {
                transform.localScale = new Vector3(_leftSide, transform.localScale.y, transform.localScale.z);
            }

            if (x > 0)
            {
                transform.localScale = new Vector3(_rightSide, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
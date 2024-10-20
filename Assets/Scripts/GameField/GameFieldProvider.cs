using UnityEngine;

namespace Survival.GameField
{
    public class GameFieldProvider : MonoBehaviour
    {
        public Vector2 FieldMin => new (_leftBorder.bounds.max.x, _bottomBorder.bounds.max.y);
        public Vector2 FieldMax => new (_rightBorder.bounds.min.x, _topBorder.bounds.min.y);

        [SerializeField] private BoxCollider2D _topBorder;
        [SerializeField] private BoxCollider2D _bottomBorder;
        [SerializeField] private BoxCollider2D _leftBorder;
        [SerializeField] private BoxCollider2D _rightBorder;
    }
}
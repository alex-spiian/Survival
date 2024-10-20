using UnityEngine;

namespace Survival.Player
{
    public interface IPlayerTransformProvider
    {
        public Transform Transform { get; }
    }
}
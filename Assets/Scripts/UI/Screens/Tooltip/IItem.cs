using Survival;
using UnityEngine;

namespace Survival.UI
{
    public interface IItem
    {
        public ItemConfig ItemConfig { get; }
        public Transform Transform { get; }
    }
}
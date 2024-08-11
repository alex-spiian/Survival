using Item;
using UnityEngine;

namespace Screens.Tooltip
{
    public interface IItem
    {
        public ItemConfig ItemConfig { get; }
        public Transform Transform { get; }
    }
}
using System;
using JetBrains.Annotations;
using Survival.Item;
using UnityEngine;
using UnityEngine.UI;

namespace Survival.UI
{
    public class InventoryItem : MonoBehaviour, IItem
    {
        public Action<InventoryItem> Selected;
        
        public ItemConfig ItemConfig { get; private set; }
        public Transform Transform => transform;
        
        [SerializeField] private Image _itemIcon;
        [SerializeField] private Image _background;

        public void Initialize(ItemConfig itemConfig)
        {
            ItemConfig = itemConfig;
            _itemIcon.sprite = ItemConfig.Icon;
            _background.color = Color.white;
        }
        
        [UsedImplicitly]
        public void OnClick()
        {
            Selected?.Invoke(this);
        }

        public void OnSelected()
        {
            _background.color = Color.black;
        }

        public void OnDeSelected()
        {
            _background.color = Color.white;
        }
    }
}
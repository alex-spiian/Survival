using Survival.Item;
using UnityEngine;

namespace Survival.UI
{
    public class TooltipContext
    {
        public ItemConfig ItemConfig { get; }
        public RectTransform RectTransform { get; }
        public TooltipType TooltipType { get; }
        
        public TooltipContext(ItemConfig itemConfig,
            RectTransform rectTransform, TooltipType tooltipType)
        {
            ItemConfig = itemConfig;
            RectTransform = rectTransform;
            TooltipType = tooltipType;
        }
    }
}
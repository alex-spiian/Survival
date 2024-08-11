using Item;
using UnityEngine;

namespace Screens.Tooltip
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
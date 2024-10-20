using System;
using UnityEngine;

namespace Survival.UI
{
    [Serializable]
    public class TooltipData
    {
        [field:SerializeField]
        public TooltipType TooltipType { get; private set; }
        
        [field:SerializeField]
        public ItemTooltip Tooltip { get; private set; }
    }
}
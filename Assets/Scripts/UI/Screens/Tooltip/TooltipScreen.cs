using System.Linq;
using ScreenManager.Core;
using UnityEngine;

namespace Survival.UI
{
    public class TooltipScreen : UIScreen<TooltipContext>
    {
        [SerializeField]
        private TooltipData[] _tooltipsData;
        
        public override void Initialize(TooltipContext context)
        {
            // you can create different tooltips on the screen and choose any of them by type
            var tooltipData =
                _tooltipsData.FirstOrDefault(tooltipData => tooltipData.TooltipType == context.TooltipType);
            
            tooltipData.Tooltip.Initialize(context.ItemConfig, context.RectTransform);
        }
    }
}
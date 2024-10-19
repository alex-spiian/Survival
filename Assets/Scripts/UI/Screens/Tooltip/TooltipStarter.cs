using JetBrains.Annotations;
using UnityEngine;

namespace Survival.UI
{
    // put this component on an object you want to display a tooltip
    [RequireComponent(typeof(IItem))]
    public class TooltipStarter : MonoBehaviour
    {
        [SerializeField]
        private TooltipType _tooltipType;

        [SerializeField] private int delay;
        
        private IItem _item;
        private bool _isTooltipOpen;

        private void Awake()
        {
            _item = GetComponent<IItem>();
        }
        
        [UsedImplicitly]
        public void OnPointerClick()
        {
            ScreensManager.OpenScreen<TooltipScreen, TooltipContext>
                (new TooltipContext(_item.ItemConfig, _item.Transform as RectTransform, _tooltipType));
            _isTooltipOpen = true;
        }
    }
}
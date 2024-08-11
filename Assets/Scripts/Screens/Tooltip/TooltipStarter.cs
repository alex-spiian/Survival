using UnityEngine;
using UnityEngine.EventSystems;

namespace Screens.Tooltip
{
    // put this component on an object you want to display a tooltip
    public class TooltipStarter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private TooltipType _tooltipType;
        
        private IItem _item;
        private void Awake()
        {
            _item = GetComponent<IItem>();
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            ScreensManager.OpenScreen<TooltipScreen, TooltipContext>
                (new TooltipContext(_item.ItemConfig, _item.Transform as RectTransform, _tooltipType));
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ScreensManager.CloseScreen<TooltipScreen>();
        }
    }
}
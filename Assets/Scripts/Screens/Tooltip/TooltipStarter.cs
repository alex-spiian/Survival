using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Screens.Tooltip
{
    // put this component on an object you want to display a tooltip
    [RequireComponent(typeof(IItem))]
    public class TooltipStarter : MonoBehaviour
    {
        [SerializeField]
        private TooltipType _tooltipType;
        
        private IItem _item;
        private bool _isTooltipOpen;

        private void Awake()
        {
            _item = GetComponent<IItem>();
        }
        
        private async void Update()
        {
            if (_isTooltipOpen && Input.GetMouseButtonDown(0))
            {
                if (!IsPointerOverThisElement())
                {
                    await UniTask.Delay(500);
                    ScreensManager.CloseScreen<TooltipScreen>();
                    _isTooltipOpen = false;
                }
            }
        }
        
        [UsedImplicitly]
        public void OnPointerClick()
        {
            ScreensManager.OpenScreen<TooltipScreen, TooltipContext>
                (new TooltipContext(_item.ItemConfig, _item.Transform as RectTransform, _tooltipType));
            _isTooltipOpen = true;
        }
        
        private bool IsPointerOverThisElement()
        {
            return RectTransformUtility.RectangleContainsScreenPoint(
                _item.Transform as RectTransform, 
                Input.mousePosition, 
                Camera.main
            );
        }
    }
}
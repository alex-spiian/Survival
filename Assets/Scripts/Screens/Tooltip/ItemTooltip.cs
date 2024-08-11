using Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.Tooltip
{
    public class ItemTooltip : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _name;
        
        private RectTransform _tooltipRectTransform;

        private void Awake()
        {
            _tooltipRectTransform = GetComponent<RectTransform>();
        }

        public virtual void Initialize(ItemConfig itemConfig, RectTransform rectTransform)
        {
            SetValue(itemConfig);
            var offset = Vector2.zero;
            SetPosition(rectTransform, offset);
        }

        protected virtual void SetValue(ItemConfig itemConfig)
        {
            _name.text = itemConfig.Name.ToUpper();
            _icon.sprite = itemConfig.Icon;
        }

        protected void SetPosition(RectTransform itemRectTransform, Vector2 offset)
        {
            // for canvas render mode "Screen Space - Camera" you must provide the right camera you need
            var screenPoint = RectTransformUtility.WorldToScreenPoint(null, itemRectTransform.position);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _tooltipRectTransform.parent as RectTransform, screenPoint, null, out var positionOnCanvas);

            _tooltipRectTransform.anchoredPosition = positionOnCanvas + offset;
        }
    }
}
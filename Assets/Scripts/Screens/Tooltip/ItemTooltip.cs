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

        public void Initialize(ItemConfig itemConfig, RectTransform rectTransform)
        {
            SetValue(itemConfig);
            SetPosition(rectTransform);
        }

        private void SetValue(ItemConfig itemConfig)
        {
            _name.text = itemConfig.Name.ToUpper();
            _icon.sprite = itemConfig.Icon;
        }

        private void SetPosition(RectTransform itemRectTransform)
        {
            // for canvas render mode "Screen Space - Camera" you must provide the right camera you need
            var screenPoint = RectTransformUtility.WorldToScreenPoint(null, itemRectTransform.position);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _tooltipRectTransform.parent as RectTransform, screenPoint, null, out var positionOnCanvas);

            var offset = new Vector2(itemRectTransform.sizeDelta.x / 2, 0f);
            _tooltipRectTransform.anchoredPosition = positionOnCanvas + offset;
        }
    }
}
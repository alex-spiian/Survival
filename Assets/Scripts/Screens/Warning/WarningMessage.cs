using TMPro;
using UnityEngine;

namespace Screens.Warning
{
    public class WarningMessage : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _header;
        
        [SerializeField]
        private TextMeshProUGUI _content;
        
        public void Initialize(string header, string content)
        {
            _header.text = header;
            _content.text = content;
        }
    }
}
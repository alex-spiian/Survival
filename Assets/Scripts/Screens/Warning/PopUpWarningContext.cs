using UnityEngine;

namespace Survival.UI.Warning
{
    public class PopUpWarningContext
    {
        public string Header { get; }
        public string Content { get; }
        
        public Transform ObjectToPayAttention { get; }

        public PopUpWarningContext(string header, string content, Transform objectToPayAttention)
        {
            Header = header;
            Content = content;
            ObjectToPayAttention = objectToPayAttention;
        }
    }
}
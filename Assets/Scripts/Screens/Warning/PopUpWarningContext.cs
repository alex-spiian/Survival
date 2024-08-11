namespace Screens.Warning
{
    public class PopUpWarningContext
    {
        public string Header { get; }
        public string Content { get; }

        public PopUpWarningContext(string header, string content)
        {
            Header = header;
            Content = content;
        }
    }
}
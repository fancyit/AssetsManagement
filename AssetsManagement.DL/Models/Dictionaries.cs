namespace AssetsManagement.DL.Models
{
    public enum MessageSeverity
    {
        INFORMATION = 0,
        WARNING,
        ERROR,
        UNKNOWN
    }

    public class ServiceMessage
    {
        public MessageSeverity Severity { get; set; }
        public string MessageText { get; set; }
    }
}

namespace MVC_Apps.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string? ControllerName { get; set; }
        public string? ActonName { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
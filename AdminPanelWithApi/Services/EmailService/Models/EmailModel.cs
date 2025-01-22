namespace AdminPanelWithApi.Services.EmailService.Models
{
    public class EmailModel
    {
        public required EmailConfigurationModel? EmailConfiguration { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public required List<string> ToEmailList { get; set; }

    }
}

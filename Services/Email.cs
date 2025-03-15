namespace yonoma.Services
{
    public class EmailService
    {
        private readonly ApiClient _apiClient;

        public EmailService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        // Send an Email
        public async Task<string> SendEmailAsync(
            string fromEmail,
            string toEmail,
            string subject,
            string mailTemplate
        )
        {
            var data = new
            {
                from_email = fromEmail,
                to_email = toEmail,
                subject = subject,
                mail_template = mailTemplate
            };

            return await _apiClient.PostAsync("email/send", data);
        }
    }
}

using yonoma.Services;

namespace yonoma
{
    public class Yonoma
    {
        private readonly ApiClient _client;

        // Expose services as properties
        public ListService Lists { get; }
        public TagService Tags { get; }
        public ContactService Contacts { get; }
        public EmailService Email { get; }

        // Constructor to initialize the API key once
        public Yonoma(string apiKey)
        {
            _client = new ApiClient(apiKey);
            Lists = new ListService(_client);
            Tags = new TagService(_client);
            Contacts = new ContactService(_client);
            Email = new EmailService(_client);
        }
    }
}

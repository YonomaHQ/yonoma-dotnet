namespace yonoma.Services
{
    public class ContactService(ApiClient apiClient)
    {
        private readonly ApiClient _apiClient = apiClient;

        // CREATE A CONTACT
        public async Task<string> Create(
            string listId,
            string email,
            string status,
            string firstName,
            string lastName,
            string phone,
            string dateOfBirth,
            string address,
            string city,
            string state,
            string country,
            string zipcode
        )
        {
            var contactData = new
            {
                email = email,
                status = status,
                firstName = firstName,
                lastName = lastName,
                phone = phone,
                company = company,
                address = address,
                city = city,
                state = state,
                country = country,
                zipCode = zipCode
            };

            return await _apiClient.PostAsync($"contacts/{listId}/create", contactData);
        }

        // UNSUBSCRIBE A CONTACT
        public async Task<string> Unsubscribe(string listId, string contactId, string status)
        {
            var data = new { status = status };
            return await _apiClient.PostAsync($"contacts/{listId}/status/{contactId}", data);
        }

        // LABEL A CONTACT WITH A TAG
        public async Task<string> AddTag(string contactId, string tagId)
        {
            var data = new { tag_id = tagId };
            return await _apiClient.PostAsync($"contacts/tags/{contactId}/add", data);
        }

        // REMOVE A TAG FROM A CONTACT
        public async Task<string> RemoveTag(string contactId, string tagId)
        {
            var data = new { tag_id = tagId };
            return await _apiClient.PostAsync($"contacts/tags/{contactId}/remove", data);
        }
    }
}

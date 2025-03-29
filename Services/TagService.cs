namespace yonoma.Services
{
    public class TagService(ApiClient apiClient)
    {
        private readonly ApiClient _apiClient = apiClient;

        // List all tags
        public async Task<string> List()
        {
            return await _apiClient.GetAsync("tags/list");
        }

        // Create a new tag
        public async Task<string> Create(string tagName)
        {
            var data = new { tag_name = tagName };
            return await _apiClient.PostAsync("tags/create", data);
        }

        // Update an existing tag
        public async Task<string> Update(string tagId, string newName)
        {
            var data = new { tag_name = newName };
            return await _apiClient.PostAsync($"tags/{tagId}/update", data);
        }

        // Retrieve a specific tag
        public async Task<string> Retrieve(string tagId)
        {
            return await _apiClient.GetAsync($"tags/{tagId}");
        }

        // Delete a tag
        public async Task<string> Delete(string tagId)
        {
            var data = new { };
            return await _apiClient.DeleteAsync($"tags/{tagId}/delete", data);
        }
    }
}

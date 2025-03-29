namespace yonoma.Services
{
    public class ListService(ApiClient apiClient)
    {
        private readonly ApiClient _apiClient = apiClient;

        public async Task<string> Lists()
        {
            return await _apiClient.GetAsync("lists/list");
        }

        // Create a new list
        public async Task<string> Create(string listName)
        {
            var data = new { list_name = listName };
            return await _apiClient.PostAsync("lists/create", data);
        }

        // Update an existing list    
        public async Task<string> Update(string listId, string listName)
        {
            var data = new { list_name = listName };
            return await _apiClient.PostAsync($"lists/{listId}/update", data);
        }

        // Retrieve a specific list
        public async Task<string> Retrieve(string listId)
        {
            return await _apiClient.GetAsync($"lists/{listId}");
        }

        // Delete a list
        public async Task<string> Delete(string listId)
        {
            var data = new { };
            return await _apiClient.DeleteAsync($"lists/{listId}/delete", data);
        }
    }
}

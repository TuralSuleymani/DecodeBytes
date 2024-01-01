using System.Net.Http;

namespace WpfAsyncUI.Services
{
    internal class WebDocumentService
    {
        public async Task<string> GetContentAsync(string requestUri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(requestUri); // I/O bound operation
                return response;
            }
        }
    }
}

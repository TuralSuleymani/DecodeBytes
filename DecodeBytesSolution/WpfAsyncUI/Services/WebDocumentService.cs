using System.Net.Http;

namespace WpfAsyncUI.Services
{
    internal class WebDocumentService
    {
        public async Task<string> GetContentAsync(string requestUri)
        {
            return await new HttpClient().GetStringAsync(requestUri);
        }
    }
}

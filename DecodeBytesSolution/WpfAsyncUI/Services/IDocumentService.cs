
namespace WpfAsyncUI.Services
{
    internal interface IDocumentService
    {
        Task<string> GetContentAsync(string requestUri);
    }
}
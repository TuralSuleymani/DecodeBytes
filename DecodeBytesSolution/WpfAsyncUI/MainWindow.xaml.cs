using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using WpfAsyncUI.Services;

namespace WpfAsyncUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WebDocumentService _documentService;
        public MainWindow()
        {
            InitializeComponent();
            _documentService = new WebDocumentService();
        }

        //private async void load_Click(object sender, RoutedEventArgs e)
        //{
        //    Debug.WriteLine("Operation started. Normal flow");
        //    string contentUrl = "https://www.c-sharpcorner.com/article/microservices-vs-monoliths/";
        //    var articleContent = await _documentService.GetContentAsync(contentUrl);
        //    txbx_content.Document = AsFlowDocument(articleContent);
        //}

        private void load_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Operation started. Deadlock");
            string contentUrl = "https://www.c-sharpcorner.com/article/microservices-vs-monoliths/";
            var documentTask = _documentService.GetContentAsync(contentUrl);//schedule
            documentTask.Wait();//block the UI
            txbx_content.Document = AsFlowDocument("You are not going to see this message");
        }

        private static FlowDocument AsFlowDocument(string content)
        {
            FlowDocument flowDocument = new();
            flowDocument.Blocks.Add(new Paragraph(new Run(content)));
            return flowDocument;
        }

    }
}
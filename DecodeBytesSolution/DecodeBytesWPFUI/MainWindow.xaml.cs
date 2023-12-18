using System.Windows;

namespace DecodeBytes.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowProviderVisualizer _providerVisualizer;
        public MainWindow()
        {
            InitializeComponent();
            _providerVisualizer = new WindowProviderVisualizer(x_mainPanel);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _providerVisualizer.RenderProviders();
        }
    }
}
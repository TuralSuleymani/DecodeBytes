using DecodeBytes.Common.Contracts;
using DecodeBytes.Common.Implementations;
using DecodeBytes.Provider;
using System.Windows.Controls;

namespace DecodeBytesWPFUI
{
    /// <summary>
    /// Responsible for provider visualisation
    /// </summary>
    public class WindowProviderVisualizer: IProviderVisualizer
    {
        private readonly Panel _panel;
        private int _locationX;
        private int _locationY;
        private ProviderService _providerService;

        public WindowProviderVisualizer(Panel panel)
        {
            _panel = panel;
            _providerService = new ProviderService();
            InitializeDefaultParams();
        }
        
        public void RenderProviders()
        {
            ClearProviders();
            var providers = _providerService.GetProviders();

            foreach (var provider in providers)
            {
                AddProvider(provider);
            }
        }
        private void ClearProviders()
        {
            _panel.Children.Clear();
            InitializeDefaultParams();
        }
        private void InitializeDefaultParams()
        {
            _locationX = 20;
            _locationY = 34;
        }

        private void AddProvider(IBankProvider provider)
        {
            Button button = new()
            {
                Content = provider.ProviderName,
                Height =  100,
                Width = 150,
                Margin = new System.Windows.Thickness(_locationX,_locationY,0,0)
            };
            button.Click += (sndr, args) =>
            {
                new BankWindow(provider).ShowDialog();
            };
            _panel.Children.Add(button);
            _locationX += 150;
        }
    }
}

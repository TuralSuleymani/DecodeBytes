using DecodeBytes.Common.Contracts;
using DecodeBytes.Common.Implementations;
using DecodeBytes.Provider;

namespace DecodeBytes.WinForm
{
    /// <summary>
    /// Responsible for provider visualisation
    /// </summary>
    public class FormProviderVisualizer : IProviderVisualizer
    {
        private readonly Control _control;
        private int _locationX;
        private int _locationY;
        private ProviderService _providerService;

        public FormProviderVisualizer(Control control)
        {
            _control = control;
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
            _control.Controls.Clear();
            InitializeDefaultParams();
        }
        private void InitializeDefaultParams()
        {
            _locationX = 20;
            _locationY = 34;
        }

        private void AddProvider(BankProvider provider)
        {
            Button button = new()
            {
                Text = provider.ProviderName,
                Size = new Size(150, 100),
                Location = new Point(_locationX, _locationY)
            };
            button.Click += (sndr, args) =>
            {
                new BankForm(provider).ShowDialog();
            };
            _control.Controls.Add(button);
            _locationX += 150;
        }
    }
}

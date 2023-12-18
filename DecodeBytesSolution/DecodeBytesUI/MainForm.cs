namespace DecodeBytesUI
{
    public partial class MainForm : Form
    {
        private FormProviderVisualizer _providerVisualizer;
        public MainForm()
        {
            InitializeComponent();
            _providerVisualizer = new FormProviderVisualizer(grbx_bank);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //get path to libs folder
            _providerVisualizer.RenderProviders();
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            _providerVisualizer.RenderProviders();
        }
    }
}

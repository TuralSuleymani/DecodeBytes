using DecodeBytes.Provider;

namespace DecodeBytesUI
{
    public partial class BankForm : Form
    {
        private readonly IBankProvider _bankProvider;
        public BankForm(IBankProvider bankProvider)
        {
            _bankProvider = bankProvider;
            InitializeComponent();
        }

        private void BankForm_Load(object sender, EventArgs e)
        {
            this.Text = _bankProvider.ProviderName;
        }

        private void btn_addToBalance_Click(object sender, EventArgs e)
        {
            CardNumber cardNumber = new CardNumber(txbx_cardNumber.Text);
            decimal amount = Convert.ToDecimal(txbx_amount.Text);
            _bankProvider.AddToBalance(cardNumber, amount);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CardNumber cardNumber = new CardNumber(txbx_cardNumber.Text);
           decimal balance = _bankProvider.GetBalance(cardNumber);
            MessageBox.Show(balance.ToString());
        }
    }
}

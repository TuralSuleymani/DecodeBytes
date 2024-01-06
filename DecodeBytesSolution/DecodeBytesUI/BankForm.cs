using DecodeBytes.Common.Implementations;
using DecodeBytes.Provider;

namespace DecodeBytes.WinForm
{
    public partial class BankForm : Form
    {
        private readonly BankProvider _bankProvider;
        public BankForm(BankProvider bankProvider)
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
            if(String.IsNullOrEmpty(txbx_amount.Text)|| String.IsNullOrEmpty(txbx_cardNumber.Text))
            {
                MessageBox.Show("Not allowed empty input");
                return;
            }
            CardNumber cardNumber = new CardNumber(txbx_cardNumber.Text);
            decimal amount = Convert.ToDecimal(txbx_amount.Text);
            _bankProvider.AddToBalance(cardNumber, amount);
        }

        private void btnCheckBalance_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txbx_cardNumber.Text))
            {
                MessageBox.Show("Not allowed empty input");
                return;
            }
            CardNumber cardNumber = new CardNumber(txbx_cardNumber.Text);
           decimal balance = _bankProvider.GetBalance(cardNumber);
            MessageBox.Show(balance.ToString());
        }
    }
}

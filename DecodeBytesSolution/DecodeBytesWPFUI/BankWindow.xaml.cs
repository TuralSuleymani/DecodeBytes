using DecodeBytes.Provider;
using System.Windows;

namespace DecodeBytesWPFUI
{
    /// <summary>
    /// Interaction logic for BankWindow.xaml
    /// </summary>
    public partial class BankWindow : Window
    {
        private IBankProvider _bankProvider;
        public BankWindow(IBankProvider bankProvider)
        {
            InitializeComponent();
            _bankProvider = bankProvider;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CardNumber cardNumber = new CardNumber(txbx_cardnumber.Text);
           MessageBox.Show( _bankProvider.GetBalance(cardNumber).ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CardNumber cardNumber = new CardNumber(txbx_cardnumber.Text);
            _bankProvider.AddToBalance(cardNumber, Convert.ToDecimal(txbx_amount.Text));
        }
    }
}

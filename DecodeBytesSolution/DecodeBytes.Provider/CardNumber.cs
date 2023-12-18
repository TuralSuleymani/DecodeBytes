using System.Text.RegularExpressions;

namespace DecodeBytes.Provider
{
    /// <summary>
    /// Card number domain entity
    /// </summary>
    public partial class CardNumber
    {
        public string Number { get; private set; }
        public CardNumber(string cardNumber)
        {
            CardNumberRegExp().IsMatch(cardNumber);
            Number = cardNumber;
        }

        [GeneratedRegex(@"\\d{4}-\\d{4}-\\d{4}-\\d{4}")]
        private static partial Regex CardNumberRegExp();
    }
}

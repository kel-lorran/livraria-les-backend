using System;
using Shared;

namespace Domain.CustomerContext
{
    public class CreditCard : Identity<CreditCard, int>
    {
        public CreditCard()
        {
        }

        public CreditCard(string creditCardCompany, string cardNumber, DateTime validity, string label)
        {
            CreditCardCompany = creditCardCompany;
            CardNumber = cardNumber;
            Validity = validity;
            Label = label;
        }

        public string CreditCardCompany { get; set; }
        public string CardNumber { get; set; }
        public DateTime Validity { get; set; }
        public string Label { get; set; }
    }
}
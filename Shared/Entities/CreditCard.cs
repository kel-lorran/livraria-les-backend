using System;
using Shared;

namespace Domain.Shared.Entities
{
    public class CreditCard : Entity
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
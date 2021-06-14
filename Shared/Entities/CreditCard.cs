using System;
using Shared;

namespace Domain.Shared.Entities
{
    public class CreditCard : Identity<CreditCard, int>
    {
        public CreditCard()
        {
        }

        public CreditCard(CreditCard card)
        {
            CreditCardCompany = card.CreditCardCompany;
            CardNumber = card.CardNumber;
            Validity = card.Validity;
            Label = card.Label;
        }

        public CreditCard(string creditCardCompany, string cardNumber, DateTime validity, string label)
        {
            CreditCardCompany = creditCardCompany;
            CardNumber = cardNumber;
            Validity = validity;
            Label = label;
        }

        public int Id { get => base.Id; set => base.Id = value; }
        public string CreditCardCompany { get; set; }
        public string CardNumber { get; set; }
        public DateTime Validity { get; set; }
        public string Label { get; set; }
    }
}
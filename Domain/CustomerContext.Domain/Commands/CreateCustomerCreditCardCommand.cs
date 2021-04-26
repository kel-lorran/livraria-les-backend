using System;
using Shared;
using Shared.Utils;

namespace Domain.CustomerContext
{
    public class CreateCustomerCreditCardCommand : ICommand
    {
        public CreateCustomerCreditCardCommand()
        {
        }

        public CreateCustomerCreditCardCommand(string creditCardCompany, string cardNumber, string validity, string label, int customerId)
        {
            CreditCardCompany = creditCardCompany;
            CardNumber = cardNumber;
            Validity = validity;
            Label = label;
            CustomerId = customerId;
        }

        public string CreditCardCompany { get; set; }
        public string CardNumber { get; set; }
        public string Validity { get; set; }
        public string Label { get; set; }
        public int CustomerId { get; set; }

    }
}
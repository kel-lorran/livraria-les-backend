using System;
using Shared;
using Shared.Utils;

namespace Domain.CustomerContext
{
    public class CreateCustomerCreditCardCommand : ICommandWithValidation
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

        public GenericCommandResult Validate()
        {
            var result = true;
            var message = "";

            if (!TextValidator.Validity(CreditCardCompany)) {
                result = false;
                message += "CreditCardCompany is required\n";
            }
            if (!TextValidator.Validity(CardNumber, @"\d{16}", @"\D")) {
                result = false;
                message += "CardNumber is required\n";
            }
            if (!TextValidator.Validity(Validity, @"\d{1,2}\/\d{4}")) {
                if (StringToDateTime.Convert(Validity, "M/yyyy") < DateTime.Now) {
                    result = false;
                    message += "Validity is invalid, allow MM/yyyy\n";
                }
            }
            if (!TextValidator.Validity(Label)) {
                result = false;
                message += "Label is required\n";
            }
            
            return new GenericCommandResult(result, message);
        }
    }
}
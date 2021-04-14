using Shared;

namespace Domain.CustomerContext
{
    public class UpdateCustomerPersonDataCommand : ICommand
    {
        public UpdateCustomerPersonDataCommand()
        {
        }

        public UpdateCustomerPersonDataCommand(string name, string lastName, string gender, string cPF, string birthDate, string phone, string email, int active)
        {
            Name = name;
            LastName = lastName;
            Gender = gender;
            CPF = cPF;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Active = active;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string CPF { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Active { get; set; }

        public Customer MergeEntity(Customer customer)
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                var value = prop.GetValue(this);
                if(value != null)
                    System.Console.WriteLine(prop.Name);
                    prop.SetValue(customer, value);
            }
            return customer;
        }
    }
}
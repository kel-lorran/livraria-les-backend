using System;
using System.Collections.Generic;
using System.Linq;
using Domain.CustomerContext;
using Domain.MerchandiseContext;
using Domain.Shared.Entities;
using Domain.UserContext;
using Shared.Utils;

namespace Infra.FakeData
{
    public static class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            try
            {
                // var manager = new User("kelvinlorran_2010@hotmail.com", "123", "manager");
                // var address = new Address(
                //     "casa",
                //     "rua",
                //     "cedro",
                //     "21",
                //     "09944620",
                //     "Jd União",
                //     "Colorado",
                //     "Acre",
                //     "Brasil",
                //     "",
                //     "end principal"
                // );

                // var card =  new CreditCard(
                //     "Visa",
                //     "1234123412341234",
                //     StringToDateTime.Convert("18/12/2023"),
                //     "meu cartãozão"
                // );

                // var customer = new Customer(
                //     "Kelvin",
                //     "Jesus",
                //     "masculino",
                //     "01234567890",
                //     StringToDateTime.Convert("18/05/1993"),
                //     "1144224488",
                //     "kelvinlorran_2010@hotmail.com",
                //     1,
                //     new List<Address>{address}
                // );

                // context.Users.Add(manager); 
                // context.Customers.Add(customer);

                // context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR SEEDATA]: {ex.Message}");
            }
        }

    }
}
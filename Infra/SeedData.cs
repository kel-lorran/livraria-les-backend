using System;
using System.Linq;
using Domain.UserContext;

namespace Infra.FakeData
{
    public static class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            try
            {
                if (context.Users.Any()) return;

                context.Users.Add(new User("kelvinlorran_2010@hotmail.com", "123", "manager"));           

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR SEEDATA]: {ex.Message}");
            }
        }

    }
}
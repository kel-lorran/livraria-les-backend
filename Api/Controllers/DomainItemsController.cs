using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.CustomerContext;
using Domain.MerchandiseContext;
using Domain.Shared.Entities;
using Domain.UserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Utils;

namespace Api
{
    [ApiController]
    [Route("v1/domain-items")]
    public class DomainItemsController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public dynamic Populate(
            [FromServices]IUserRepository repository,
            [FromServices]ICustomerRepository customerRepository,
            [FromServices]IProductRepository productRepository,
            [FromServices]IMerchandiseRepository merchandiseRepository,
            [FromServices]ICategoryRepository categoryRepository,
            [FromServices]IPriceGroupRepository priceGroupRepository
        )
        {
            if (customerRepository.GetAll().Count() > 0)
                return BadRequest();
            
            var manager = new User { Email = "kelvinlorran_2010@hotmail.com", Password = "123", Role = "manager" };
            repository.CreateUser(manager);
            repository.SaveChanges();

            var address = new Address {
                HomeType = "casa",
                PublicPlaceType = "rua",
                PublicPlaceName = "um",
                HomeNumber = "11",
                CEP = "08843660",
                Neighborhood = "Jardim modelo",
                City = "Cidade piloto",
                State = "Acre",
                Country = "Brasil",
                Complement = "",
                AddressLabel = "end principal"
            };

            var customer = new Customer {
                UserId = manager.Id,
                Name = "Kelvin",
                LastName = "Jesus",
                Gender = "m",
                CPF = "01234567890",
                BirthDate = StringToDateTime.Convert("18/05/1993"),
                Phone = "1147224889",
                Email = manager.Email,
                Active = 1,
                AddressList = new List<Address> {address},
            };

            var card = new CreditCard {
                CreditCardCompany = "visa",
                CardNumber = "1234123412341234",
                Validity = StringToDateTime.Convert("05/2025", "M/yyyy"),
                Label = "meu visa principal"
            };

            customer.CreditCardList = new List<CreditCard> {card};

            customerRepository.CreateCustomer(customer);
            customerRepository.SaveChanges();

            var pG1 = new PriceGroup("Padrão", 1.2f);
            var pG2 = new PriceGroup("Estratégico", 0.75f);
            var pG3 = new PriceGroup("Especial", 1.4f);

            priceGroupRepository.CreateManyPriceGroup(new List<PriceGroup> {pG1, pG2, pG3});
            priceGroupRepository.SaveChanges();

            var cat1 = new Category("Aventura", "volumes com contos fantasiosos e fantásticos");
            var cat2 = new Category("Suspense", "volumes com histórias de misterio");
            var cat3 = new Category("Romance", "livros com historias de paixão e amor");
            var cat4 = new Category("Técnicos", "faciculos com aplicações práticas em diciplinas exatas");
            var cat5 = new Category("Infantis", "contos lúdicos pra crianças");
            var cat6 = new Category("Quadrinhos", "historias ilustradas de ficcção cientificas e ação para jovens");

            categoryRepository.CreateManyCategory(new List<Category> { cat1, cat2, cat3, cat5, cat6 });
            categoryRepository.SaveChanges();

            return Ok();
        }
        [HttpGet]
        [Route("category")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<List<Category>>> GetAllCategories (
            [FromServices]ICategoryRepository categoryRepository
        )
        {
            return Ok(categoryRepository.getAll());
        }
        [HttpGet]
        [Route("price-group")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<List<PriceGroup>>> GetAllCategories (
            [FromServices]IPriceGroupRepository pGRepository
        )
        {
            return Ok(pGRepository.GetAll());
        }
    }
}
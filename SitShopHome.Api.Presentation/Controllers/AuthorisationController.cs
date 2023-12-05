using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects;
using SitShopHome.Api.Presentation.ActionFilters;
using SitShopHome.API.Presentation;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SitShopHome.Api.Presentation.Controllers
{
    [ApiController]
    [Route("api/authorisation/[action]")]
    public class AuthorisationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public AuthorisationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var customer = _serviceManager.Customer.GetCustomerByEmailAndPassword(email, password, trackChanges: false);

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, email) };

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var ecodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                customerId = customer.CustomerId,
                access_token = ecodedJwt
            };
            return Ok(response);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Registration([FromBody] CustomerForManipulationDTO customerForManipulation, DateOnly? birth)
        {
            //Проверка на уникальный логин
            if (birth is null)
                return BadRequest("Sent birth cant be null");

            var customer = _serviceManager.Customer.CreateCustomer(customerForManipulation, (DateOnly)birth);

            return CreatedAtRoute("GetCustomerById", new {controller = "Customers", customerId = customer.CustomerId }, customer);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model.Entities;
using Model.Services.Customers;

namespace CustomersApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    [EnableCors("AllowCors")]
    public class CustomersController : Controller
    {

        private readonly ICustomerServices _horseService;


        public CustomersController(ICustomerServices horseService)
        {
            _horseService = horseService;

        }

       // [ServiceFilter(typeof(DigestAuthenticationFilterAttribute))]
        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _horseService.GetCustomers();
        }


        // POST: api/Customers
        [HttpPost]
        public async Task<IActionResult> PostCustomers([FromBody] Customer customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _horseService.InsertCustomer(customers);
            

            return CreatedAtAction("GetCustomers", new { id = customers.CustomerId }, customers);
        }
    }
}
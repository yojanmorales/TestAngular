using ModeloNet;
using ModeloNet.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APINET.Controllers
{
    public class CustomersController : ApiController
    {


        readonly FachadaCustomers _repository;

        public CustomersController()

        {
            _repository = new FachadaCustomers();
        }





        // GET api/Customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _repository.GetCustomers();
        }


    }
}
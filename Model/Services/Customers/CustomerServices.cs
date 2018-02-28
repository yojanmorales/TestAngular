using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model.Model.Context;
using Model.Model.Entities;
using Model.Model.Repository;

namespace Model.Services.Customers
{
    public class CustomerServices : ICustomerServices
    {


        private readonly IRepository<Customer> _customerRepository;



        public CustomerServices(IRepository<Customer> horseRepository)
        {
            _customerRepository = horseRepository;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var horses = _customerRepository.GetAll();
            return horses;

        }


        public void InsertCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
        }
    }
}

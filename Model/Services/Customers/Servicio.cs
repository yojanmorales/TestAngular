using System;
using System.Collections.Generic;
using System.Text;
using Model.Model.Entities;

namespace Model.Services.Customers
{
    public class Servicio:IServicio
    {

       
        //ICustomerServices _countryRepository;

        //public Servicio(ICustomerServices countryRepository)
        //    : base(new CustomerServices(countryRepository))
        //{
          
        //    _countryRepository = countryRepository;
        //}

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public void InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}

using Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Services.Customers
{
    public interface ICustomerServices
    {

        IEnumerable<Customer> GetCustomers();
        void InsertCustomer(Customer customer);
       
    }
}

using ModeloNet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloNet.Servicio
{
    public class CustomerServices : ICustomerServices
    {


        private readonly CustomerDao _customerDao;



        public CustomerServices()
        {
            _customerDao = new CustomerDao();
        }

        public List<Customer> GetCustomers()
        {
            var customerslist = _customerDao.GetCustomers();
            return customerslist;

        }


        public void InsertCustomer(Customer customer)
        {
            // _customerRepository.Add(customer);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloNet.Servicio
{
    public interface ICustomerServices
    {

        List<Customer> GetCustomers();
        void InsertCustomer(Customer customer);

      

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloNet.Servicio
{
    public interface ICustomerServices
    {

        IEnumerable<Customer> GetCustomers();
        void InsertCustomer(Customer customer);

      

    }
}

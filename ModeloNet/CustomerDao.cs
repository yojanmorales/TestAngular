using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloNet
{
    public class CustomerDao
    {

        public List<Customer> GetCustomers()
        {
            using (ModeloNetContext con = new ModeloNetContext())
            {
                return con.Customer.ToList();
            }
        }
    }
}

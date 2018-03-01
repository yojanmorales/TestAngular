using ModeloNet.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloNet
{
    public class FachadaCustomers
    {
        private readonly ICustomerServices _ContextoRepositorio;
        public FachadaCustomers()
            : this(new CustomerServices())
        {
        }

        public FachadaCustomers(ICustomerServices contextoRepositorio)
        {
            this._ContextoRepositorio = contextoRepositorio;
        }

        public List<Customer> GetCustomers()
        {
            return _ContextoRepositorio.GetCustomers();
        }
    }
}

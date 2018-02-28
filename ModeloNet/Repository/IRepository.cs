using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloNet.Repository
{
    public interface IRepository<T>
    {
        T Get<TKey>(TKey id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloNet.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ModeloNetContext Context;
        protected DbSet<T> DbSet;

        public Repository()
        {
            Context = new ModeloNetContext();
            DbSet = Context.Set<T>();
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);

            Save();
        }

        public T Get<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public void Update(T entity)
        {
            Save();
        }

        private void Save()
        {
            Context.SaveChanges();
        }
    }
}

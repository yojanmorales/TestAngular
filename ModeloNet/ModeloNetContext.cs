using ModeloNet.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloNet
{
    public class ModeloNetContext : DbContext
    {
        public ModeloNetContext() :
            base("ModeloNetContext")
        {
            Configure();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ModeloNetContext, Configuration>());
        }
        public virtual DbSet<Customer> Customer { get; set; }
        public void Configure()
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = true;

        }

    }
}

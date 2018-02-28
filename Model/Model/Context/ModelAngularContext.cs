using Microsoft.EntityFrameworkCore;
using Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model.Context
{
    public class ModelAngularContext : DbContext
    {

        public ModelAngularContext(DbContextOptions<ModelAngularContext> options)
           : base(options)
        {


        }

        public DbSet<Customer> Customers { get; set; }
    }
}

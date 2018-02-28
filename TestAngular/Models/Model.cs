using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class TestAngularjContext : DbContext
    {
        public TestAngularjContext(DbContextOptions<TestAngularjContext> options)
            : base(options)
        {
            

        }

        public DbSet<Customers> Customers { get; set; }

    }

    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }

    }


}
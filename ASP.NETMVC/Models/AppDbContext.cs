using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ASP.NETMVC.Models
{
 
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
        //public override void OnConfiguring(DbContextOptionsBuilder builder) => base.OnConfiguring(builder);
        //public override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        base.OnModelCreating(modelBuilder);
        //        //foreach(var entityType in modelBuilder.Model.GetEntityTypes())
        //        //{
        //        //    var tableName = entityType.GetTableName();
        //        //    if (tableName.StartsWith("AspNet"))
        //        //    {
        //        //        entityType.SetTableName(tableName.Substring(6));
        //        //    }
        //        //}
        //    }

        public DbSet<ProductEntity> MyProperty { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}

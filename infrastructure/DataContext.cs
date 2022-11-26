using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Portfolio>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    
                    Id = Guid.NewGuid(),
                    Avater = "avatar.jpg",
                    Fullname = "Khalid ESSAADANI",
                    Profile = "Microsoft MVP / .NET Consultant",
                    
                }
                );
        }

        public DbSet<Owner> owners { get; set; }
        public DbSet<Portfolio> portfolios { get; set; }
      


    }
}

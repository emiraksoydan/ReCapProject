using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContextDal : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCapProject;Trusted_Connection=true");
           
        }

        public DbSet<Car> Cars  { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().ToTable("Brands");
            modelBuilder.Entity<Brand>().Property(p => p.BrandId).HasColumnName("BrandId");
            modelBuilder.Entity<Brand>().Property(p => p.BrandName).HasColumnName("BrandName");
        }
    }
}

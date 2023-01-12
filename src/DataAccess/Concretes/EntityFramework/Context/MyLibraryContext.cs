using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concretes.EntityFramework.Context
{
    public class MyLibraryContext : DbContext
    {
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=mylibrarydb;Port=5432;User Id=postgres;Password=postgres;");

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


        //protected IConfiguration Configuration { get; set; }
        //public MyLibraryContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        //{
        //    Configuration = configuration;
        //}

        //public MyLibraryContext()
        //{

        //}


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Book>(m =>
        //    {
        //        m.ToTable("Books").HasKey(b => b.Id);
        //        m.Property(b => b.Id).HasColumnName("Id");
        //        m.Property(b => b.Name).HasColumnName("Name");
        //        m.Property(b => b.Author).HasColumnName("Author");
        //        m.Property(b => b.Publisher).HasColumnName("Publisher");
        //        m.Property(b => b.Read).HasColumnName("Read");
        //    });

        //    modelBuilder.Entity<Category>(m =>
        //    {
        //        m.ToTable("Categories").HasKey(c => c.CategoryId);
        //        m.Property(c => c.CategoryId).HasColumnName("Id");
        //        m.Property(c => c.Name).HasColumnName("Name");
        //    });



        //}
    }
}

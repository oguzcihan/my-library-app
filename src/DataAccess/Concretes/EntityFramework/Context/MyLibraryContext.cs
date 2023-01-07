using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concretes.EntityFramework.Context
{
    public class MyLibraryContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MyLibraryContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(m =>
            {
                m.ToTable("Books").HasKey(b => b.Id);
                m.Property(b => b.Id).HasColumnName("Id");
                m.Property(b => b.Name).HasColumnName("Name");
                m.Property(b => b.Author).HasColumnName("Author");
                m.Property(b => b.Publisher).HasColumnName("Publisher");
                m.Property(b => b.Read).HasColumnName("Read");
                m.HasMany(b => b.Categories); //her kitabın birden fazla kategorisi vardır
            });

            modelBuilder.Entity<Category>(m =>
            {
                m.ToTable("Categories").HasKey(c => c.CategoryId);
                m.Property(c => c.CategoryId).HasColumnName("Id");
                m.Property(c => c.Name).HasColumnName("Name");
            });



        }
    }
}

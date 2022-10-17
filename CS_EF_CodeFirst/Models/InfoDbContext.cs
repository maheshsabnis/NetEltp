using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_CodeFirst.Models
{
    public class InfoDbContext : DbContext
    {
        public InfoDbContext()
        {

        }
        // ENtity Mapping with Table
        public DbSet<Person> Persons { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// THis method will be haing COnnctionstring to database
        /// DbContextOptionsBuilder: The class that uses an extension method to connet to database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data SOurce=.;Initial Catalog=CodiCodeFirst; Integrated Security=SSPI;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        /// <summary>
        /// The Method that will contain code for Relatios (if Any) 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // IMplement One-to-Many Relationships with Foreign Key
            // Between Category and Product

            modelBuilder.Entity<Product>()
                        // One Product HAs One Category
                        // One-to-one Relationship
                        .HasOne<Category>(p => p.Category)
                        // One Category HAs Multiple Products
                        // One-To-any Relationshs
                        .WithMany(c => c.Products)
                        .HasForeignKey(p => p.CategoryRowId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

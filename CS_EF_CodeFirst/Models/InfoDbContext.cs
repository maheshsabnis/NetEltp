using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductionUnit> ProductionUnits { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<WebSeries> WebSeries { get; set; }

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

            // Estabishig Many-To-Many Relations
            modelBuilder.Entity<Customer>()
                        // One Customer HAs Many Orders
                        .HasMany<Order>(c=>c.Orders)
                        // Each Order belongs to Mahny Customers
                        .WithMany(o=>o.Customers)
                        // CReate a New Table
                        // a new Table will be created
                        // with CustomerId and OrderId in it
                        .UsingEntity(relation => relation.ToTable("CustomersOrders"));



            // create a seed data
            var movies = new Movies[]
            {
                 new Movies(){ Id=1, Name="Dr.No",ReleaseYear=1963,
                     Category="Spy",BoxOfficeCollection=12222,PlayDuration=150},
                 new Movies(){ Id=2, Name="Golmal",ReleaseYear=1976,
                     Category="Comedy",BoxOfficeCollection=122,PlayDuration=180}
            };
            var series = new WebSeries[]
            {
                new WebSeries(){ Id=3, Name="Ramayan",ReleaseYear=1986,Seasons=2,EpisodPerSeason=100},
                new WebSeries(){ Id=4, Name="House of Cards",ReleaseYear=2005,Seasons=6,EpisodPerSeason=50}
            };

            // define a union
            // Case Movies to ProductionUnit with all its data and then Union it 
            // with WebSeries. This will make sure that the Movies and WebSeries classes are
            // union together so FLuentyAPI will map all using the ProductUnit table
            var productionUnit = movies.Cast<ProductionUnit>()
                    .Union(series)
                    .ToList();

            // link the data to the model builder
            // model mapping will generate a Single table ProductUnit
            // // having a 'descriminator' column to sagrigate the row for each derive type
            modelBuilder.Entity<Movies>().HasData(movies);
            modelBuilder.Entity<WebSeries>().HasData(series);


            base.OnModelCreating(modelBuilder);
        }
    }
}

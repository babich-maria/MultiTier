using DAL.Domain;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataBase
{
    public class StoreContext : DbContext, IStoreContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
           : base(options)
        {
        }
       
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
              .HasIndex(u => u.Iso)
              .IsUnique();

            modelBuilder.Entity<Customer>()
             .HasKey(c => new { c.CustomerId, c.Name });

            modelBuilder.Entity<Address>()
            .HasKey(c => new { c.CustomerId, c.AddressTypeId });

            modelBuilder.Entity<Country>().HasData(
               new Country { CountryId = 20, Iso = "BY", Name = "Belarus" },
               new Country { CountryId = 80, Iso = "DE", Name = "Germany" },
               new Country { CountryId = 171, Iso = "PL", Name = "Poland" });

            modelBuilder.Entity<AddressType>().HasData(
                new AddressType { AddressTypeId = 1, Code = "I", Description = "invoice address" },
                new AddressType { AddressTypeId = 2, Code = "D", Description = "delivery address" },
                new AddressType { AddressTypeId = 3, Code = "S", Description = "service address" });

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = "1", Name = "Alex", Street = "Gaja", ZIP = "24605", City = "Wroclaw", CountryId = 171 },
                new Customer { CustomerId = "2", Name = "Alex", Street = "Swieta", ZIP = "35605", City = "Grodno", CountryId = 20 },
                new Customer { CustomerId = "1", Name = "Ola", Street = "Jasna", ZIP = "67605", City = "Wroclaw", CountryId = 171 },
                new Customer { CustomerId = "3", Name = "Ola", Street = "Czysta", ZIP = "24777", City = "Katovice", CountryId = 171 });

            modelBuilder.Entity<Address>().HasData(
                new Address { CustomerId = "1", AddressTypeId = 1, Name = "Alex", Street = "Zielona", ZIP = "24605", City = "Wroclaw", CountryId = 171 },
                new Address { CustomerId = "1", AddressTypeId = 2, Name = "Alex", Street = "Czerwona", ZIP = "24601", City = "Wroclaw", CountryId = 171 },
                new Address { CustomerId = "3", AddressTypeId = 3, Name = "Ola", Street = "Pomaranczowa", ZIP = "24605", City = "Wroclaw", CountryId = 171 },
                new Address { CustomerId = "2", AddressTypeId = 2, Name = "Alex", Street = "Szara", ZIP = "24601", City = "Wroclaw", CountryId = 171 });

        }
    }
}

﻿// <auto-generated />
using DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApp.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Domain.Address", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("varchar(5)");

                    b.Property<int>("AddressTypeId");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ZIP")
                        .HasColumnType("varchar(20)");

                    b.HasKey("CustomerId", "AddressTypeId");

                    b.HasIndex("AddressTypeId");

                    b.HasIndex("CountryId");

                    b.HasIndex("CustomerId", "Name");

                    b.ToTable("Adresses");

                    b.HasData(
                        new
                        {
                            CustomerId = "1",
                            AddressTypeId = 1,
                            City = "Wroclaw",
                            CountryId = 171,
                            Name = "Alex",
                            Street = "Zielona",
                            ZIP = "24605"
                        },
                        new
                        {
                            CustomerId = "1",
                            AddressTypeId = 2,
                            City = "Wroclaw",
                            CountryId = 171,
                            Name = "Alex",
                            Street = "Czerwona",
                            ZIP = "24601"
                        },
                        new
                        {
                            CustomerId = "3",
                            AddressTypeId = 3,
                            City = "Wroclaw",
                            CountryId = 171,
                            Name = "Ola",
                            Street = "Pomaranczowa",
                            ZIP = "24605"
                        },
                        new
                        {
                            CustomerId = "2",
                            AddressTypeId = 2,
                            City = "Wroclaw",
                            CountryId = 171,
                            Name = "Alex",
                            Street = "Szara",
                            ZIP = "24601"
                        });
                });

            modelBuilder.Entity("DAL.Domain.AddressType", b =>
                {
                    b.Property<int>("AddressTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Description");

                    b.HasKey("AddressTypeId");

                    b.ToTable("AddressType");

                    b.HasData(
                        new
                        {
                            AddressTypeId = 1,
                            Code = "I",
                            Description = "invoice address"
                        },
                        new
                        {
                            AddressTypeId = 2,
                            Code = "D",
                            Description = "delivery address"
                        },
                        new
                        {
                            AddressTypeId = 3,
                            Code = "S",
                            Description = "service address"
                        });
                });

            modelBuilder.Entity("DAL.Domain.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Iso")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Iso3")
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("NumCode");

                    b.Property<string>("PhoneCode");

                    b.HasKey("CountryId");

                    b.HasIndex("Iso")
                        .IsUnique();

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            CountryId = 20,
                            Iso = "BY",
                            Name = "Belarus"
                        },
                        new
                        {
                            CountryId = 80,
                            Iso = "DE",
                            Name = "Germany"
                        },
                        new
                        {
                            CountryId = 171,
                            Iso = "PL",
                            Name = "Poland"
                        });
                });

            modelBuilder.Entity("DAL.Domain.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CountryId");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ZIP")
                        .HasColumnType("varchar(20)");

                    b.HasKey("CustomerId", "Name");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = "1",
                            Name = "Alex",
                            City = "Wroclaw",
                            CountryId = 171,
                            Street = "Gaja",
                            ZIP = "24605"
                        },
                        new
                        {
                            CustomerId = "2",
                            Name = "Alex",
                            City = "Grodno",
                            CountryId = 20,
                            Street = "Swieta",
                            ZIP = "35605"
                        },
                        new
                        {
                            CustomerId = "1",
                            Name = "Ola",
                            City = "Wroclaw",
                            CountryId = 171,
                            Street = "Jasna",
                            ZIP = "67605"
                        },
                        new
                        {
                            CustomerId = "3",
                            Name = "Ola",
                            City = "Katovice",
                            CountryId = 171,
                            Street = "Czysta",
                            ZIP = "24777"
                        });
                });

            modelBuilder.Entity("DAL.Domain.Address", b =>
                {
                    b.HasOne("DAL.Domain.AddressType", "AddressType")
                        .WithMany()
                        .HasForeignKey("AddressTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId", "Name");
                });

            modelBuilder.Entity("DAL.Domain.Customer", b =>
                {
                    b.HasOne("DAL.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

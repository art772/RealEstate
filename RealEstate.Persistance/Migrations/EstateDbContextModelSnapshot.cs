﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstate.Persistance;

#nullable disable

namespace RealEstate.Persistance.Migrations
{
    [DbContext(typeof(EstateDbContext))]
    partial class EstateDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RealEstate.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InactivatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7296),
                            Name = "Sprzedaż",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7334),
                            Name = "Wynajem",
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Estate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<double>("EstateArea")
                        .HasColumnType("float");

                    b.Property<string>("FlatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InactivatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfConstruction")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GenreId");

                    b.HasIndex("StateId");

                    b.ToTable("Estates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            City = "Poznań",
                            Country = "Polska",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7600),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nec ultricies nisl.",
                            EstateArea = 150.0,
                            FlatNumber = "5",
                            GenreId = 2,
                            Name = "Mieszkanie na sprzedaż 150m2",
                            Price = 500000.0,
                            StateId = 1,
                            StatusId = 1,
                            Street = "Dąbrowskiego",
                            StreetNumber = "10",
                            YearOfConstruction = 2022,
                            ZipCode = "60-123"
                        });
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.EstateTag", b =>
                {
                    b.Property<int>("EstateId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("EstateId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("EstateTags");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InactivatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7499),
                            Name = "Dom",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7505),
                            Name = "Mieszkanie",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7507),
                            Name = "Kawalerka",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7510),
                            Name = "Apartament",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7512),
                            Name = "Biuro",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7514),
                            Name = "Pokój",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 7,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7517),
                            Name = "Lokal usługowy",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 8,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7520),
                            Name = "Garaż",
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InactivatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7545),
                            Name = "Dostępne",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7548),
                            Name = "Niedostępne",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7550),
                            Name = "Zarezerwowane",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7552),
                            Name = "Wynajęte",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7555),
                            Name = "Sprzedane",
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InactivatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7574),
                            Name = "Ogród",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7576),
                            Name = "Taras",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7579),
                            Name = "Winda",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7581),
                            Name = "Basen",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2023, 4, 5, 19, 37, 42, 13, DateTimeKind.Local).AddTicks(7584),
                            Name = "Piętrowy",
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Estate", b =>
                {
                    b.HasOne("RealEstate.Domain.Entities.Category", "Category")
                        .WithMany("Estates")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Domain.Entities.Genre", "Genre")
                        .WithMany("Estates")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Domain.Entities.State", "State")
                        .WithMany("Estates")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Genre");

                    b.Navigation("State");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.EstateTag", b =>
                {
                    b.HasOne("RealEstate.Domain.Entities.Tag", "Tag")
                        .WithMany("EstateTags")
                        .HasForeignKey("EstateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Domain.Entities.Estate", "Estate")
                        .WithMany("EstateTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estate");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Category", b =>
                {
                    b.Navigation("Estates");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Estate", b =>
                {
                    b.Navigation("EstateTags");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Genre", b =>
                {
                    b.Navigation("Estates");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.State", b =>
                {
                    b.Navigation("Estates");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Tag", b =>
                {
                    b.Navigation("EstateTags");
                });
#pragma warning restore 612, 618
        }
    }
}

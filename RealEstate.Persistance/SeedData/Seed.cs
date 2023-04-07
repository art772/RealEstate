using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Persistance.SeedData
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 1, Name = "Sprzedaż" },
                new Category() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 2, Name = "Wynajem" }
                );

            modelBuilder.Entity<Genre>().HasData(
                new Genre() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 1, Name = "Dom" },
                new Genre() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 2, Name = "Mieszkanie" },
                new Genre() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 3, Name = "Kawalerka" },
                new Genre() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 4, Name = "Apartament" },
                new Genre() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 5, Name = "Biuro" },
                new Genre() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 6, Name = "Pokój" },
                new Genre() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 7, Name = "Lokal usługowy" },
                new Genre() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 8, Name = "Garaż" }
                );

            modelBuilder.Entity<State>().HasData(
                new State() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 1, Name = "Dostępne" },
                new State() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 2, Name = "Niedostępne" },
                new State() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 3, Name = "Zarezerwowane" },
                new State() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 4, Name = "Wynajęte" },
                new State() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 5, Name = "Sprzedane" }
                );

            modelBuilder.Entity<Tag>().HasData(
                new Tag() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 1, Name = "Ogród" },
                new Tag() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 2, Name = "Taras" },
                new Tag() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 3, Name = "Winda" },
                new Tag() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 4, Name = "Basen" },
                new Tag() { CreatedBy = "Admin", StatusId = 1, CreatedDate = DateTime.Now, Id = 5, Name = "Piętrowy" }
                );

            modelBuilder.Entity<Estate>().HasData(
                new Estate()
                {
                    CreatedBy = "Admin",
                    StatusId = 1,
                    CreatedDate = DateTime.Now,
                    Id = 1,
                    Name = "Mieszkanie na sprzedaż 150m2",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nec ultricies nisl.",
                    Street = "Dąbrowskiego",
                    StreetNumber = "10",
                    FlatNumber = "5",
                    City = "Poznań",
                    ZipCode = "60-123",
                    Country = "Polska",
                    Price = 500000.00,
                    EstateArea = 150.00,
                    YearOfConstruction = 2022,
                    CategoryId = 1,
                    GenreId = 2,
                    StateId = 1,
                }
                );
            
        }
    }
}

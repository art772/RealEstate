using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Application.Estates.Commands.CreateEstate;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstate.Persistance
{
    public static class EstateDbContextSeed
    {
        public static async Task SeedUserRolesAsync(RoleManager<IdentityRole<int>> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Roles.SuperAdministrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Roles.User.ToString()));
        }

        public static async Task SeedDefaultSuperAdmin(UserManager<ApplicationUser> userManager)
        {
            var user = new ApplicationUser()
            {
                UserName = "SAdmin",
                FirstName = "Super",
                LastName = "Administrator",
                Email = "admin@admin.pl",
                IsBanned = false
            };

            var password = "Password123!";

            await userManager.CreateAsync(user, password);

            await userManager.AddToRoleAsync(user, "SuperAdministrator");
        }

        public static async Task SeedDefaultData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 1, Name = "Sprzedaż" },
                new Category() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 2, Name = "Wynajem" }
                );

            modelBuilder.Entity<Genre>().HasData(
                new Genre() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 1, Name = "Dom" },
                new Genre() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 2, Name = "Mieszkanie" },
                new Genre() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 3, Name = "Kawalerka" },
                new Genre() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 4, Name = "Apartament" },
                new Genre() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 5, Name = "Biuro" },
                new Genre() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 6, Name = "Pokój" },
                new Genre() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 7, Name = "Lokal usługowy" },
                new Genre() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 8, Name = "Garaż" }
                );

            modelBuilder.Entity<State>().HasData(
                new State() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 1, Name = "Dostępne" },
                new State() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 2, Name = "Niedostępne" },
                new State() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 3, Name = "Zarezerwowane" },
                new State() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 4, Name = "Wynajęte" },
                new State() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 5, Name = "Sprzedane" }
                );

            modelBuilder.Entity<Tag>().HasData(
                new Tag() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 1, Name = "Ogród" },
                new Tag() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 2, Name = "Taras" },
                new Tag() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 3, Name = "Winda" },
                new Tag() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 4, Name = "Basen" },
                new Tag() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 5, Name = "Piętrowy" }
                );

            modelBuilder.Entity<Estate>().HasData(
                new Estate()
                {
                    CreatedBy = "art772",
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

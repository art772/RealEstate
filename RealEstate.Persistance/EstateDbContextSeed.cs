using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;
using System.Drawing;

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

        //public static async Task SeedDefaultData(this ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>().HasData(
        //        new Category() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 1, Name = "Sprzedaż" },
        //        new Category() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 2, Name = "Wynajem" }
        //        );

        //    modelBuilder.Entity<Genre>().HasData(
        //        new Genre() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 1, Name = "Dom" },
        //        new Genre() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 2, Name = "Mieszkanie" },
        //        new Genre() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 3, Name = "Kawalerka" },
        //        new Genre() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 4, Name = "Apartament" },
        //        new Genre() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 5, Name = "Biuro" },
        //        new Genre() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 6, Name = "Pokój" },
        //        new Genre() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 7, Name = "Lokal usługowy" },
        //        new Genre() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 8, Name = "Garaż" }
        //        );

        //    modelBuilder.Entity<State>().HasData(
        //        new State() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 1, Name = "Dostępne" },
        //        new State() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 2, Name = "Niedostępne" },
        //        new State() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 3, Name = "Zarezerwowane" },
        //        new State() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 4, Name = "Wynajęte" },
        //        new State() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 5, Name = "Sprzedane" }
        //        );

        //    modelBuilder.Entity<Tag>().HasData(
        //        new Tag() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 1, Name = "Ogród" },
        //        new Tag() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 2, Name = "Taras" },
        //        new Tag() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 3, Name = "Winda" },
        //        new Tag() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 4, Name = "Basen" },
        //        new Tag() { CreatedBy = "SAdmin", StatusId = 1, CreatedDate = DateTime.Now, Id = 5, Name = "Piętrowy" }
        //        );

        //    modelBuilder.Entity<Estate>().HasData(
        //        new Estate()
        //        {
        //            CreatedBy = "SAdmin",
        //            StatusId = 1,
        //            CreatedDate = DateTime.Now,
        //            Id = 1,
        //            Name = "Dom na sprzedaż 150m2",
        //            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse laoreet metus risus, id efficitur sapien consequat sed. Interdum et malesuada fames ac ante ipsum primis in faucibus. Quisque accumsan varius dolor, et placerat tortor lobortis eget. Donec a facilisis ante. Maecenas vehicula nunc eu felis mattis mattis. Nullam diam nulla, fermentum ac tristique eu, rhoncus ac quam. Integer eleifend gravida sapien, at ornare ipsum suscipit sed.\r\n\r\nMauris vel congue massa. Sed elementum lectus sed urna euismod, quis condimentum nibh ultricies. Fusce dolor ex, pulvinar non ligula quis, gravida viverra lorem. Cras sed mi rhoncus sem venenatis elementum. Pellentesque nec felis ut leo sodales fringilla sed in dui. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nulla in commodo augue, eget rhoncus nisi. Phasellus justo ipsum, efficitur in porttitor vel, facilisis vitae mauris. Cras dapibus non ex ut scelerisque. Curabitur blandit imperdiet pulvinar.\r\n\r\nInteger blandit nunc sit amet pretium ornare. Etiam molestie dapibus nisi, non vestibulum orci tincidunt at. Aliquam ut augue a leo finibus molestie. Phasellus purus ligula, facilisis ut pellentesque non, tincidunt in sapien. Pellentesque dignissim tellus ex, ut aliquam enim scelerisque varius. Proin a leo eu ligula lacinia dapibus. Fusce ultrices sed ipsum et pellentesque.",
        //            Street = "Dąbrowskiego",
        //            StreetNumber = "220",
        //            FlatNumber = "",
        //            City = "Poznań",
        //            ZipCode = "60-123",
        //            Country = "Polska",
        //            Price = 1500000.00,
        //            EstateArea = 150.00,
        //            YearOfConstruction = 2020,
        //            MarketType = "Rynek wtórny",
        //            FinishState = "Do zamieszkania",
        //            Floor = 0,
        //            NumberOfRooms = 5,
        //            CategoryId = 1,
        //            GenreId = 1,
        //            StateId = 1,
        //            ApplicationUserId = 1
        //        },

        //        new Estate()
        //        {
        //            CreatedBy = "SAdmin",
        //            StatusId = 1,
        //            CreatedDate = DateTime.Now,
        //            Id = 2,
        //            Name = "Mieszkanie Wilczak 7 50m2",
        //            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse laoreet metus risus, id efficitur sapien consequat sed. Interdum et malesuada fames ac ante ipsum primis in faucibus. Quisque accumsan varius dolor, et placerat tortor lobortis eget. Donec a facilisis ante. Maecenas vehicula nunc eu felis mattis mattis. Nullam diam nulla, fermentum ac tristique eu, rhoncus ac quam. Integer eleifend gravida sapien, at ornare ipsum suscipit sed.\r\n\r\nMauris vel congue massa. Sed elementum lectus sed urna euismod, quis condimentum nibh ultricies. Fusce dolor ex, pulvinar non ligula quis, gravida viverra lorem. Cras sed mi rhoncus sem venenatis elementum. Pellentesque nec felis ut leo sodales fringilla sed in dui. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nulla in commodo augue, eget rhoncus nisi. Phasellus justo ipsum, efficitur in porttitor vel, facilisis vitae mauris. Cras dapibus non ex ut scelerisque. Curabitur blandit imperdiet pulvinar.\r\n\r\nInteger blandit nunc sit amet pretium ornare. Etiam molestie dapibus nisi, non vestibulum orci tincidunt at. Aliquam ut augue a leo finibus molestie. Phasellus purus ligula, facilisis ut pellentesque non, tincidunt in sapien. Pellentesque dignissim tellus ex, ut aliquam enim scelerisque varius. Proin a leo eu ligula lacinia dapibus. Fusce ultrices sed ipsum et pellentesque.",
        //            Street = "Wilczak",
        //            StreetNumber = "7",
        //            FlatNumber = "1",
        //            City = "Poznań",
        //            ZipCode = "60-672",
        //            Country = "Polska",
        //            Price = 500000.00,
        //            EstateArea = 50.00,
        //            YearOfConstruction = 2002,
        //            MarketType = "Rynek wtórny",
        //            FinishState = "Do zamieszkania",
        //            Floor = 0,
        //            NumberOfRooms = 2,
        //            CategoryId = 1,
        //            GenreId = 2,
        //            StateId = 1,
        //            ApplicationUserId = 1
        //        },

        //        new Estate()
        //        {
        //            CreatedBy = "SAdmin",
        //            StatusId = 1,
        //            CreatedDate = DateTime.Now,
        //            Id = 3,
        //            Name = "Mieszkanie 60m2 Nad wierzbakiem 3",
        //            Description = "Mauris vel congue massa. Sed elementum lectus sed urna euismod, quis condimentum nibh ultricies. Fusce dolor ex, pulvinar non ligula quis, gravida viverra lorem. Cras sed mi rhoncus sem venenatis elementum. Pellentesque nec felis ut leo sodales fringilla sed in dui. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nulla in commodo augue, eget rhoncus nisi. Phasellus justo ipsum, efficitur in porttitor vel, facilisis vitae mauris. Cras dapibus non ex ut scelerisque. Curabitur blandit imperdiet pulvinar.\r\n\r\nDonec pharetra imperdiet mauris, ac posuere velit vehicula ullamcorper. Phasellus enim risus, tristique in turpis quis, congue vehicula mi. Proin euismod ornare velit, quis porttitor purus porta blandit. Phasellus cursus urna quam, quis rhoncus massa dignissim placerat. Duis condimentum lacus nec leo ultricies, sit amet euismod dolor semper. Etiam faucibus justo at lorem consectetur gravida. Ut pretium magna quis magna viverra ornare. Curabitur ut elit dolor. Vivamus non dapibus sem. Donec efficitur non arcu a rhoncus. Cras pulvinar urna et dictum faucibus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Donec pharetra metus varius, dictum eros sed, laoreet purus. Suspendisse posuere ante eu orci molestie, sit amet finibus turpis ultricies. Proin sed lorem dui. Nulla non elementum tellus.",
        //            Street = "Nad wierzbakiem",
        //            StreetNumber = "3",
        //            FlatNumber = "4",
        //            City = "Poznań",
        //            ZipCode = "60-852",
        //            Country = "Polska",
        //            Price = 600000.00,
        //            EstateArea = 50.00,
        //            YearOfConstruction = 1998,
        //            MarketType = "Rynek wtórny",
        //            FinishState = "Do zamieszkania",
        //            Floor = 3,
        //            NumberOfRooms = 2,
        //            CategoryId = 1,
        //            GenreId = 2,
        //            StateId = 1,
        //            ApplicationUserId = 1
        //        },

        //        new Estate()
        //        {
        //            CreatedBy = "SAdmin",
        //            StatusId = 1,
        //            CreatedDate = DateTime.Now,
        //            Id = 4,
        //            Name = "Mieszkanie Poznańska 80m2",
        //            Description = "Morbi dictum lobortis pretium. Nulla finibus fringilla vestibulum. Nunc gravida lorem eget urna aliquam, sit amet rhoncus elit tristique. Ut fringilla lorem eget leo posuere malesuada. Proin in velit ut quam auctor vehicula. Pellentesque augue elit, posuere ac libero sed, vulputate consequat mauris. Donec sit amet tristique quam. Cras sit amet vehicula est. Aenean et magna quis est elementum consequat et at risus. Nunc tempus sem augue, eu rutrum ipsum porttitor quis. Nunc suscipit egestas mollis. Aliquam gravida turpis eu nulla lacinia pulvinar.\r\n\r\nDonec pharetra imperdiet mauris, ac posuere velit vehicula ullamcorper. Phasellus enim risus, tristique in turpis quis, congue vehicula mi. Proin euismod ornare velit, quis porttitor purus porta blandit. Phasellus cursus urna quam, quis rhoncus massa dignissim placerat. Duis condimentum lacus nec leo ultricies, sit amet euismod dolor semper. Etiam faucibus justo at lorem consectetur gravida. Ut pretium magna quis magna viverra ornare. Curabitur ut elit dolor. Vivamus non dapibus sem. Donec efficitur non arcu a rhoncus. Cras pulvinar urna et dictum faucibus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Donec pharetra metus varius, dictum eros sed, laoreet purus. Suspendisse posuere ante eu orci molestie, sit amet finibus turpis ultricies. Proin sed lorem dui. Nulla non elementum tellus.",
        //            Street = "Poznańska",
        //            StreetNumber = "18",
        //            FlatNumber = "34",
        //            City = "Poznań",
        //            ZipCode = "60-321",
        //            Country = "Polska",
        //            Price = 800000.00,
        //            EstateArea = 80.00,
        //            YearOfConstruction = 2023,
        //            MarketType = "Rynek pierwotny",
        //            FinishState = "Do remontu",
        //            Floor = 7,
        //            NumberOfRooms = 3,
        //            CategoryId = 1,
        //            GenreId = 2,
        //            StateId = 1,
        //            ApplicationUserId = 1
        //        }
        //    );
        //}

    }
}
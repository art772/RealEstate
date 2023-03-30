using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Persistance.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "InactivatedBy", "InactivatedDate", "ModifiedBy", "ModifiedDate", "Name", "StatusId" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2213), null, null, null, null, "Sprzedaż", 1 },
                    { 2, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2251), null, null, null, null, "Wynajem", 1 }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "InactivatedBy", "InactivatedDate", "ModifiedBy", "ModifiedDate", "Name", "StatusId" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2416), null, null, null, null, "Dom", 1 },
                    { 2, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2424), null, null, null, null, "Mieszkanie", 1 },
                    { 3, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2427), null, null, null, null, "Kawalerka", 1 },
                    { 4, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2429), null, null, null, null, "Apartament", 1 },
                    { 5, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2431), null, null, null, null, "Biuro", 1 },
                    { 6, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2434), null, null, null, null, "Pokój", 1 },
                    { 7, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2436), null, null, null, null, "Lokal usługowy", 1 },
                    { 8, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2438), null, null, null, null, "Garaż", 1 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "InactivatedBy", "InactivatedDate", "ModifiedBy", "ModifiedDate", "Name", "StatusId" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2459), null, null, null, null, "Dostępne", 1 },
                    { 2, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2462), null, null, null, null, "Niedostępne", 1 },
                    { 3, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2464), null, null, null, null, "Zarezerwowane", 1 },
                    { 4, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2467), null, null, null, null, "Wynajęte", 1 },
                    { 5, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2469), null, null, null, null, "Sprzedane", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "InactivatedBy", "InactivatedDate", "ModifiedBy", "ModifiedDate", "Name", "StatusId", "Value" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2486), null, null, null, null, "Ogród", 1, null },
                    { 2, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2490), null, null, null, null, "Taras", 1, null },
                    { 3, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2492), null, null, null, null, "Winda", 1, null },
                    { 4, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2494), null, null, null, null, "Basen", 1, null },
                    { 5, "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2497), null, null, null, null, "Piętrowy", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Estates",
                columns: new[] { "Id", "CategoryId", "City", "Country", "CreatedBy", "CreatedDate", "Description", "EstateArea", "FlatNumber", "GenreId", "InactivatedBy", "InactivatedDate", "ModifiedBy", "ModifiedDate", "Name", "Price", "StateId", "StatusId", "Street", "StreetNumber", "YearOfConstruction", "ZipCode" },
                values: new object[] { 1, 1, "Poznań", "Polska", "Admin", new DateTime(2023, 3, 29, 21, 41, 50, 650, DateTimeKind.Local).AddTicks(2514), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse nec ultricies nisl.", 150.0, "5", 2, null, null, null, null, "Mieszkanie na sprzedaż 150m2", 500000.0, 1, 1, "Dąbrowskiego", "10", 2022, "60-123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

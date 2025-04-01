using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MYDIARY.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingDataDiaryEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { 1, "Went on a long walk with Jenn.", new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), "Went on a walk" },
                    { 2, "Bake some double chocolate brownies.", new DateTime(2024, 3, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), "Baked brownies" },
                    { 3, "Went for movies with Jenn.", new DateTime(2024, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Went for movies" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

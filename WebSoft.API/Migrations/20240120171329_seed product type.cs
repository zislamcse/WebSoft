using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebSoft.API.Migrations
{
    /// <inheritdoc />
    public partial class seedproducttype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3b583571-3d65-4df0-ac8b-cdb439ade2b7"), "Tablet" },
                    { new Guid("e6c4969b-69de-43a9-90b4-9c9bc763a3f5"), "Capsule" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: new Guid("3b583571-3d65-4df0-ac8b-cdb439ade2b7"));

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: new Guid("e6c4969b-69de-43a9-90b4-9c9bc763a3f5"));
        }
    }
}

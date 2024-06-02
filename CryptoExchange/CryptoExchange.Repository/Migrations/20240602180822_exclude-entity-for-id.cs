using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoExchange.Repository.Migrations
{
    /// <inheritdoc />
    public partial class excludeentityforid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 6, 2, 18, 8, 22, 742, DateTimeKind.Utc).AddTicks(7845));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 6, 1, 18, 18, 39, 592, DateTimeKind.Utc).AddTicks(1569));
        }
    }
}

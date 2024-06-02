using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoExchange.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 6, 2, 18, 21, 6, 983, DateTimeKind.Utc).AddTicks(2169));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 6, 2, 18, 8, 22, 742, DateTimeKind.Utc).AddTicks(7845));
        }
    }
}

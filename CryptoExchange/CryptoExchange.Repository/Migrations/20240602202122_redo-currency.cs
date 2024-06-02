using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoExchange.Repository.Migrations
{
    /// <inheritdoc />
    public partial class redocurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrencyValue",
                table: "CurrencyValue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrencyValue",
                table: "CurrencyValue",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 6, 2, 20, 21, 21, 945, DateTimeKind.Utc).AddTicks(2316));

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyValue_PortfolioId_CurrencyId",
                table: "CurrencyValue",
                columns: new[] { "PortfolioId", "CurrencyId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrencyValue",
                table: "CurrencyValue");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyValue_PortfolioId_CurrencyId",
                table: "CurrencyValue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrencyValue",
                table: "CurrencyValue",
                columns: new[] { "PortfolioId", "CurrencyId" });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 6, 2, 19, 15, 41, 98, DateTimeKind.Utc).AddTicks(3117));
        }
    }
}

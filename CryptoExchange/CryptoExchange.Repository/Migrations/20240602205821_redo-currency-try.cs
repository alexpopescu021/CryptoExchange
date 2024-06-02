using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoExchange.Repository.Migrations
{
    /// <inheritdoc />
    public partial class redocurrencytry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CurrencyValue_PortfolioId_CurrencyId",
                table: "CurrencyValue");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 6, 2, 20, 58, 21, 778, DateTimeKind.Utc).AddTicks(4838));

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyValue_PortfolioId",
                table: "CurrencyValue",
                column: "PortfolioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CurrencyValue_PortfolioId",
                table: "CurrencyValue");

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
    }
}

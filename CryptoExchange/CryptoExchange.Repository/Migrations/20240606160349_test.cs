using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoExchange.Repository.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyValue_Currencies_CurrencyId",
                table: "CurrencyValue");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyValue_Portfolios_PortfolioId",
                table: "CurrencyValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Currencies_CurrencyId",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_CurrencyId",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Portfolios");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 6, 6, 16, 3, 49, 533, DateTimeKind.Utc).AddTicks(1858));

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyValue_Currencies_CurrencyId",
                table: "CurrencyValue",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyValue_Portfolios_PortfolioId",
                table: "CurrencyValue",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyValue_Currencies_CurrencyId",
                table: "CurrencyValue");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyValue_Portfolios_PortfolioId",
                table: "CurrencyValue");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CurrencyId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 6, 2, 20, 58, 21, 778, DateTimeKind.Utc).AddTicks(4838));

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_CurrencyId",
                table: "Portfolios",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyValue_Currencies_CurrencyId",
                table: "CurrencyValue",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyValue_Portfolios_PortfolioId",
                table: "CurrencyValue",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Currencies_CurrencyId",
                table: "Portfolios",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

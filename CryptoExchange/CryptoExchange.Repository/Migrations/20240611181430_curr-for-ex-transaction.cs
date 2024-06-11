using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoExchange.Repository.Migrations
{
    /// <inheritdoc />
    public partial class currforextransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CurrencyCode", "IsFiat" },
                values: new object[] { -1, "", true });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 6, 11, 18, 14, 30, 821, DateTimeKind.Utc).AddTicks(9151));

            migrationBuilder.CreateIndex(
                name: "IX_ExternalTransactions_CurrencyId",
                table: "ExternalTransactions",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalTransactions_Currencies_CurrencyId",
                table: "ExternalTransactions",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalTransactions_Currencies_CurrencyId",
                table: "ExternalTransactions");

            migrationBuilder.DropIndex(
                name: "IX_ExternalTransactions_CurrencyId",
                table: "ExternalTransactions");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2024, 6, 10, 13, 58, 59, 580, DateTimeKind.Utc).AddTicks(2206));
        }
    }
}

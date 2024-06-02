﻿// <auto-generated />
using System;
using CryptoExchange.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CryptoExchange.Repository.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240602202122_redo-currency")]
    partial class redocurrency
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CryptoExchange.Domain.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFiat")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrencyCode = "EUR",
                            IsFiat = true
                        },
                        new
                        {
                            Id = 2,
                            CurrencyCode = "USD",
                            IsFiat = true
                        });
                });

            modelBuilder.Entity("CryptoExchange.Domain.Models.CurrencyValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("PortfolioId", "CurrencyId")
                        .IsUnique();

                    b.ToTable("CurrencyValue");
                });

            modelBuilder.Entity("CryptoExchange.Domain.Models.ExternalTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Iban")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExternalTransactions");
                });

            modelBuilder.Entity("CryptoExchange.Domain.Models.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("UserId");

                    b.ToTable("Portfolios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrencyId = 1,
                            UserId = 1,
                            Value = 123m
                        });
                });

            modelBuilder.Entity("CryptoExchange.Domain.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal>("TransactionFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WithdrawalCurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal>("WithdrawalFee")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("CryptoExchange.Domain.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ConversionRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SourceCurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal>("SourcePrice")
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("TargetCurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal>("TargetPrice")
                        .HasColumnType("decimal(18,6)");

                    b.Property<DateTime>("TransactionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SourceCurrencyId");

                    b.HasIndex("TargetCurrencyId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConversionRate = 3m,
                            SourceCurrencyId = 1,
                            SourcePrice = 100m,
                            TargetCurrencyId = 2,
                            TargetPrice = 40m,
                            TransactionDate = new DateTime(2024, 6, 2, 20, 21, 21, 945, DateTimeKind.Utc).AddTicks(2316),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("CryptoExchange.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "test address",
                            EmailAddress = "email",
                            FirstName = "FirstName",
                            LastName = "LastName",
                            PasswordHash = new byte[] { 1, 2, 3, 4, 5 },
                            PasswordSalt = new byte[] { 6, 7, 8, 9, 16 },
                            TelephoneNumber = "028172612",
                            Username = "username"
                        });
                });

            modelBuilder.Entity("CryptoExchange.Domain.Models.CurrencyValue", b =>
                {
                    b.HasOne("CryptoExchange.Domain.Models.Currency", "Currency")
                        .WithMany("CurrencyValues")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CryptoExchange.Domain.Models.Portfolio", "Portfolio")
                        .WithMany("CurrencyValues")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("CryptoExchange.Domain.Models.Portfolio", b =>
                {
                    b.HasOne("CryptoExchange.Domain.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoExchange.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CryptoExchange.Domain.Models.Settings", b =>
                {
                    b.HasOne("CryptoExchange.Domain.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("CryptoExchange.Domain.Models.Transaction", b =>
                {
                    b.HasOne("CryptoExchange.Domain.Models.Currency", "SourceCurrency")
                        .WithMany("SourceTransactions")
                        .HasForeignKey("SourceCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoExchange.Domain.Models.Currency", "TargetCurrency")
                        .WithMany("TargetTransactions")
                        .HasForeignKey("TargetCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CryptoExchange.Domain.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SourceCurrency");

                    b.Navigation("TargetCurrency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CryptoExchange.Domain.Models.Currency", b =>
                {
                    b.Navigation("CurrencyValues");

                    b.Navigation("SourceTransactions");

                    b.Navigation("TargetTransactions");
                });

            modelBuilder.Entity("CryptoExchange.Domain.Models.Portfolio", b =>
                {
                    b.Navigation("CurrencyValues");
                });

            modelBuilder.Entity("CryptoExchange.Domain.Models.User", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}

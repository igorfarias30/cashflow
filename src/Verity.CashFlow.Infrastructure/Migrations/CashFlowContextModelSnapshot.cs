﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Verity.CashFlow.Infrastructure.Persistence;

#nullable disable

namespace Verity.CashFlow.Infrastructure.Migrations
{
    [DbContext(typeof(CashFlowContext))]
    partial class CashFlowContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Verity.CashFlow.Domain.Entities.Cash", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("ClosedBalanceInCents")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("DateOfCash")
                        .HasColumnType("date");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("boolean");

                    b.Property<long>("StartBalanceInCents")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Cashes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateOfCash = new DateOnly(2023, 9, 9),
                            IsClosed = false,
                            StartBalanceInCents = 1000000L
                        });
                });

            modelBuilder.Entity("Verity.CashFlow.Domain.Entities.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AmountInCents")
                        .HasColumnType("bigint");

                    b.Property<long>("CashId")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("DateOfTransaction")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CashId");

                    b.ToTable("Transactions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AmountInCents = 1500L,
                            CashId = 1L,
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateOfTransaction = new DateOnly(2023, 9, 9),
                            Description = "2 milks",
                            Status = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 2L,
                            AmountInCents = 5000L,
                            CashId = 1L,
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateOfTransaction = new DateOnly(2023, 9, 9),
                            Description = "10 rice",
                            Status = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 3L,
                            AmountInCents = 3000L,
                            CashId = 1L,
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateOfTransaction = new DateOnly(2023, 9, 9),
                            Description = "20 salt",
                            Status = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 4L,
                            AmountInCents = 2515L,
                            CashId = 1L,
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateOfTransaction = new DateOnly(2023, 9, 9),
                            Description = "1 Kg argentine apple",
                            Status = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 5L,
                            AmountInCents = 65750L,
                            CashId = 1L,
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateOfTransaction = new DateOnly(2023, 9, 9),
                            Description = "15 Kg picanha",
                            Status = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 6L,
                            AmountInCents = 20000L,
                            CashId = 1L,
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateOfTransaction = new DateOnly(2023, 9, 9),
                            Description = "Energy Bill",
                            Status = 0,
                            Type = 1
                        },
                        new
                        {
                            Id = 7L,
                            AmountInCents = 10000L,
                            CashId = 1L,
                            CreatedAt = new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateOfTransaction = new DateOnly(2023, 9, 9),
                            Description = "Water Bill",
                            Status = 0,
                            Type = 1
                        });
                });

            modelBuilder.Entity("Verity.CashFlow.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("Verity.CashFlow.Domain.Entities.Cash", "Cash")
                        .WithMany("Transactions")
                        .HasForeignKey("CashId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cash");
                });

            modelBuilder.Entity("Verity.CashFlow.Domain.Entities.Cash", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}

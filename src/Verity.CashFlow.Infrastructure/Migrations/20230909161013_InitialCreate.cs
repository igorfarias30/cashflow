using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verity.CashFlow.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfTransaction = table.Column<DateOnly>(type: "date", nullable: false),
                    AmountInCents = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AmountInCents", "Comment", "CreatedAt", "DateOfTransaction", "Description", "Status", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("20f2ea13-ebbf-47a9-b2fe-a70da62ce80b"), 1500L, null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "2 milks", 0, 0, null },
                    { new Guid("2bb7425d-6dbd-46f0-a684-c4af23b389d7"), 20000L, null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "Energy Bill", 0, 1, null },
                    { new Guid("4cf56e7a-9319-472c-94f4-4593843b4e41"), 65750L, null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "15 Kg picanha", 0, 0, null },
                    { new Guid("5c9310b6-55cf-4725-9c43-3c44aff14a0b"), 3000L, null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "20 salt", 0, 0, null },
                    { new Guid("ad7a238c-1f2f-4a7a-99de-d02db448c39a"), 2515L, null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "1 Kg argentine apple", 0, 0, null },
                    { new Guid("ef050209-416a-4a1f-bb0a-4f8549f7d0b6"), 10000L, null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "Water Bill", 0, 1, null },
                    { new Guid("f6fd5f54-1b01-4b42-8169-82e13dc606c0"), 5000L, null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "10 rice", 0, 0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}

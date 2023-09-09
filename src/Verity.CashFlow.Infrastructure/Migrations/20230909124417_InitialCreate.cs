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
                    { new Guid("3dee5685-34a5-4c23-8a67-ba0aff22dcf3"), 1500L, null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "2 milks", 0, 0, null },
                    { new Guid("7413e79e-db3a-4e6c-93ee-ed4d62c490b3"), 3000L, null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "20 salt", 0, 0, null },
                    { new Guid("e354c9b9-8746-40f8-b527-c75b75e062da"), 5000L, null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "10 rice", 0, 0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}

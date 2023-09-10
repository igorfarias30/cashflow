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
                name: "Cashes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfCash = table.Column<DateOnly>(type: "date", nullable: false),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: false),
                    StartBalanceInCents = table.Column<long>(type: "bigint", nullable: false),
                    ClosedBalanceInCents = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CashId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Transactions_Cashes_CashId",
                        column: x => x.CashId,
                        principalTable: "Cashes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cashes",
                columns: new[] { "Id", "ClosedBalanceInCents", "CreatedAt", "DateOfCash", "IsClosed", "StartBalanceInCents", "UpdatedAt" },
                values: new object[] { new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), false, 1000000L, null });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AmountInCents", "CashId", "Comment", "CreatedAt", "DateOfTransaction", "Description", "Status", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1dce7743-56ae-4e95-861e-79f49795a48e"), 5000L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "10 rice", 0, 0, null },
                    { new Guid("2e3c9b55-297a-4bbe-90e9-5d2f85d3a93c"), 10000L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "Water Bill", 0, 1, null },
                    { new Guid("47574087-aa72-4f1d-9b75-1bde6ef4e305"), 1500L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "2 milks", 0, 0, null },
                    { new Guid("80584d65-a4aa-4dd5-807a-384b9df3b95a"), 3000L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "20 salt", 0, 0, null },
                    { new Guid("8581bbbe-63f5-4a0f-bb13-f4f2ce44f498"), 20000L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "Energy Bill", 0, 1, null },
                    { new Guid("9519c0a8-c2e2-4978-8cd0-820d74d264e3"), 2515L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "1 Kg argentine apple", 0, 0, null },
                    { new Guid("ddd90310-e54d-4d30-af23-5f21e951db7f"), 65750L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "15 Kg picanha", 0, 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CashId",
                table: "Transactions",
                column: "CashId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Cashes");
        }
    }
}

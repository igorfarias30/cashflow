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
                    { new Guid("025b9bc8-5cce-4a22-98f2-ce6727a0f482"), 5000L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "10 rice", 0, 0, null },
                    { new Guid("45301e31-bed5-4695-87b0-286c2b4b495b"), 1500L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "2 milks", 0, 0, null },
                    { new Guid("732d6158-f1c7-4c12-adcb-9f3fac617fa2"), 3000L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "20 salt", 0, 0, null },
                    { new Guid("936203f8-74dd-42cc-841c-c8ec340e16d9"), 10000L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "Water Bill", 0, 1, null },
                    { new Guid("988a5a5a-06e6-4cf7-b43e-571beb55ed13"), 20000L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "Energy Bill", 0, 1, null },
                    { new Guid("e564b9e8-a62f-42eb-9dfd-c6f25e5e5816"), 65750L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "15 Kg picanha", 0, 0, null },
                    { new Guid("f22c362d-6a21-440a-9cb0-5a1aa63a106e"), 2515L, new Guid("35b5b1cc-56b5-4e61-97d5-12ea4d0f72e5"), null, new DateTimeOffset(new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2023, 9, 9), "1 Kg argentine apple", 0, 0, null }
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

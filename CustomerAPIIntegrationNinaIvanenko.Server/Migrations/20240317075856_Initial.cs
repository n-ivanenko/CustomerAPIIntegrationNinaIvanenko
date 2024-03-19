using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerAPIIntegrationNinaIvanenko.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.CreateTable(
                    name: "Customers",
                    columns: table => new
                    {
                        Id = table.Column<int>(nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Name = table.Column<string>(nullable: true),
                        PhoneNumber = table.Column<string>(nullable: true),
                        Email = table.Column<string>(nullable: true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Customers", x => x.Id);
                    });

            migrationBuilder.CreateTable(
                name: "CallAttempts",
                columns: table => new
                {
                    CallId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallAttempts", x => x.CallId);
                    table.ForeignKey(
                        name: "FK_CallAttempts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallAttempts_CustomerId",
                table: "CallAttempts",
                column: "CustomerId");
                    }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallAttempts");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}

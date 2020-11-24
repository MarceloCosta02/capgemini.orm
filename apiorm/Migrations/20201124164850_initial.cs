using Microsoft.EntityFrameworkCore.Migrations;

namespace apiorm.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "PetShop",
                columns: table => new
                {
                    PetShopId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetShop", x => x.PetShopId);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCane = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    PetshopId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Company_PetShop_PetshopId",
                        column: x => x.PetshopId,
                        principalTable: "PetShop",
                        principalColumn: "PetShopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    PetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PetshopId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.PetId);
                    table.ForeignKey(
                        name: "FK_Pet_PetShop_PetshopId",
                        column: x => x.PetshopId,
                        principalTable: "PetShop",
                        principalColumn: "PetShopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetShopClient",
                columns: table => new
                {
                    PetshopId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetShopClient", x => new { x.ClientId, x.PetshopId });
                    table.ForeignKey(
                        name: "FK_PetShopClient_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetShopClient_PetShop_PetshopId",
                        column: x => x.PetshopId,
                        principalTable: "PetShop",
                        principalColumn: "PetShopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_PetshopId",
                table: "Company",
                column: "PetshopId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pet_PetshopId",
                table: "Pet",
                column: "PetshopId");

            migrationBuilder.CreateIndex(
                name: "IX_PetShopClient_PetshopId",
                table: "PetShopClient",
                column: "PetshopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "PetShopClient");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "PetShop");
        }
    }
}

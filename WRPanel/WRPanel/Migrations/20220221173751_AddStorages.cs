using Microsoft.EntityFrameworkCore.Migrations;

namespace WRPanel.Migrations
{
    public partial class AddStorages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageNum = table.Column<int>(type: "int", nullable: false),
                    PlateNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TireNum = table.Column<int>(type: "int", nullable: false),
                    Rim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RimNum = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storages_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Storages_ClientId",
                table: "Storages",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Storages");
        }
    }
}

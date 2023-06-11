using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternLogAPI.Migrations
{
    public partial class loginit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logs",
                columns: table => new
                {
                    logId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loggInTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loggOutTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    internID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.logId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logs");
        }
    }
}

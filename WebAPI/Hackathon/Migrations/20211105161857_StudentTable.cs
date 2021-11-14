using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.Migrations
{
    public partial class StudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudRollNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudFatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudYearAndBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudDOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudGender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}

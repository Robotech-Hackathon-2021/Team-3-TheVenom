using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.Migrations
{
    public partial class TeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherDegree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherDOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherGender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}

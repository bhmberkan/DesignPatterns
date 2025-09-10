using Microsoft.EntityFrameworkCore.Migrations;

namespace DesignPattern.Decorator.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notifiers",
                columns: table => new
                {
                    NotifierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotifierCreator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotifierSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotifierType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotifierChannel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifiers", x => x.NotifierID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notifiers");
        }
    }
}

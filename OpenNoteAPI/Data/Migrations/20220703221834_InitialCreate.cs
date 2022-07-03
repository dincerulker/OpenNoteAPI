using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenNoteAPI.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "CreatedTime", "ModifiedTime", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quasi, incidunt?", new DateTime(2022, 7, 4, 1, 18, 34, 84, DateTimeKind.Local).AddTicks(4263), new DateTime(2022, 7, 4, 1, 18, 34, 84, DateTimeKind.Local).AddTicks(4273), "Sample Note 1" },
                    { 2, "Odit iure quos quidem voluptate accusamus non officia maiores vero.", new DateTime(2022, 7, 4, 1, 18, 34, 84, DateTimeKind.Local).AddTicks(4276), new DateTime(2022, 7, 4, 1, 18, 34, 84, DateTimeKind.Local).AddTicks(4277), "Sample Note 2" },
                    { 3, "Quos saepe tempora ipsam deserunt corrupti ipsum minima obcaecati minus.", new DateTime(2022, 7, 4, 1, 18, 34, 84, DateTimeKind.Local).AddTicks(4277), new DateTime(2022, 7, 4, 1, 18, 34, 84, DateTimeKind.Local).AddTicks(4278), "Sample Note 3" },
                    { 4, "Possimus mollitia dolore placeat nisi nostrum cumque corrupti iste inventore!", new DateTime(2022, 7, 4, 1, 18, 34, 84, DateTimeKind.Local).AddTicks(4278), new DateTime(2022, 7, 4, 1, 18, 34, 84, DateTimeKind.Local).AddTicks(4279), "Sample Note 4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}

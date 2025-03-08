using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistense.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdenticacionCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Lastnames = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IdTypeIdentification = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", maxLength: 15, nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}

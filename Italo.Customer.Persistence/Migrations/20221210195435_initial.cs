using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Italo.Customer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "corporate");

            migrationBuilder.CreateTable(
                name: "customer",
                schema: "corporate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customertype = table.Column<byte>(name: "customer_type", type: "tinyint", nullable: false),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "datetime2", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "datetime2", nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    modifiedby = table.Column<string>(name: "modified_by", type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer",
                schema: "corporate");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Italo.Customer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "corporate");

            migrationBuilder.CreateTable(
                name: "address",
                schema: "corporate",
                columns: table => new
                {
                    addressid = table.Column<int>(name: "address_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zipcode = table.Column<int>(type: "int", nullable: false),
                    street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    complement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "datetime2", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "datetime2", nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    modifiedby = table.Column<string>(name: "modified_by", type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("address_id", x => x.addressid);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                schema: "corporate",
                columns: table => new
                {
                    customerid = table.Column<int>(name: "customer_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customertype = table.Column<byte>(name: "customer_type", type: "tinyint", nullable: false),
                    addressid = table.Column<int>(name: "address_id", type: "int", nullable: false),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "datetime2", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "datetime2", nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    modifiedby = table.Column<string>(name: "modified_by", type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customer_id", x => x.customerid);
                    table.ForeignKey(
                        name: "FK_customer_address_address_id",
                        column: x => x.addressid,
                        principalSchema: "corporate",
                        principalTable: "address",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_id",
                schema: "corporate",
                table: "customer",
                column: "address_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer",
                schema: "corporate");

            migrationBuilder.DropTable(
                name: "address",
                schema: "corporate");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncidentId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Contacts",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "IncidentName",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentName", "Description" },
                values: new object[,]
                {
                    { "INC001", "Initial Incident 1" },
                    { "INC002", "Initial Incident 2" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "IncidentName", "Name" },
                values: new object[,]
                {
                    { new Guid("0442326b-5e02-4d78-948f-b30e743a9d0e"), "INC001", "Account1" },
                    { new Guid("675895dc-8d7a-485a-9abd-37125a5fa7d2"), "INC002", "Account2" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AccountId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("a47d9a95-ac92-4043-b2e2-a83e92167da4"), new Guid("0442326b-5e02-4d78-948f-b30e743a9d0e"), "john.doe@example.com", "John", "Doe" },
                    { new Guid("ab44f4d8-ffcc-49df-b25e-b6356e3fa1c8"), new Guid("675895dc-8d7a-485a-9abd-37125a5fa7d2"), "jane.doe@example.com", "Jane", "Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("a47d9a95-ac92-4043-b2e2-a83e92167da4"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("ab44f4d8-ffcc-49df-b25e-b6356e3fa1c8"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("0442326b-5e02-4d78-948f-b30e743a9d0e"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("675895dc-8d7a-485a-9abd-37125a5fa7d2"));

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "IncidentName",
                keyValue: "INC001");

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "IncidentName",
                keyValue: "INC002");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Contacts",
                newName: "ContactName");

            migrationBuilder.AlterColumn<string>(
                name: "IncidentName",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IncidentId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

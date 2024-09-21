using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class EnhancementMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("12cd75ac-75cb-484c-a9ab-8475cb25c543"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("89a81881-4eb3-4521-9459-6bed2e60efa8"));

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "IncidentName",
                keyValue: "INC001");

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "IncidentName",
                keyValue: "INC002");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Incidents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IncidentName",
                table: "Incidents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Accounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IncidentName",
                table: "Accounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AccountId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("3536776d-5684-449b-9b77-d9aafa3a77b8"), new Guid("0442326b-5e02-4d78-948f-b30e743a9d0e"), "john.doe@example.com", "John", "Doe" },
                    { new Guid("815ac4bf-9465-41d5-9b55-8290ab2319f3"), new Guid("675895dc-8d7a-485a-9abd-37125a5fa7d2"), "jane.doe@example.com", "Jane", "Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("3536776d-5684-449b-9b77-d9aafa3a77b8"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("815ac4bf-9465-41d5-9b55-8290ab2319f3"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "IncidentName",
                table: "Incidents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "IncidentName",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AccountId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("12cd75ac-75cb-484c-a9ab-8475cb25c543"), new Guid("0442326b-5e02-4d78-948f-b30e743a9d0e"), "john.doe@example.com", "John", "Doe" },
                    { new Guid("89a81881-4eb3-4521-9459-6bed2e60efa8"), new Guid("675895dc-8d7a-485a-9abd-37125a5fa7d2"), "jane.doe@example.com", "Jane", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentName", "Description" },
                values: new object[,]
                {
                    { "INC001", "Initial Incident 1" },
                    { "INC002", "Initial Incident 2" }
                });
        }
    }
}

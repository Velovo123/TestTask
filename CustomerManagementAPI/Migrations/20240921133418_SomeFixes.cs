using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class SomeFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("a47d9a95-ac92-4043-b2e2-a83e92167da4"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("ab44f4d8-ffcc-49df-b25e-b6356e3fa1c8"));

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AccountId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("60b380d5-ce16-498d-88e6-52b564d4ffb9"), new Guid("675895dc-8d7a-485a-9abd-37125a5fa7d2"), "jane.doe@example.com", "Jane", "Doe" },
                    { new Guid("857bb6a9-3f52-47e3-b9e4-01e036cbe828"), new Guid("0442326b-5e02-4d78-948f-b30e743a9d0e"), "john.doe@example.com", "John", "Doe" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts",
                column: "IncidentName",
                principalTable: "Incidents",
                principalColumn: "IncidentName",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("60b380d5-ce16-498d-88e6-52b564d4ffb9"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("857bb6a9-3f52-47e3-b9e4-01e036cbe828"));

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AccountId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("a47d9a95-ac92-4043-b2e2-a83e92167da4"), new Guid("0442326b-5e02-4d78-948f-b30e743a9d0e"), "john.doe@example.com", "John", "Doe" },
                    { new Guid("ab44f4d8-ffcc-49df-b25e-b6356e3fa1c8"), new Guid("675895dc-8d7a-485a-9abd-37125a5fa7d2"), "jane.doe@example.com", "Jane", "Doe" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts",
                column: "IncidentName",
                principalTable: "Incidents",
                principalColumn: "IncidentName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Accounts_AccountId",
                table: "Contacts");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("60b380d5-ce16-498d-88e6-52b564d4ffb9"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("857bb6a9-3f52-47e3-b9e4-01e036cbe828"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AccountId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("12cd75ac-75cb-484c-a9ab-8475cb25c543"), new Guid("0442326b-5e02-4d78-948f-b30e743a9d0e"), "john.doe@example.com", "John", "Doe" },
                    { new Guid("89a81881-4eb3-4521-9459-6bed2e60efa8"), new Guid("675895dc-8d7a-485a-9abd-37125a5fa7d2"), "jane.doe@example.com", "Jane", "Doe" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts",
                column: "IncidentName",
                principalTable: "Incidents",
                principalColumn: "IncidentName",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Accounts_AccountId",
                table: "Contacts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Accounts_AccountId",
                table: "Contacts");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("12cd75ac-75cb-484c-a9ab-8475cb25c543"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("89a81881-4eb3-4521-9459-6bed2e60efa8"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Accounts_AccountId",
                table: "Contacts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

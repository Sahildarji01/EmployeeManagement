using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstWebApi.Migrations
{
    /// <inheritdoc />
    public partial class changeinemployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserAuth_EmployeeId",
                table: "UserAuth");

            migrationBuilder.DropColumn(
                name: "Dob",
                table: "Employee_details");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Employee_details",
                newName: "PhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employee_details",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoiningDate",
                table: "Employee_details",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Employee_details",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "JobTitleId",
                table: "Employee_details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserAuth_EmployeeId",
                table: "UserAuth",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserAuth_EmployeeId",
                table: "UserAuth");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Employee_details");

            migrationBuilder.DropColumn(
                name: "JobTitleId",
                table: "Employee_details");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Employee_details",
                newName: "phoneNumber");

            migrationBuilder.AlterColumn<int>(
                name: "phoneNumber",
                table: "Employee_details",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "JoiningDate",
                table: "Employee_details",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Dob",
                table: "Employee_details",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_UserAuth_EmployeeId",
                table: "UserAuth",
                column: "EmployeeId");
        }
    }
}

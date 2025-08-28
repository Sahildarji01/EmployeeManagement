using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstWebApi.Migrations
{
    /// <inheritdoc />
    public partial class changeInLeaveDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApplyOn",
                table: "Leave_Details",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Leave_Details",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedOn",
                table: "Leave_Details",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplyOn",
                table: "Leave_Details");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Leave_Details");

            migrationBuilder.DropColumn(
                name: "ApprovedOn",
                table: "Leave_Details");
        }
    }
}

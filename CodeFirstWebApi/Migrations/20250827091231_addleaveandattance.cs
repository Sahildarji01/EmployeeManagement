using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addleaveandattance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attandance_Details",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckInDateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDateAndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attandance_Details", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attandance_Details_Employee_details_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee_details",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leave_Details",
                columns: table => new
                {
                    LeaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveType = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave_Details", x => x.LeaveId);
                    table.ForeignKey(
                        name: "FK_Leave_Details_Employee_details_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee_details",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attandance_Details_EmployeeId",
                table: "Attandance_Details",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_Details_EmployeeId",
                table: "Leave_Details",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attandance_Details");

            migrationBuilder.DropTable(
                name: "Leave_Details");
        }
    }
}

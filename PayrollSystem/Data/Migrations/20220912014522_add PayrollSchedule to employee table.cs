using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollSystem.Data.Migrations
{
    public partial class addPayrollScheduletoemployeetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayrollSchedule",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayrollSchedule",
                table: "Employees");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingLeaveAllocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveAllocation",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "LeaveTypeId", "NumberOfDays", "Period" },
                values: new object[] { 1, "09f5a295-7712-4a27-a929-edb6e41ebe05", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09f5a295-7712-4a27-a929-edb6e41ebe05", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveAllocation",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

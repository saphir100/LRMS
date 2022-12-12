using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingLeaveRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveRequest",
                columns: new[] { "Id", "Approved", "Cancelled", "CreatedBy", "DateActioned", "DateCreated", "DateRequested", "EndDate", "LastModifiedBy", "LastModifiedDate", "LeaveTypeId", "RequestComments", "StartDate" },
                values: new object[,]
                {
                    { 1, false, false, "09f5a295-7712-4a27-a929-edb6e41ebe05", new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "09f5a295-7712-4a27-a929-edb6e41ebe05", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "busy", new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, false, false, "09f5a295-7712-4a27-a929-edb6e41ebe05", new DateTime(2022, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "09f5a295-7712-4a27-a929-edb6e41ebe05", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "busy", new DateTime(2022, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveRequest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveRequest",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

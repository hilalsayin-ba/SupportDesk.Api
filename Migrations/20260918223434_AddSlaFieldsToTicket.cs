using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupportDesk.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSlaFieldsToTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_tickets_customer_id",
                table: "tickets",
                newName: "IX_Tickets_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_assigned_staff_id",
                table: "tickets",
                newName: "IX_Tickets_AssignedStaffId");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_comments_ticket_id",
                table: "ticket_comments",
                newName: "IX_TicketComments_TicketId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "sla_deadline",
                table: "tickets",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tickets",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSlaBreached",
                table: "tickets",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ticket_comments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tickets");

            migrationBuilder.DropColumn(
                name: "IsSlaBreached",
                table: "tickets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ticket_comments");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_CustomerId",
                table: "tickets",
                newName: "IX_tickets_customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_AssignedStaffId",
                table: "tickets",
                newName: "IX_tickets_assigned_staff_id");

            migrationBuilder.RenameIndex(
                name: "IX_TicketComments_TicketId",
                table: "ticket_comments",
                newName: "IX_ticket_comments_ticket_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "sla_deadline",
                table: "tickets",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}

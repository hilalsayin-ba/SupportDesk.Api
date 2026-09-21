using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupportDesk.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyIdAndTableFormatting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slas",
                table: "Slas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketMessages",
                table: "TicketMessages");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "tickets");

            migrationBuilder.RenameTable(
                name: "Slas",
                newName: "slas");

            migrationBuilder.RenameTable(
                name: "TicketMessages",
                newName: "ticket_messages");

            migrationBuilder.RenameColumn(
                name: "SlaId",
                table: "tickets",
                newName: "CompanyId");

            migrationBuilder.AddColumn<int>(
                name: "AssignedSlaId",
                table: "tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedAt",
                table: "tickets",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "tickets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tickets",
                table: "tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_slas",
                table: "slas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ticket_messages",
                table: "ticket_messages",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tickets",
                table: "tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_slas",
                table: "slas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ticket_messages",
                table: "ticket_messages");

            migrationBuilder.DropColumn(
                name: "AssignedSlaId",
                table: "tickets");

            migrationBuilder.DropColumn(
                name: "ClosedAt",
                table: "tickets");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "tickets");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "tickets",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "slas",
                newName: "Slas");

            migrationBuilder.RenameTable(
                name: "ticket_messages",
                newName: "TicketMessages");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Tickets",
                newName: "SlaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slas",
                table: "Slas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketMessages",
                table: "TicketMessages",
                column: "Id");
        }
    }
}

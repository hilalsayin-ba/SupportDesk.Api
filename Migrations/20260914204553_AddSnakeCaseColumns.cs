using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupportDesk.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSnakeCaseColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_comments_tickets_TicketId",
                table: "ticket_comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_comments_users_UserId",
                table: "ticket_comments");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_categories_CategoryId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_companies_CompanyId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_users_AssignedStaffId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_users_CustomerId",
                table: "tickets");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "tickets",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tickets",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "tickets",
                newName: "priority");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "tickets",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tickets",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TicketCode",
                table: "tickets",
                newName: "ticket_code");

            migrationBuilder.RenameColumn(
                name: "SlaDeadline",
                table: "tickets",
                newName: "sla_deadline");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "tickets",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "tickets",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "tickets",
                newName: "company_id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "tickets",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "AssignedStaffId",
                table: "tickets",
                newName: "assigned_staff_id");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_CustomerId",
                table: "tickets",
                newName: "IX_tickets_customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_CompanyId",
                table: "tickets",
                newName: "IX_tickets_company_id");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_CategoryId",
                table: "tickets",
                newName: "IX_tickets_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_AssignedStaffId",
                table: "tickets",
                newName: "IX_tickets_assigned_staff_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ticket_comments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ticket_comments",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "ticket_comments",
                newName: "ticket_id");

            migrationBuilder.RenameColumn(
                name: "IsInternal",
                table: "ticket_comments",
                newName: "is_internal");

            migrationBuilder.RenameColumn(
                name: "CommentText",
                table: "ticket_comments",
                newName: "comment_text");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_comments_UserId",
                table: "ticket_comments",
                newName: "IX_ticket_comments_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_comments_TicketId",
                table: "ticket_comments",
                newName: "IX_ticket_comments_ticket_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SlaHours",
                table: "categories",
                newName: "sla_hours");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_comments_tickets_ticket_id",
                table: "ticket_comments",
                column: "ticket_id",
                principalTable: "tickets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_comments_users_user_id",
                table: "ticket_comments",
                column: "user_id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_categories_category_id",
                table: "tickets",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_companies_company_id",
                table: "tickets",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_users_assigned_staff_id",
                table: "tickets",
                column: "assigned_staff_id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_users_customer_id",
                table: "tickets",
                column: "customer_id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_comments_tickets_ticket_id",
                table: "ticket_comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_comments_users_user_id",
                table: "ticket_comments");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_categories_category_id",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_companies_company_id",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_users_assigned_staff_id",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_users_customer_id",
                table: "tickets");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "tickets",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "tickets",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "priority",
                table: "tickets",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "tickets",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tickets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ticket_code",
                table: "tickets",
                newName: "TicketCode");

            migrationBuilder.RenameColumn(
                name: "sla_deadline",
                table: "tickets",
                newName: "SlaDeadline");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "tickets",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "tickets",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "tickets",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "tickets",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "assigned_staff_id",
                table: "tickets",
                newName: "AssignedStaffId");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_customer_id",
                table: "tickets",
                newName: "IX_tickets_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_company_id",
                table: "tickets",
                newName: "IX_tickets_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_category_id",
                table: "tickets",
                newName: "IX_tickets_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_assigned_staff_id",
                table: "tickets",
                newName: "IX_tickets_AssignedStaffId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ticket_comments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ticket_comments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ticket_id",
                table: "ticket_comments",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "is_internal",
                table: "ticket_comments",
                newName: "IsInternal");

            migrationBuilder.RenameColumn(
                name: "comment_text",
                table: "ticket_comments",
                newName: "CommentText");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_comments_user_id",
                table: "ticket_comments",
                newName: "IX_ticket_comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_comments_ticket_id",
                table: "ticket_comments",
                newName: "IX_ticket_comments_TicketId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sla_hours",
                table: "categories",
                newName: "SlaHours");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_comments_tickets_TicketId",
                table: "ticket_comments",
                column: "TicketId",
                principalTable: "tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_comments_users_UserId",
                table: "ticket_comments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_categories_CategoryId",
                table: "tickets",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_companies_CompanyId",
                table: "tickets",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_users_AssignedStaffId",
                table: "tickets",
                column: "AssignedStaffId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_users_CustomerId",
                table: "tickets",
                column: "CustomerId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

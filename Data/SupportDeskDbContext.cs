using Microsoft.EntityFrameworkCore;
using SupportDesk.Api.Models;

namespace SupportDesk.Api.Data;

public class SupportDeskDbContext : DbContext
{
    public SupportDeskDbContext(DbContextOptions<SupportDeskDbContext> options) : base(options) { }

    public DbSet<Company> Companies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketComment> TicketComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Tablo İsimleri (snake_case)
        modelBuilder.Entity<Company>().ToTable("companies");
        modelBuilder.Entity<User>().ToTable("users");
        
        modelBuilder.Entity<Category>(entity => {
            entity.ToTable("categories");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.SlaHours).HasColumnName("sla_hours");
        });

        modelBuilder.Entity<Ticket>(entity => {
            entity.ToTable("tickets");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TicketCode).HasColumnName("ticket_code");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.AssignedStaffId).HasColumnName("assigned_staff_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.SlaDeadline).HasColumnName("sla_deadline");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
        });

        modelBuilder.Entity<TicketComment>(entity => {
            entity.ToTable("ticket_comments");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CommentText).HasColumnName("comment_text");
            entity.Property(e => e.IsInternal).HasColumnName("is_internal");
        });

        // Çakışmayı önleyen silme kuralları
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Customer)
            .WithMany(u => u.CustomerTickets)
            .HasForeignKey(t => t.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.AssignedStaff)
            .WithMany(u => u.AssignedTickets)
            .HasForeignKey(t => t.AssignedStaffId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
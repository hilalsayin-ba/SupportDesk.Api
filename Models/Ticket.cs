using System.ComponentModel.DataAnnotations;

namespace SupportDesk.Api.Models;
public class Ticket
{
    public int Id { get; set; }
    public string TicketCode { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public User Customer { get; set; } = null!;
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public int? AssignedStaffId { get; set; }
    public User? AssignedStaff { get; set; }
    public string Status { get; set; } = "Yeni";
    public string Priority { get; set; } = "Orta";
    public DateTime SlaDeadline { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();


[Timestamp]
public DateTime RowVersion { get; set; }
}
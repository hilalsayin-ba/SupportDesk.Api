using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportDesk.Api.Data;
using SupportDesk.Api.DTOs;
using SupportDesk.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace SupportDesk.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly SupportDeskDbContext _context;

    public TicketsController(SupportDeskDbContext context)
    {
        _context = context;
    }

    // GET: api/tickets
    [HttpGet]
    public async Task<IActionResult> GetTickets()
    {
        var tickets = await _context.Tickets
            .Include(t => t.Company)
            .Include(t => t.Customer)
            .Include(t => t.Category)
            .Include(t => t.AssignedStaff)
            .ToListAsync();
            
        return Ok(tickets);
    }

    // POST: api/tickets (SLA Hesaplamalı Talep Oluşturma)
    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDto dto)
    {
        var category = await _context.Categories.FindAsync(dto.CategoryId);
        int slaHours = category?.SlaHours ?? 24;

        var ticket = new Ticket
        {
            TicketCode = $"TCK-{DateTime.UtcNow:yyyyMMdd}-{new Random().Next(1000, 9999)}",
            Title = dto.Title,
            Description = dto.Description,
            CustomerId = dto.CustomerId,
            CompanyId = dto.CompanyId,
            CategoryId = dto.CategoryId,
            Priority = dto.Priority,
            Status = "Yeni",
            SlaDeadline = DateTime.UtcNow.AddHours(slaHours),
            CreatedAt = DateTime.UtcNow,
            RowVersion = DateTime.UtcNow,
        };

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();

        return Ok(ticket);
    }

    // PUT: api/tickets/{id}/assign (Personele Atama)
    [HttpPut("{id}/assign")]
    public async Task<IActionResult> AssignTicket(int id, [FromBody] int staffId)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null) return NotFound(new { message = "Talep bulunamadı." });

        ticket.AssignedStaffId = staffId;
        if (ticket.Status == "Yeni") ticket.Status = "İşlemde";
        
        try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        return Conflict("Bu talep başka bir kullanıcı tarafından güncellendi. Lütfen sayfayı yenileyip tekrar deneyin.");
    }
        return Ok(ticket);
    }

   // PUT: api/tickets/{id}/status (Durum Güncelleme)
[HttpPut("{id}/status")]
public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateTicketStatusDto dto)
{
    var ticket = await _context.Tickets.FindAsync(id);
    if (ticket == null) return NotFound();

    // EF Core'a orijinal rowVersion değerini bildiriyoruz
    _context.Entry(ticket).Property(t => t.RowVersion).OriginalValue = dto.RowVersion;

    ticket.Status = dto.Status;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        return Conflict(new { message = "Concurrency conflict detected." });
    }

    return Ok(ticket);
}
}
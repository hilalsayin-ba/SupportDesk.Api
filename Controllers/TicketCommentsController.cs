using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportDesk.Api.Data;
using SupportDesk.Api.Models;

namespace SupportDesk.Api.Controllers
{
    [Route("api/tickets/{ticketId}/comments")]
    [ApiController]
    public class TicketCommentsController : ControllerBase
    {
        private readonly SupportDeskDbContext _context;

        public TicketCommentsController(SupportDeskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketComment>>> GetComments(int ticketId)
        {
            return await _context.TicketComments
                .Include(c => c.User)
                .Where(c => c.TicketId == ticketId)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TicketComment>> AddComment(int ticketId, [FromBody] CreateCommentDto dto)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null) return NotFound("Talep bulunamadı.");

            var comment = new TicketComment
            {
                TicketId = ticketId,
                UserId = dto.UserId,
                CommentText = dto.CommentText,
                IsInternal = dto.IsInternal
            };

            _context.TicketComments.Add(comment);
            await _context.SaveChangesAsync();

            return Ok(comment);
        }
    }

    public class CreateCommentDto
    {
        public int UserId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public bool IsInternal { get; set; } = false;
    }
}
using System.ComponentModel.DataAnnotations;

namespace SupportDesk.Api.DTOs;

public class UpdateTicketStatusDto
{
    [Required(ErrorMessage = "Durum alanı zorunludur.")]
    [StringLength(50, ErrorMessage = "Durum en fazla 50 karakter olabilir.")]
    public string Status { get; set; } = null!;

    [Required(ErrorMessage = "Versiyon bilgisi (RowVersion) zorunludur.")]
    public DateTime RowVersion { get; set; }
}
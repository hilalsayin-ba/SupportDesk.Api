using System.ComponentModel.DataAnnotations;

namespace SupportDesk.Api.DTOs;

public class CreateTicketDto
{
    [Required(ErrorMessage = "Başlık zorunludur.")]
    [StringLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir.")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Açıklama zorunludur.")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Şirket seçimi zorunludur.")]
    public int CompanyId { get; set; }

    [Required(ErrorMessage = "Müşteri seçimi zorunludur.")]
    public int CustomerId { get; set; }

    public string Priority { get; set; } = "Orta";
}
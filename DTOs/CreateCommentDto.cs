using System.ComponentModel.DataAnnotations;

namespace SupportDesk.Api.DTOs;

public class CreateCommentDto
{
    [Required(ErrorMessage = "Yorum içeriği boş olamaz.")]
    [StringLength(1000, ErrorMessage = "Yorum en fazla 1000 karakter olabilir.")]
    public string CommentText { get; set; } = null!;

    [Required(ErrorMessage = "Kullanıcı seçimi zorunludur.")]
    public int UserId { get; set; }
}
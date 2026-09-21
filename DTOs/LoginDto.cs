namespace SupportDesk.Api.DTOs
{
    /// <summary>
    /// Kullanıcı giriş (Login) işlemleri için veri transfer nesnesidir (DTO).
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// Kullanıcının sisteme kayıtlı e-posta adresi.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Kullanıcının düz metin (plain-text) şifresi.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class UserAddModel
    {
        [Required(ErrorMessage ="Email Boş Geçilemez.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez.")]
        public string Password { get; set; }
        public bool Status { get; set; }
        public bool IsAdmin { get; set; }
    }
}

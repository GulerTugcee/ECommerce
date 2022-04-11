using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class AdminLoginModel
    {
        [Required(ErrorMessage = "Email Boş Bırakılamaz."), MaxLength(100, ErrorMessage = "Email Fazla Uzun Max : 100")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Hatalı Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Boş Bırakılamaz."), MaxLength(25, ErrorMessage = "Şifre Fazla Uzun Max : 25")]
        public string Password { get; set; }
    }
}

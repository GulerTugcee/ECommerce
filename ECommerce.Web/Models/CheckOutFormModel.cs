using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models
{
    public class CheckOutFormModel
    {
        [Required(ErrorMessage = "İsim Giriniz")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad Giriniz")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon Giriniz")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Adres Giriniz")]
        public string Address { get; set; }
        public string City { get; set; }
    }
}

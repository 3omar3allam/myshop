using System.ComponentModel.DataAnnotations;

namespace MyShop.Web.Models
{
    public class RegisterCustomerVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string DisplayName { get; set; }
    }
}

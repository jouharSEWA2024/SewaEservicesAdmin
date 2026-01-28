using System.ComponentModel.DataAnnotations;

namespace SEWAEContractorAdmin.Models
{
    public class AdminLoginViewModel : ErrorViewModel
    {
        [Required(ErrorMessage = "Please enter UserName")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
    }
}

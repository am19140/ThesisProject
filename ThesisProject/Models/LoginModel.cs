using System.ComponentModel.DataAnnotations;

namespace ThesisProject.Models
{
    public class LoginModel
    {
        [Required]
        public string? username { get; set; }

        [Required]
        public string? password { get; set; }

        public bool isLoginConfirmed { get; set; } = true;
    }
}

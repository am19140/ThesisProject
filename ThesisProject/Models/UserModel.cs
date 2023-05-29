using System.ComponentModel.DataAnnotations;


namespace ThesisProject.Models
{
    public class UserModel
    {
        [Required]
        [Key]
        public string username { get; set; }
        [Required]
        [MinLength(6,ErrorMessage ="Password should contain more than 6 characters.")]
        public string password { get; set; }
        [Required]
        public string firstname { get; set; }
        
        [Required]
        public string lastname { get; set; }

        public string? profileImage { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$", ErrorMessage = "Insert a valid email address")]

        public string email { get; set; }

        [Required]
        public string gender { get; set; }

    }
}

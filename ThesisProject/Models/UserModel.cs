using System.ComponentModel.DataAnnotations;


namespace ThesisProject.Models
{
    public class UserModel
    {
        [Required]
        [Key]
        public string Username { get; set; }
        [Required]
        [MinLength(6,ErrorMessage ="Password should contain more than 6 characters.")]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }

        public string ProfileImage { get; set; }

    }
}

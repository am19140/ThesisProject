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

        public string profileImage { get; set; }

    }
}

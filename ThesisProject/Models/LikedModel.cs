using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThesisProject.Models
{
    public class LikedModel
    {
        [Key]
        [NotMapped]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int SongId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThesisProject.Models
{
    public class LikedModel
    {
        [Key]
        [NotMapped]
        public int id { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public int songId { get; set; }
    }
}

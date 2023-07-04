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
        [ForeignKey("username")]
        public string username { get; set; }

        [Required]
        [ForeignKey("songId")]

        public int songId { get; set; }
    }
}

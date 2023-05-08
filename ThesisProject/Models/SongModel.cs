using System.ComponentModel.DataAnnotations;

namespace ThesisProject.Models
{
    public class SongModel
    {
        [Required]
        [Key]
        public int SongId { get; set; }

        [Required]
        public string SongName { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public string Mood { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string SongFile { get; set; }
    }
}

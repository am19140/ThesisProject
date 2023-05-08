using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThesisProject.Models
{
    public class HistoryModel
    {
        [Key]
        [NotMapped]
        public int Id { get; set; }
        public string Username { get; set; }
        public int SongId { get; set; }

        public int TimesListened { get; set; }

    }
}

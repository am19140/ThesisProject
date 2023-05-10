using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThesisProject.Models
{
    public class HistoryModel
    {
        [Key]
        [NotMapped]
        public int id { get; set; }
        public string username { get; set; }
        public int songId { get; set; }

        public int timesListened { get; set; }

    }
}

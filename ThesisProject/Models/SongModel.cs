﻿using System.ComponentModel.DataAnnotations;

namespace ThesisProject.Models
{
    public class SongModel
    {
        [Required]
        [Key]
        public int songId { get; set; }

        [Required]
        public string songname { get; set; }

        [Required]
        public string duration { get; set; }

        [Required]
        public string artist { get; set; }

        [Required]
        public string mood { get; set; }

        [Required]
        public string genre { get; set; }

        [Required]
        public string songfile { get; set; }
    }
}

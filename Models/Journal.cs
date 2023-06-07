using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptureJournal.Models
{
    public class Journal
    {

        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Book { get; set; }

        public int Chapter { get; set; }
        public int Verse { get; set; }

        [StringLength(500, MinimumLength = 0)]
        [Required]
        public string? Comments { get; set; }

        [Display(Name= "Entry Date")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}
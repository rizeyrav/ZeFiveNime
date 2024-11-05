using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZeFiveNime.Models
{
    public class Source{
        [Key]
        public int Id_Source { get; set; }
        [Display(Name = "Source")]
        public required string Name_Source {get; set;}
        public string? SourceOne { get; set; }
        public string? SourceTwo { get; set; }
        public string? SourceThree { get; set; }
        public Episode? Episode { get; set; }
        public int Episode_Source { get; set; }
    }
}
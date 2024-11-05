using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZeFiveNime.Models
{
    public class Animation{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public required string Judul { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy}",ApplyFormatInEditMode = true)]
        public DateTime Tahun { get; set; }
        public required string Sinopsis { get; set; }
        [NotMapped]
        public required IFormFile PosterImage { get; set; }
        public required byte[] PosterByte { get; set; }
        public ICollection<Episode>? Episodes { get; set; }
        [NotMapped]
        public int Jumlah_Episode => Episodes?.Count ?? 0;

        
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZeFiveNime.Models
{
    public class Episode{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Episode { get; set; }
        [Display(Name = "Episode")]
        public required string Judul_Episode { get; set; }
        [Range(1,24)]
        public required int Durasi { get; set; }
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Upload")]
        public DateTime UploadTime { get; set; }

        public required Animation Animation { get; set; }
        [ForeignKey("Animation")]
        public required int Id_Animation { get; set; }
        public ICollection<Source>? Sources { get; set; }
    }
}
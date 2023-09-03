using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AnimalApi.Models
{
    public class Comment
    {
        [Key]
        [Display(Name = "Comment Id")]

        [Required]
        public int CommentId { get; set; }

        [Required]
        [ForeignKey("AnimalId")]
        [Display(Name = "Animal Id")]


        public virtual Animal? Animal { get; set; }
        public int AnimalId { get; set; }

        [Required]
        [Display(Name = "Comment")]
        [Column(TypeName = "nvarchar")]
        [MinLength(1, ErrorMessage = "Please Don't enter empty commetns!")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public required string Note { get; set; }
    }
}

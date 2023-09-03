using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AnimalApi.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }


        [Required(ErrorMessage = "Please enter a name")]

        public required string Name { get; set; }



        [Required(ErrorMessage = "Please Enter Age")]
        [Range(1, 100, ErrorMessage = "Age Should Be Between 1-100")] // Oldest Age Is turtle
        public required int Age { get; set; }

        [Required(ErrorMessage = "No file selected")]
        [Display(Name = "Picture Name")]


        public required string PictureName { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        [Column(TypeName = "nvarchar")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000)]
        public required string Description { get; set; }



        public virtual Category? Category { get; set; }

        [Required(ErrorMessage = "Please choose category")]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public virtual ICollection<Comment>? Comment { get; set; }
    }
}

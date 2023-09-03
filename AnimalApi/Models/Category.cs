using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnimalApi.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "nchar")]
        [StringLength(40)]
        public required string Name { get; set; }

        public virtual ICollection<Animal>? Animals { get; set; }
    }
}

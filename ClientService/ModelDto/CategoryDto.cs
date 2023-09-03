using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.ModelDto
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<AnimalDto>? Animals { get; set; }
    }
}

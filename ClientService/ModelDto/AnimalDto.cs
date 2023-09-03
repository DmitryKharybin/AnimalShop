using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClientService.ModelDto
{
    public class AnimalDto
    {
        public int AnimalId { get; set; }
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string PictureName { get; set; }
        public required string Description { get; set; }
        public virtual CategoryDto? Category { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<CommentDto>? Comment { get; set; }
    }
}

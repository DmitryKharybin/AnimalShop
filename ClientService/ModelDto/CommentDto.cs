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
    public class CommentDto
    {
        public int CommentId { get; set; }
        public virtual AnimalDto? Animal { get; set; }
        public int AnimalId { get; set; }
        public required string Note { get; set; }
    }
}

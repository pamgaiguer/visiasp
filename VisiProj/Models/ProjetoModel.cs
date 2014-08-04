using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VisiProj.Models
{
    public class ProjetoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Column(TypeName="Date")]
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public string Area { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? Updatedat { get; set; }
        public bool Deleted { get; set; }
    }
}
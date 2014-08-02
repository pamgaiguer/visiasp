using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisiProj.Models
{
    public class ProjetoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public string Area { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Updatedat { get; set; }
    }
}
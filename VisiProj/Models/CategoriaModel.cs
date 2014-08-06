using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisiProj.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public virtual ICollection<ProjetoModel> Projetos { get; set; }
        public string Nome { get; set; }
    }
}
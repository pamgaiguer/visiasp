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
        public virtual CategoriaModel Categoria { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public string Area { get; set; }
        public virtual ICollection<ImagemProjetoModel> Imagens { get; set; }
        public bool Deleted { get; set; }
    }
}
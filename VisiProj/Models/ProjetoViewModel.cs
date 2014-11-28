using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisiProj.Models
{
    public class IndexViewModel
    {
        public List<CategoriaModel> Categorias { get; set; }

        public List<ProjetoModel> Projetos { get; set; }
        
        public List<ImagemProjetoModel> Imagens { get; set; }

        public int? ProjetoId { get; set; }

        public int? CategoriaId { get; set; }

        public IndexViewModel()
        {
            Categorias = new List<CategoriaModel>();
            Projetos = new List<ProjetoModel>();
            Imagens = new List<ImagemProjetoModel>();
        }
    }
}
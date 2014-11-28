using System;

namespace VisiProj.Models
{
    public class ImagemProjetoModel
    {
        public int Id { get; set; }

        public virtual ProjetoModel Projeto { get; set; }

        public string UrlNormal { get; set; }

        public string UrlMiniatura { get; set; }

        public TipoImagem Tipo { get; set; }

        public ImagemProjetoModel()
        {

        }
    }
}


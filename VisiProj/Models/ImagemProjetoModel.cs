using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisiProj.Models
{
    public class ImagemProjetoModel
    {
        public int Id { get; set; }

        public virtual ProjetoModel Projeto { get; set; }

        public string UrlNormal { get; set; }

        public string UrlMiniatura { get; set; }

        public TipoImagem? TipoImagem { get; set; }

        public ImagemProjetoModel()
        {

        }
    }
}


using System;

namespace VisiProj.Models
{
    public class ImagemProjetoModel
    {
        public int Id { get; set; }

        public virtual ProjetoModel Projeto { get; set; }

        public string UrlNormal
        {
            get;
            set;
        }

        public string UrlPequena
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }

        public string Local
        {
            get;
            set;
        }

        public string Classificadores
        {
            get;
            set;
        }

        public ImagemProjetoModel()
        {

        }
    }
}


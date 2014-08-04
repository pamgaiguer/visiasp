using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VisiProj.Models
{
    public class VisiContext : DbContext
    {
        public virtual DbSet<ProjetoModel> Projetos { get; set; }
        public virtual DbSet<ImagemProjetoModel> ImagemProjetos { get; set; }

        public VisiContext()
            : base("Name=VisiProd")
        {

        }
    }
}
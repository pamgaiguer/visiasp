namespace VisiProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipIntoProjetoAndImagemProjeto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImagemProjetoModels", "Projeto_Id", c => c.Int());
            CreateIndex("dbo.ImagemProjetoModels", "Projeto_Id");
            AddForeignKey("dbo.ImagemProjetoModels", "Projeto_Id", "dbo.ProjetoModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImagemProjetoModels", "Projeto_Id", "dbo.ProjetoModels");
            DropIndex("dbo.ImagemProjetoModels", new[] { "Projeto_Id" });
            DropColumn("dbo.ImagemProjetoModels", "Projeto_Id");
        }
    }
}

namespace VisiProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoriaIdToProjetoModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjetoModels", "Categoria_Id", "dbo.CategoriaModels");
            DropIndex("dbo.ProjetoModels", new[] { "Categoria_Id" });
            AlterColumn("dbo.ProjetoModels", "Categoria_Id", c => c.Int());
            CreateIndex("dbo.ProjetoModels", "Categoria_Id");
            AddForeignKey("dbo.ProjetoModels", "Categoria_Id", "dbo.CategoriaModels", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjetoModels", "Categoria_Id", "dbo.CategoriaModels");
            DropIndex("dbo.ProjetoModels", new[] { "Categoria_Id" });
            AlterColumn("dbo.ProjetoModels", "Categoria_Id", c => c.Int());
            CreateIndex("dbo.ProjetoModels", "Categoria_Id");
            AddForeignKey("dbo.ProjetoModels", "Categoria_Id", "dbo.CategoriaModels", "Id");
        }
    }
}

namespace VisiProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbAdjust : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriaModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ImagemProjetoModels", "UrlMiniatura", c => c.String());
            AddColumn("dbo.ProjetoModels", "Categoria_Id", c => c.Int());
            CreateIndex("dbo.ProjetoModels", "Categoria_Id");
            AddForeignKey("dbo.ProjetoModels", "Categoria_Id", "dbo.CategoriaModels", "Id");
            DropColumn("dbo.ImagemProjetoModels", "UrlPequena");
            DropColumn("dbo.ImagemProjetoModels", "Nome");
            DropColumn("dbo.ImagemProjetoModels", "Local");
            DropColumn("dbo.ImagemProjetoModels", "Classificadores");
            DropColumn("dbo.ProjetoModels", "Data");
            DropColumn("dbo.ProjetoModels", "CreatedAt");
            DropColumn("dbo.ProjetoModels", "Updatedat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjetoModels", "Updatedat", c => c.DateTime());
            AddColumn("dbo.ProjetoModels", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjetoModels", "Data", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.ImagemProjetoModels", "Classificadores", c => c.String());
            AddColumn("dbo.ImagemProjetoModels", "Local", c => c.String());
            AddColumn("dbo.ImagemProjetoModels", "Nome", c => c.String());
            AddColumn("dbo.ImagemProjetoModels", "UrlPequena", c => c.String());
            DropForeignKey("dbo.ProjetoModels", "Categoria_Id", "dbo.CategoriaModels");
            DropIndex("dbo.ProjetoModels", new[] { "Categoria_Id" });
            DropColumn("dbo.ProjetoModels", "Categoria_Id");
            DropColumn("dbo.ImagemProjetoModels", "UrlMiniatura");
            DropTable("dbo.CategoriaModels");
        }
    }
}

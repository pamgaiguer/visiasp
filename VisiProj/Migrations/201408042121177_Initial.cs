namespace VisiProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImagemProjetoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrlNormal = c.String(),
                        UrlPequena = c.String(),
                        Nome = c.String(),
                        Local = c.String(),
                        Classificadores = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjetoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Data = c.DateTime(nullable: false),
                        Local = c.String(),
                        Area = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        Updatedat = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProjetoModels");
            DropTable("dbo.ImagemProjetoModels");
        }
    }
}

namespace VisiProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnTipoImagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImagemProjetoModels", "TipoImagem", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImagemProjetoModels", "TipoImagem");
        }
    }
}

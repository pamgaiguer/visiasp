namespace VisiProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTipo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImagemProjetoModels", "Tipo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImagemProjetoModels", "Tipo");
        }
    }
}

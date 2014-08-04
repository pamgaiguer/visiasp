namespace VisiProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedFieltToProjetoModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjetoModels", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjetoModels", "Deleted");
        }
    }
}

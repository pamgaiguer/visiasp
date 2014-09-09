namespace VisiProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjetoModels", "Data", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjetoModels", "Data");
        }
    }
}

namespace VisiProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAtNotRequiredInProjetoModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjetoModels", "Updatedat", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjetoModels", "Updatedat", c => c.DateTime(nullable: false));
        }
    }
}

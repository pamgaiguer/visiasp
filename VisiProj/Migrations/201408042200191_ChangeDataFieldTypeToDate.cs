namespace VisiProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataFieldTypeToDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjetoModels", "Data", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjetoModels", "Data", c => c.DateTime(nullable: false));
        }
    }
}

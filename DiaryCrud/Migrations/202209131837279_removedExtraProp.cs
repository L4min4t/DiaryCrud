namespace DiaryCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedExtraProp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Records", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Records", "MyProperty", c => c.Int(nullable: false));
        }
    }
}

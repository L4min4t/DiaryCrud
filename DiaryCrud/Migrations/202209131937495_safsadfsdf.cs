namespace DiaryCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class safsadfsdf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Records", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Records", "UserId", c => c.Int(nullable: false));
        }
    }
}

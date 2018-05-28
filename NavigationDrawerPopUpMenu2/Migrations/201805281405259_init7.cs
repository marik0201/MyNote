namespace MyNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Archives", "Text", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Notes", "Text", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "Text", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Archives", "Text", c => c.String(nullable: false, maxLength: 50));
        }
    }
}

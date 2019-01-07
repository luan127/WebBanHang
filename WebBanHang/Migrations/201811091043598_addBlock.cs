namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBlock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Block", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Block");
        }
    }
}

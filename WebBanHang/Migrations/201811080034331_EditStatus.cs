namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Status", c => c.Int());
        }
    }
}

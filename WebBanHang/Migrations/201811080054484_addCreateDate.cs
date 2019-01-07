namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCreateDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "CreateDate", c => c.DateTime());
            DropColumn("dbo.Product", "IsNew");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "IsNew", c => c.Boolean(nullable: false));
            DropColumn("dbo.Product", "CreateDate");
        }
    }
}

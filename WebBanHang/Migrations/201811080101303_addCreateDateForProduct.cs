namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCreateDateForProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "CreateDate", c => c.DateTime());
        }
    }
}

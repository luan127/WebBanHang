namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Vote = c.Int(),
                        UserID = c.Long(),
                        ProductID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Code = c.String(maxLength: 10),
                        MetaTitle = c.String(nullable: false, maxLength: 250),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Detail = c.String(nullable: false),
                        IsHot = c.Boolean(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        Status = c.Int(),
                        ProducerID = c.Long(),
                        ProductCategoryID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Producer", t => t.ProducerID)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryID)
                .Index(t => t.ProducerID)
                .Index(t => t.ProductCategoryID);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Src = c.String(nullable: false, maxLength: 500),
                        ProductID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        ProductID = c.Long(nullable: false),
                        OrderID = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(),
                        SubPrice = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.ProductID, t.OrderID })
                .ForeignKey("dbo.Order", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(),
                        ShipName = c.String(nullable: false, maxLength: 60),
                        ShipPhone = c.String(nullable: false, maxLength: 20),
                        ShipAddress = c.String(nullable: false, maxLength: 500),
                        ShipCreateDate = c.DateTime(nullable: false),
                        ShipEmail = c.String(nullable: false, maxLength: 50),
                        Status = c.Int(),
                        TotalPrice = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Avatar = c.String(maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 50),
                        Genre = c.String(maxLength: 5),
                        BirthDay = c.DateTime(nullable: false, storeType: "date"),
                        Phone = c.String(nullable: false, maxLength: 50),
                        CreateDate = c.DateTime(nullable: false),
                        Permission = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Producer",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ProductID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.FeedBack",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        phone = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 250),
                        Content = c.String(nullable: false, maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NewsCategory",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        MetaTitle = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Content = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        MetaTitle = c.String(nullable: false, maxLength: 250),
                        NewsCategory_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NewsCategory", t => t.NewsCategory_ID)
                .Index(t => t.NewsCategory_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "NewsCategory_ID", "dbo.NewsCategory");
            DropForeignKey("dbo.Sales", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductCategoryID", "dbo.ProductCategory");
            DropForeignKey("dbo.Product", "ProducerID", "dbo.Producer");
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Order", "UserID", "dbo.User");
            DropForeignKey("dbo.Comment", "UserID", "dbo.User");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Image", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Comment", "ProductID", "dbo.Product");
            DropIndex("dbo.News", new[] { "NewsCategory_ID" });
            DropIndex("dbo.Sales", new[] { "ProductID" });
            DropIndex("dbo.Order", new[] { "UserID" });
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.Image", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "ProductCategoryID" });
            DropIndex("dbo.Product", new[] { "ProducerID" });
            DropIndex("dbo.Comment", new[] { "ProductID" });
            DropIndex("dbo.Comment", new[] { "UserID" });
            DropTable("dbo.News");
            DropTable("dbo.NewsCategory");
            DropTable("dbo.FeedBack");
            DropTable("dbo.Sales");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Producer");
            DropTable("dbo.User");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Image");
            DropTable("dbo.Product");
            DropTable("dbo.Comment");
        }
    }
}

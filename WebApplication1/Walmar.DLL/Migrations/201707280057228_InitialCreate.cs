namespace Walmar.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GoodsReviews",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ReviewIdWalmar = c.String(),
                        ReviewText = c.String(),
                        GoodId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.GoodId, cascadeDelete: true)
                .Index(t => t.GoodId);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.String(),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoodsReviews", "GoodId", "dbo.Goods");
            DropIndex("dbo.GoodsReviews", new[] { "GoodId" });
            DropTable("dbo.Goods");
            DropTable("dbo.GoodsReviews");
        }
    }
}

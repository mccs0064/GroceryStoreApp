namespace Grocery.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Name = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                        ItemListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemLists", t => t.ItemListId, cascadeDelete: true)
                .Index(t => t.ItemListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ItemListId", "dbo.ItemLists");
            DropIndex("dbo.Items", new[] { "ItemListId" });
            DropTable("dbo.Items");
            DropTable("dbo.ItemLists");
        }
    }
}

namespace BillTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillModels",
                c => new
                    {
                        BillId = c.Int(nullable: false, identity: true),
                        BillName = c.String(),
                        BillCompany = c.String(),
                        BillDate = c.String(),
                        BillPrice = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BillId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillModels", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.BillModels", new[] { "UserId" });
            DropTable("dbo.BillModels");
        }
    }
}

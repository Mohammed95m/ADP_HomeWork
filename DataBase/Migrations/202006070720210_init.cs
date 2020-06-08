namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityID = c.Int(nullable: false),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageID, cascadeDelete: true)
                .Index(t => t.CityID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Title = c.String(),
                        Abstract = c.String(),
                        Text = c.String(),
                        ImagePath = c.String(),
                        TotalReads = c.Int(nullable: false),
                        AgencyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Agencies", t => t.AgencyID, cascadeDelete: true)
                .Index(t => t.AgencyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "AgencyID", "dbo.Agencies");
            DropForeignKey("dbo.Agencies", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.Agencies", "CityID", "dbo.Cities");
            DropIndex("dbo.News", new[] { "AgencyID" });
            DropIndex("dbo.Agencies", new[] { "LanguageID" });
            DropIndex("dbo.Agencies", new[] { "CityID" });
            DropTable("dbo.News");
            DropTable("dbo.Languages");
            DropTable("dbo.Cities");
            DropTable("dbo.Agencies");
        }
    }
}

namespace Web_Ankh_Mork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assasins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        HighestReward = c.Int(nullable: false),
                        LowestReward = c.Int(nullable: false),
                        IsOcupied = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Beggars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeggarType = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        AmountOfMoney = c.Double(nullable: false),
                        Replic = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Fools",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FoolType = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Salary = c.Double(nullable: false),
                        Replic = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Thiefs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Fee = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Thiefs");
            DropTable("dbo.Fools");
            DropTable("dbo.Beggars");
            DropTable("dbo.Assasins");
        }
    }
}

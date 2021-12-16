namespace Web_Ankh_Mork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ver1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Beggars", "Replic", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Beggars", "Replic", c => c.String(nullable: false));
        }
    }
}

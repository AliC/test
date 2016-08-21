namespace PostcodeEditor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tweaks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostcodeDetails", "Region", c => c.String());
            AlterColumn("dbo.PostcodeDetails", "Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.PostcodeDetails", "Longitude", c => c.Double(nullable: false));
            DropColumn("dbo.PostcodeDetails", "CountryRegion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostcodeDetails", "CountryRegion", c => c.String());
            AlterColumn("dbo.PostcodeDetails", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PostcodeDetails", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.PostcodeDetails", "Region");
        }
    }
}

namespace PostcodeEditor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCountryRegionproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostcodeDetails", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PostcodeDetails", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PostcodeDetails", "County", c => c.String());
            AddColumn("dbo.PostcodeDetails", "District", c => c.String());
            AddColumn("dbo.PostcodeDetails", "Ward", c => c.String());
            AddColumn("dbo.PostcodeDetails", "CountryRegion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostcodeDetails", "CountryRegion");
            DropColumn("dbo.PostcodeDetails", "Ward");
            DropColumn("dbo.PostcodeDetails", "District");
            DropColumn("dbo.PostcodeDetails", "County");
            DropColumn("dbo.PostcodeDetails", "Longitude");
            DropColumn("dbo.PostcodeDetails", "Latitude");
        }
    }
}

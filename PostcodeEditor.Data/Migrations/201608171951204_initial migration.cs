namespace PostcodeEditor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostcodeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Postcode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostcodeDetails");
        }
    }
}

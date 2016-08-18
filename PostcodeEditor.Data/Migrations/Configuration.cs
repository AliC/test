namespace PostcodeEditor.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Repositories;

    internal sealed class Configuration : DbMigrationsConfiguration<PostcodeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PostcodeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Postcodes.AddOrUpdate(p => p.Postcode, new PostcodeDetails
            {
                Postcode = "QV1 1IJ",
                CountryRegion = "From EF Seed"
            });
        }
    }
}

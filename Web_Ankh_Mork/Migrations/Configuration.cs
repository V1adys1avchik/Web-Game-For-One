namespace Web_Ankh_Mork.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Web_Ankh_Mork.DB.AnkhMorokContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Web_Ankh_Mork.DB.AnkhMorokContext";
        }

        protected override void Seed(Web_Ankh_Mork.DB.AnkhMorokContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

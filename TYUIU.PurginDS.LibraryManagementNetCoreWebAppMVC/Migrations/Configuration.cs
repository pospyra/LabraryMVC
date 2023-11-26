namespace TYUIU.PurginDS.LibraryManagementNetCoreWebAppMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TYUIU.PurginDS.LibraryManagementNetCoreWebAppMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TYUIU.PurginDS.LibraryManagementNetCoreWebAppMVC.Models.ApplicationDbContext";
        }

        protected override void Seed(TYUIU.PurginDS.LibraryManagementNetCoreWebAppMVC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

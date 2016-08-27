namespace Gamersfable_prototype.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gamersfable_prototype.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Gamersfable_prototype.Models.ApplicationDbContext context)
        {
            if (context.Users.Any() == false)
            {
            }
        }
    }
}

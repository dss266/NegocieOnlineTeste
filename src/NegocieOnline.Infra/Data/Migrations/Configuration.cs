namespace NegocieOnline.Infra.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NegocieOnline.Infra.Data.NegocieOnlineDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


    }
}

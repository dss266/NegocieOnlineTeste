using System.Data.Entity.Migrations;

namespace NegocieOnline.Infra.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<NegocieOnline.Infra.Data.NegocieOnlineDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


    }
}

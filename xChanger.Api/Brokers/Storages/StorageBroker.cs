using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace xChanger.Core.POC.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-CNTLCPV;Initial Catalog=xChangerDBCore;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}

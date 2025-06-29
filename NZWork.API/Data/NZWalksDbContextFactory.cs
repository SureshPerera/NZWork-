using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NZWork.API.Data;

namespace NZWork.API
{
    public class NZWalksDbContextFactory : IDesignTimeDbContextFactory<NZWalksDbContext>
    {
        public NZWalksDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NZWalksDbContext>();

            // ✅ Use your real dev connection string here
            var connectionString = "Server=SURESH;Database=NZWolksDb;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);

            return new NZWalksDbContext(optionsBuilder.Options);
        }
    }
}

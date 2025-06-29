using Microsoft.EntityFrameworkCore;
using NZWork.API.Model.Domain;

namespace NZWork.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions options)
    : base(options)
        {
        }
        public DbSet<Difficulty> Difficulties{ get; set; }
        public DbSet<Region> Regions{ get; set; }
        public DbSet<Work> Works{ get; set; }
    }
}

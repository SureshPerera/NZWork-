using Microsoft.EntityFrameworkCore;
using NZWork.API.Data;
using NZWork.API.Model.Domain;

namespace NZWork.API.Repositories
{
    public class SqlRegionRepository : IRegionsRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SqlRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var exsistingRegions = await dbContext.Regions.FirstOrDefaultAsync(a=>a.Id == id);
            if(exsistingRegions == null) {return null;}
            dbContext.Regions.Remove(exsistingRegions);
            await dbContext.SaveChangesAsync();
            return exsistingRegions;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetItemById(Guid id)
        {
            var domainRegion = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (domainRegion == null) { return null; }
            return domainRegion;

        }

        public async Task<Region> UpdateAsync(Region region, Guid id)
        {
            var exsistingRegion = await dbContext.Regions.FirstOrDefaultAsync(a => a.Id == id);
            if (exsistingRegion == null)
            {
                return null;
            }
            exsistingRegion.Code = region.Code;
            exsistingRegion.Name = region.Name;
            exsistingRegion.RegionImgUrl = region.RegionImgUrl;

            await dbContext.SaveChangesAsync();
            return exsistingRegion;
        }
    }
}

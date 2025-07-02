using NZWork.API.Model.Domain;

namespace NZWork.API.Repositories
{
    public class MemoryRegionRepository : IRegionsRepository
    {
        public Task<Region?> CreateAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>
            {
                new Region
                {
                    Code ="GDA12",
                    Name = "Gunapala"
                }
            };
        }

        public Task<Region?> GetItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> UpdateAsync(Region region, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

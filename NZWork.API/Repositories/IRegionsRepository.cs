using NZWork.API.Model.Domain;

namespace NZWork.API.Repositories
{
    public interface IRegionsRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetItemById(Guid id);
        Task<Region?> CreateAsync(Region region);
       
        Task<Region?> UpdateAsync(Region region,Guid id);
        Task<Region?> DeleteAsync(Guid id);
    }
}

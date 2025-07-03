using NZWork.API.Model.Domain;

namespace NZWork.API.Repositories
{
    public interface IWorkRepository 
    {
       Task<Work> CreateAsync(Work work);
    }
}

using NZWork.API.Data;
using NZWork.API.Model.Domain;

namespace NZWork.API.Repositories
{
    public class SqlWorksRepository : IWorkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SqlWorksRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Work> CreateAsync(Work work)
        {
            await dbContext.Works.AddAsync(work);
            await dbContext.SaveChangesAsync();

            return work; 
        }
    }
}

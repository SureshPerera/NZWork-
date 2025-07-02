using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWork.API.Data;

namespace NZWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WorkController(NZWalksDbContext nZWalksDbContext) {
            this.nZWalksDbContext = nZWalksDbContext;
        }
        
        
    }
}

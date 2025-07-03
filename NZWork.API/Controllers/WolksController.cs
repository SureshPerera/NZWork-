using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWork.API.Model.Domain;
using NZWork.API.Model.DTO;
using NZWork.API.Repositories;

namespace NZWork.API.Controllers
{   // / / api/wolks
    [Route("api/[controller]")]
    [ApiController]
    public class WolksController : ControllerBase
    {
       
        private readonly IWorkRepository workRepository;

        public WolksController( IWorkRepository workRepository)
        {
            
            this.workRepository = workRepository;
        }
        //create walk
        //Post: localHost//api/wolks/
        [HttpPost]
       
        public async Task<IActionResult> Create([FromBody] AddworkRequistDto addworkRequistDto)
        {
            
            //Map dto to domain model
            var WolksDOmainModel = new Work
            {
                
                    Name = addworkRequistDto.Name,
                    Description = addworkRequistDto.Description,
                    LengthInKm = addworkRequistDto.LengthInKm,
                    WalkImgUrl = addworkRequistDto.WalkImgUrl

           
            };
            await workRepository.CreateAsync(WolksDOmainModel);
            //Map Domain model to DTO
            var WolkDto = new WolksDto
            {
                Id = WolksDOmainModel.Id,
                Name = WolksDOmainModel.Name,
                Description = WolksDOmainModel.Description,
                LengthInKm = WolksDOmainModel.LengthInKm,
                WalkImgUrl = WolksDOmainModel.WalkImgUrl
            };

            return Ok(WolkDto);
        }
    }
}

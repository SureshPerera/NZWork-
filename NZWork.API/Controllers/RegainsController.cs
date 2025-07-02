using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWork.API.Data;
using NZWork.API.Model.Domain;
using NZWork.API.Model.DTO;
using NZWork.API.Repositories;

namespace NZWork.API.Controllers
{
    //http:localahost:1235/api/Regains
    [Route("api/[controller]")]
    [ApiController]
    public class RegainsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionsRepository regionsRepository;

        public RegainsController(NZWalksDbContext dbContext , IRegionsRepository regionsRepository)
        {
            this.dbContext = dbContext;
            this.regionsRepository = regionsRepository;
        }
        //GET:http:localahost:1235/api/Regains
        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            //get data into database 
            var regionDomainModel = await regionsRepository.GetAllAsync();
            //convert models to DTO
            var regionDto = new List<RegionDto>();
            foreach (var item in regionDomainModel)
            {
                regionDto.Add(new RegionDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code,
                    RegionImgUrl = item.RegionImgUrl
                });
            }
            //return DTO 
            return Ok(regionDto);
        }
        //GET:http:localahost:1235/api/Regains/{id}

        [HttpGet]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetDataById([FromRoute] Guid Id) {
            //var regions = dbContext.Regions.Find(id);
            var regions = await regionsRepository.GetItemById(Id);
            if (regions == null) {
                return NotFound();
            }
            return Ok(regions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateData([FromBody] AddRegionRequistDto addRegionRequistDto)
        {
            //Map or convert DTO to domain model
            var regionsDomainModel = new Region
            {
                Code = addRegionRequistDto.Code,
                Name = addRegionRequistDto.Name,
                RegionImgUrl = addRegionRequistDto.RegionImgUrl
            };
            //Use domain model to create regain
            await regionsRepository.CreateAsync(regionsDomainModel);
            

            //Map domain model back to Dto
            var regainDto = new RegionDto
            {
                Id = regionsDomainModel.Id,
                Name = regionsDomainModel.Name,
                Code = regionsDomainModel.Code,
                RegionImgUrl = regionsDomainModel.RegionImgUrl
            };
            return CreatedAtAction(nameof(GetDataById), new { id = regainDto.Id }, regainDto);
        }
        //Update the regions 
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegions([FromRoute] Guid id, [FromBody] UpdateRegionRequist updateRegionRequist)
        {
            //map Dto to domain model
            var regionDomainModel = new Region
            {
                Code = updateRegionRequist.Code,
                Name = updateRegionRequist.Name,
                RegionImgUrl = updateRegionRequist.RegionImgUrl,
            };
            // check Is have or not region
           regionDomainModel = await regionsRepository.UpdateAsync(regionDomainModel ,id );
           

            

            return Ok(regionDomainModel);
        }
        [HttpDelete]
        [Route("{Id:guid}")]
        public async Task<IActionResult> DeleteRegions( [FromForm] Guid Id)
        {
            //check if Id is valied or not 
            //var regionsDomain = regionsRepository.DeleteAsync(Id);
            //if(regionsDomain == null)
            //{
            //    return NotFound();
            //}
            //regionsDomain.Start();
            //delete regions
            var exsistingRegion = await  dbContext.Regions.FirstOrDefaultAsync(a=>a.Id == Id);
            dbContext.Regions.Remove(exsistingRegion);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

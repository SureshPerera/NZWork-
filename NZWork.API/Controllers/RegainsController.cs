using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWork.API.Data;
using NZWork.API.Model.Domain;
using NZWork.API.Model.DTO;

namespace NZWork.API.Controllers
{
    //http:localahost:1235/api/Regains
    [Route("api/[controller]")]
    [ApiController]
    public class RegainsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegainsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //GET:http:localahost:1235/api/Regains
        [HttpGet]
        public IActionResult GetAllData()
        {
            //get data into database 
            var regionDomainModel = dbContext.Regions.ToList();
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
        public IActionResult GetDataById([FromRoute] Guid Id) {
            //var regions = dbContext.Regions.Find(id);
            var regions = dbContext.Regions.SingleOrDefault(r => r.Id == Id);
            if (regions == null) {
                return NotFound();
            }
            return Ok(regions);
        }

        [HttpPost]
        public IActionResult CreateData([FromBody] AddRegionRequistDto addRegionRequistDto)
        {
            //Map or convert DTO to domain model

            var regionsDomainModel = new Region
            {
                Code = addRegionRequistDto.Code,
                Name = addRegionRequistDto.Name,
                RegionImgUrl = addRegionRequistDto.RegionImgUrl
            };
            //Use domain model to create regain
            dbContext.Regions.Add(regionsDomainModel);
            dbContext.SaveChanges();
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
        public IActionResult UpdateRegions([FromRoute] Guid id, [FromBody] UpdateRegionRequist updateRegionRequist)
        {
            // check Is have or not region
            var RegionDomainModel = dbContext.Regions.FirstOrDefault(r => r.Id == id);
            if(RegionDomainModel == null)
            {   
                return NotFound();
            }

            //Map Dto to Domain Model
            RegionDomainModel.Code = updateRegionRequist.Code;
            RegionDomainModel.Name = updateRegionRequist.Name;
            RegionDomainModel.RegionImgUrl = updateRegionRequist.RegionImgUrl;

            dbContext.SaveChanges();

            //Map domain back to DTO
            var regionDto = new RegionDto
            {
                Id = RegionDomainModel.Id,
                Name = RegionDomainModel.Name,
                Code = RegionDomainModel.Code,
                RegionImgUrl = RegionDomainModel.RegionImgUrl
            };

            return Ok(regionDto);
        }
    }
}

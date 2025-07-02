using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWork.API.Data;
using NZWork.API.Model.Domain;
using NZWork.API.Model.DTO;

namespace NZWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficaltyController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public DifficaltyController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            //get all data
            var DifficalityDomainModel = dbContext.Difficulties.ToList();

            //convert or Map domain model to DTO
            var DifficalityDto = new List<DifficaltyDto>();
            foreach (var item in DifficalityDomainModel)
            {
                DifficalityDto.Add(new DifficaltyDto
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return Ok(DifficalityDto);
        }
        [HttpPost]
        public IActionResult Create([FromBody] AddDifficalityDto addDifficalityDto)
        {
            //convert DTO to domain model
            var DifficalityDomainModel = new Difficulty
            {
                Name = addDifficalityDto.Name
            };
            //use domain model to create Difficality
            dbContext.Difficulties.Add(DifficalityDomainModel);
            dbContext.SaveChanges();
            return Ok(DifficalityDomainModel);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update([FromRoute]Guid id, [FromBody] UpdateDifficalityRequist updateDifficalityRequist)
        {
            //check Id is valied or not
            var DifficalityDomainModel = dbContext.Difficulties.FirstOrDefault(x => x.Id == id);
            if(DifficalityDomainModel == null)
            {
               return NotFound();
            }
            //convert or map domain model to DTO
            DifficalityDomainModel.Name = updateDifficalityRequist.Name;
            dbContext.SaveChangesAsync();
            //Map domain back to dto
            var DifficalityDto = new DifficaltyDto
            {
                Id = DifficalityDomainModel.Id,
                Name = DifficalityDomainModel.Name
            };

            return Ok(DifficalityDto);

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute]Guid id)
        {
            //check if Id is valied
            var DifficalityDomainModel = dbContext.Difficulties.FirstOrDefault(a => a.Id == id);
            if(DifficalityDomainModel == null) { return NotFound(); }
            dbContext.Remove(DifficalityDomainModel);
            dbContext.SaveChangesAsync();

            var DifficalityDto = new DifficaltyDto
            {
                Id = DifficalityDomainModel.Id,
                Name = DifficalityDomainModel.Name
            };

            return Ok(DifficalityDto);
        }
        //[HttpDelete]
        //[Route("{name:string}")]
        //public IActionResult DeleteByName([FromRoute] string name)
        //{
        //    var DifficalityDomainModel = dbContext.Difficulties.FirstOrDefault(b => b.Name == name);
        //    if(DifficalityDomainModel == null) { return NotFound(); }
        //    dbContext.Difficulties.Remove(DifficalityDomainModel);
        //    dbContext.SaveChangesAsync();

        //    var DifficalityDto = new DifficaltyDto
        //    {
        //        Id = DifficalityDomainModel.Id,
        //        Name = DifficalityDomainModel.Name
        //    };
        //    return Ok(DifficalityDto);
        //}
    }
}

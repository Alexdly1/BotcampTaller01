using Jazani.Application.Ges.Dtos.Periodtypes;
using Jazani.Application.Ges.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Mcs
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodtypeController : ControllerBase
    {
        private readonly IPeriodtypeService _periodtypeService;

        public PeriodtypeController(IPeriodtypeService periodtypeService)
        {
            _periodtypeService = periodtypeService;
        }

        // GET: api/<PeriodtypeController>
        [HttpGet]
        public async Task<IEnumerable<PeriodtypeDto>> Get()
        {
            return await _periodtypeService.FindAllAsync();
        }

        // GET api/<PeriodtypeController>/5
        [HttpGet("{id}")]
        public async Task<PeriodtypeDto> Get(int id)
        {
            return await _periodtypeService.FindByIdAsync(id);
        }

        // POST api/<PeriodtypeController>
        [HttpPost]
        public async Task<PeriodtypeDto> Post([FromBody] PeriodtypeSaveDto periodtypeSaveDto)
        {
            return await _periodtypeService.CreateAsync(periodtypeSaveDto);
        }

        // PUT api/<PeriodtypeController>/5
        [HttpPut("{id}")]
        public async Task<PeriodtypeDto> Put(int id, [FromBody] PeriodtypeSaveDto periodtypeSaveDto)
        {
            return await _periodtypeService.EditAsync(id, periodtypeSaveDto);
        }

        // DELETE api/<PeriodtypeController>/5
        [HttpDelete("{id}")]
        public async Task<PeriodtypeDto> Delete(int id)
        {
            return await _periodtypeService.DisabledAsync(id);
        }
    }
}

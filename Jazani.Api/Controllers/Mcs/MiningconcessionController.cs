using Jazani.Application.Mcs.Dtos.Miningconcessions;
using Jazani.Application.Mcs.Services;
using Jazani.Application.Mcs.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Mcs
{
    [Route("api/[controller]")]
    //[ApiController]
    public class MiningconcessionController : ControllerBase
    {
        private readonly IMiningconcessionService _miningconcessionService;

        public MiningconcessionController(IMiningconcessionService miningconcessionService)
        {
            _miningconcessionService = miningconcessionService;
        }



        // GET: api/<MiningconcessionController>
        [HttpGet]
        public async Task<IEnumerable<MiningconcessionDto>> Get()
        {
            return await _miningconcessionService.FindAllAsync();
        }

        // GET api/<MiningconcessionController>/5
        [HttpGet("{id}")]
        public async Task<MiningconcessionDto> Get(int id)
        {
            return await _miningconcessionService.FindByIdAsync(id);
        }

        // POST api/<MiningconcessionController>
        [HttpPost]
        public async Task<MiningconcessionDto> Post([FromBody] MiningconcessionSaveDto saveDto)
        {
            return await _miningconcessionService.CreateAsync(saveDto);
        }

        // PUT api/<MiningconcessionController>/5
        [HttpPut("{id}")]
        public async Task<MiningconcessionDto> Put(int id, [FromBody] MiningconcessionSaveDto saveDto)
        {
            return await _miningconcessionService.EditAsync(id, saveDto);
        }

        // DELETE api/<MiningconcessionController>/5
        [HttpDelete("{id}")]
        public async Task<MiningconcessionDto> Delete(int id)
        {
            return await _miningconcessionService.DisabledAsync(id);
        }
    }
}

using Jazani.Application.Mcs.Dtos.Investmenttypes;
using Jazani.Application.Mcs.Services;
using Jazani.Application.Mcs.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Mcs
{
    [Route("api/[controller]")]
    //[ApiController]
    public class InvestmenttypeController : ControllerBase
    {
        private readonly IInvestmenttypeService _investmenttypeService;

        public InvestmenttypeController(IInvestmenttypeService investmenttypeService)
        {
            _investmenttypeService = investmenttypeService;
        }

        // GET: api/<InvestmenttypeController>
        [HttpGet]
        public async Task<IEnumerable<InvestmenttypeDto>> Get()
        {
            return await _investmenttypeService.FindAllAsync();
        }

        // GET api/<InvestmenttypeController>/5
        [HttpGet("{id}")]
        public async Task<InvestmenttypeDto> Get(int id)
        {
            return await _investmenttypeService.FindByIdAsync(id);
        }

        // POST api/<InvestmenttypeController>
        [HttpPost]
        public async Task<InvestmenttypeDto> Post([FromBody] InvestmenttypeSaveDto investmenttypeSaveDto)
        {
            return await _investmenttypeService.CreateAsync(investmenttypeSaveDto);
        }

    // PUT api/<InvestmenttypeController>/5
    [HttpPut("{id}")]
        public async Task<InvestmenttypeDto> Put(int id, [FromBody] InvestmenttypeSaveDto investmenttypeSaveDto)
        {
            return await _investmenttypeService.EditAsync(id, investmenttypeSaveDto);
        }

        // DELETE api/<InvestmenttypeController>/5
        [HttpDelete("{id}")]
        public async Task<InvestmenttypeDto> Delete(int id)
        {
            return await _investmenttypeService.DisabledAsync(id);
        }
    }
}

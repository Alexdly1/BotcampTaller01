using Jazani.Application.Mcs.Dtos.Investmentconcepts;
using Jazani.Application.Mcs.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Mcs
{
    [Route("api/[controller]")]
    //[ApiController]
    public class InvestmentconceptController : ControllerBase
    {
        private readonly IInvestmentconceptService _investmentconceptService;

        public InvestmentconceptController(IInvestmentconceptService investmentconceptService)
        {
            _investmentconceptService = investmentconceptService;
        }

        // GET: api/<InvestmentconceptController>
        [HttpGet]
        public async Task<IEnumerable<InvestmentconceptDto>> Get()
        {
            return await _investmentconceptService.FindAllAsync();
        }

        // GET api/<InvestmentconceptController>/5
        [HttpGet("{id}")]
        public async Task<InvestmentconceptDto> Get(int id)
        {
            return await _investmentconceptService.FindByIdAsync(id);
        }

        // POST api/<InvestmentconceptController>
        [HttpPost]
        public async Task<InvestmentconceptDto> Post([FromBody] InvestmentconceptSaveDto investmentconceptSaveDto)
        {
            return await _investmentconceptService.CreateAsync(investmentconceptSaveDto);
        }

        // PUT api/<InvestmentconceptController>/5
        [HttpPut("{id}")]
        public async Task<InvestmentconceptDto> Put(int id, [FromBody] InvestmentconceptSaveDto investmentconceptSaveDto)
        {
            return await _investmentconceptService.EditAsync(id, investmentconceptSaveDto);
        }

        // DELETE api/<InvestmentconceptController>/5
        [HttpDelete("{id}")]
        public async Task<InvestmentconceptDto> Delete(int id)
        {
            return await _investmentconceptService.DisabledAsync(id);
        }
    }
}

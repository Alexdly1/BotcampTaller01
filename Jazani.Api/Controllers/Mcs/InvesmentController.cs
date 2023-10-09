using Jazani.Application.Mcs.Dtos.Investments;
using Jazani.Application.Mcs.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Mcs
{
    [Route("api/[controller]")]
    //[ApiController]
    public class InvesmentController : ControllerBase
    {
        private readonly IInvesmentService _invesmentService;

        public InvesmentController(IInvesmentService invesmentService)
        {
            _invesmentService = invesmentService;
        }

        // GET: api/<InvesmentController>
        [HttpGet]
        public async Task<IEnumerable<InvestmentDto>> Get()
        {
            return await _invesmentService.FindAllAsync();
        }

        // GET api/<InvesmentController>/5
        [HttpGet("{id}")]
        public async Task<InvestmentDto> Get(int id)
        {
            return await _invesmentService.FindByIdAsync(id);
        }

        // POST api/<InvesmentController>
        [HttpPost]
        public async Task<InvestmentDto> Post([FromBody] InvestmentSaveDto saveDto)
        {
            return await _invesmentService.CreateAsync(saveDto);
        }

        // PUT api/<InvesmentController>/5
        [HttpPut("{id}")]
        public async Task<InvestmentDto> Put(int id, [FromBody] InvestmentSaveDto saveDto)
        {
            return await _invesmentService.EditAsync(id, saveDto);
        }

        // DELETE api/<InvesmentController>/5
        [HttpDelete("{id}")]
        public async Task<InvestmentDto> Delete(int id)
        {
            return await _invesmentService.DisabledAsync(id);
        }
    }
}

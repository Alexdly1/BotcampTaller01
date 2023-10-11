using Jazani.Application.Mcs.Dtos.Investments;
using Jazani.Application.Mcs.Services;
using Microsoft.AspNetCore.Mvc;
using Jazani.Api.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Jazani.Application.Mcs.Services.Implementations;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmentDto>>> Get(int id)
        {
            var response = await _invesmentService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/<InvesmentController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentDto>>> Post([FromBody] InvestmentSaveDto saveDto)
        {
            var response = await _invesmentService.CreateAsync(saveDto);
            return TypedResults.CreatedAtRoute(response);
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

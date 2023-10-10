using Jazani.Application.Ges.Dtos.Measureunits;
using Jazani.Application.Ges.Services;
using Jazani.Application.Mcs.Dtos.Investmentconcepts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Mcs
{
    [Route("api/[controller]")]
    //[ApiController]
    public class MeasureunitController : ControllerBase
    {
        private readonly IMeasureunitService _measureunitService;

        public MeasureunitController(IMeasureunitService measureunitService)
        {
            _measureunitService = measureunitService;
        }

        // GET: api/<MeasureunitController>
        [HttpGet]
        public async Task<IEnumerable<MeasureunitDto>> Get()
        {
            return await _measureunitService.FindAllAsync();
        }

        // GET api/<MeasureunitController>/5
        [HttpGet("{id}")]
        public async Task<MeasureunitDto> Get(int id)
        {
            return await _measureunitService.FindByIdAsync(id);
        }

        // POST api/<MeasureunitController>
        [HttpPost]
        public async Task<MeasureunitDto> Post([FromBody] MeasureunitSaveDto measureunitSaveDto)
        {
            return await _measureunitService.CreateAsync(measureunitSaveDto);
        }

        // PUT api/<MeasureunitController>/5
        [HttpPut("{id}")]
        public async Task<MeasureunitDto> Put(int id, [FromBody] MeasureunitSaveDto measureunitSaveDto)
        {
            return await _measureunitService.EditAsync(id, measureunitSaveDto);
        }

        // DELETE api/<MeasureunitController>/5
        [HttpDelete("{id}")]
        public async Task<MeasureunitDto> Delete(int id)
        {
            return await _measureunitService.DisabledAsync(id);
        }
    }
}

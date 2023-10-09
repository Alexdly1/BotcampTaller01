using Jazani.Application.Socs.Dtos.Holders;
using Jazani.Application.Socs.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Socs
{
    [Route("api/[controller]")]
    //[ApiController]
    public class HolderController : ControllerBase
    {
        private readonly IHolderService _holderService;

        public HolderController(IHolderService holderService)
        {
            _holderService = holderService;
        }

        // GET: api/<HolderController>
        [HttpGet]
        public async Task<IEnumerable<HolderDto>> Get()
        {
            return await _holderService.FindAllAsync();
        }

        // GET api/<HolderController>/5
        [HttpGet("{id}")]
        public async Task<HolderDto> Get(int id)
        {
            return await _holderService.FindByIdAsync(id);
        }

        // POST api/<HolderController>
        [HttpPost]
        public async Task<HolderDto> Post([FromBody] HolderSaveDto saveDto)
        {
            return await _holderService.CreateAsync(saveDto);
        }

        // PUT api/<HolderController>/5
        [HttpPut("{id}")]
        public async Task<HolderDto> Put(int id, [FromBody] HolderSaveDto saveDto)
        {
            return await _holderService.EditAsync(id, saveDto);
        }

        // DELETE api/<HolderController>/5
        [HttpDelete("{id}")]
        public async Task<HolderDto> Delete(int id)
        {
            return await _holderService.DisabledAsync(id);
        }
    }
}

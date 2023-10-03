using Jazani.Application.Admins.Dtos.Processes;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _processService;

        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }


        // GET: api/<ProcessController>
        [HttpGet]
        public async Task<IEnumerable<ProcessDto>> Get()
        {
            return await _processService.FindAllAsync();
        }

        // GET api/<ProcessController>/5
        [HttpGet("{id}")]
        public async Task<ProcessDto> Get(int id)
        {
            return await _processService.FindByIdAsync(id);
        }

        // POST api/<ProcessController>
        [HttpPost]
        public async Task<ProcessDto> Post([FromBody] ProcessSaveDto processSaveDto)
        {
            return await _processService.CreateAsync(processSaveDto);
        }

        // PUT api/<ProcessController>/5
        [HttpPut("{id}")]
        public async Task<ProcessDto> Put(int id, [FromBody] ProcessSaveDto processSaveDto)
        {
            return await _processService.EditAsync(id, processSaveDto);
        }

        // DELETE api/<ProcessController>/5
        [HttpDelete("{id}")]
        public async Task<ProcessDto> Delete(int id)
        {
            return await _processService.DisabledAsync(id);
        }
    }
}

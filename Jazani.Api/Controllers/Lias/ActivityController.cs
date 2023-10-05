using Jazani.Application.Lias.Dtos.Activities;
using Jazani.Application.Lias.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Lias
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }


        // GET: api/<ProcessController>
        [HttpGet]
        public async Task<IEnumerable<ActivityDto>> Get()
        {
            return await _activityService.FindAllAsync();
        }

        // GET api/<ProcessController>/5
        [HttpGet("{id}")]
        public async Task<ActivityDto> Get(int id)
        {
            return await _activityService.FindByIdAsync(id);
        }

        // POST api/<ProcessController>
        [HttpPost]
        public async Task<ActivityDto> Post([FromBody] ActivitySaveDto processSaveDto)
        {
            return await _activityService.CreateAsync(processSaveDto);
        }

        // PUT api/<ProcessController>/5
        [HttpPut("{id}")]
        public async Task<ActivityDto> Put(int id, [FromBody] ActivitySaveDto processSaveDto)
        {
            return await _activityService.EditAsync(id, processSaveDto);
        }

        // DELETE api/<ProcessController>/5
        [HttpDelete("{id}")]
        public async Task<ActivityDto> Delete(int id)
        {
            return await _activityService.DisabledAsync(id);
        }
    }
}

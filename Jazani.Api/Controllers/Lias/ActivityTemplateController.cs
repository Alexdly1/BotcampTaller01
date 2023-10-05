using Jazani.Application.Lias.Dtos.ActivitiesTemplates;
using Jazani.Application.Lias.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Lias
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTemplateController : ControllerBase
    {

        private readonly IActivityTemplateService _activityTemplateService;

        public ActivityTemplateController(IActivityTemplateService activityTemplateService)
        {
            _activityTemplateService = activityTemplateService;
        }


        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<ActivityTemplateDto>> Get()
        {
            return await _activityTemplateService.FindAllAsync();
        }

        // GET api/<ProcessController>/5
        [HttpGet("{id}")]
        public async Task<ActivityTemplateDto> Get(int id)
        {
            return await _activityTemplateService.FindByIdAsync(id);
        }

        // POST api/<ProcessController>
        [HttpPost]
        public async Task<ActivityTemplateDto> Post([FromBody] ActivityTemplateSaveDto saveDto)
        {
            return await _activityTemplateService.CreateAsync(saveDto);
        }

        // PUT api/<ProcessController>/5
        [HttpPut("{id}")]
        public async Task<ActivityTemplateDto> Put(int id, [FromBody] ActivityTemplateSaveDto saveDto)
        {
            return await _activityTemplateService.EditAsync(id, saveDto);
        }

        // DELETE api/<ProcessController>/5
        [HttpDelete("{id}")]
        public async Task<ActivityTemplateDto> Delete(int id)
        {
            return await _activityTemplateService.DisabledAsync(id);
        }
    }
}

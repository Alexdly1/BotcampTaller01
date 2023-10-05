using AutoMapper;
using Jazani.Application.Lias.Dtos.ActivitiesTemplates;
using Jazani.Domain.Lias.Models;
using Jazani.Domain.Lias.Repositories;

namespace Jazani.Application.Lias.Services.Implementations
{
    public class ActivityTemplateService : IActivityTemplateService
    {
        private readonly IActivityTemplateRepository _activityTemplateRepository;
        private readonly IMapper _mapper;

        public ActivityTemplateService(IActivityTemplateRepository activityTemplateRepository, IMapper mapper)
        {
            _activityTemplateRepository = activityTemplateRepository;
            _mapper = mapper;
        }

        public async Task<ActivityTemplateDto> CreateAsync(ActivityTemplateSaveDto activitySaveDto)
        {
            ActivityTemplate activityTemplate = _mapper.Map<ActivityTemplate>(activitySaveDto);
            activityTemplate.RegistrationDate = DateTime.Now;
            activityTemplate.State = true;

            await _activityTemplateRepository.SaveAsync(activityTemplate);

            return _mapper.Map<ActivityTemplateDto>(activityTemplate);
        }

        public async Task<ActivityTemplateDto> DisabledAsync(int id)
        {
            ActivityTemplate activityTemplate = await _activityTemplateRepository.FindByIdAsync(id);
            activityTemplate.State = false;

            await _activityTemplateRepository.SaveAsync(activityTemplate);

            return _mapper.Map<ActivityTemplateDto>(activityTemplate);
        }

        public async Task<ActivityTemplateDto> EditAsync(int id, ActivityTemplateSaveDto activitySaveDto)
        {
            ActivityTemplate activityTemplate = await _activityTemplateRepository.FindByIdAsync(id);

            _mapper.Map<ActivityTemplateSaveDto, ActivityTemplate>(activitySaveDto, activityTemplate);

            await _activityTemplateRepository.SaveAsync(activityTemplate);

            return _mapper.Map<ActivityTemplateDto>(activityTemplate);
        }

        public async Task<IReadOnlyList<ActivityTemplateDto>> FindAllAsync()
        {
            IReadOnlyList<ActivityTemplate> activityTemplates = await _activityTemplateRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<ActivityTemplateDto>>(activityTemplates);
        }

        public async Task<ActivityTemplateDto?> FindByIdAsync(int id)
        {
            ActivityTemplate activityTemplate = await _activityTemplateRepository.FindByIdAsync(id);

            return _mapper.Map<ActivityTemplateDto>(activityTemplate);
        }
    }
}

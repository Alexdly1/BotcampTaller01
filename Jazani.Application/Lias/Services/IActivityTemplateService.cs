using System;
using Jazani.Application.Lias.Dtos.ActivitiesTemplates;

namespace Jazani.Application.Lias.Services
{
    public interface IActivityTemplateService
    {
        Task<IReadOnlyList<ActivityTemplateDto>> FindAllAsync();
        Task<ActivityTemplateDto?> FindByIdAsync(int id);
        Task<ActivityTemplateDto> CreateAsync(ActivityTemplateSaveDto activitySaveDto);
        Task<ActivityTemplateDto> EditAsync(int id, ActivityTemplateSaveDto activitySaveDto);
        Task<ActivityTemplateDto> DisabledAsync(int id);
        
    }
}

using Jazani.Application.Lias.Dtos.Activities;

namespace Jazani.Application.Lias.Services
{
    public interface IActivityService
    {
        Task<IReadOnlyList<ActivityDto>> FindAllAsync();
        Task<ActivityDto?> FindByIdAsync(int id);
        Task<ActivityDto> CreateAsync(ActivitySaveDto activitySaveDto);
        Task<ActivityDto> EditAsync(int id, ActivitySaveDto activitySaveDto);
        Task<ActivityDto> DisabledAsync(int id);

    }

}

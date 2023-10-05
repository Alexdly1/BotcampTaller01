using AutoMapper;
using Jazani.Application.Lias.Dtos.Activities;
using Jazani.Domain.Lias.Models;
using Jazani.Domain.Lias.Repositories;

namespace Jazani.Application.Lias.Services.Implementations
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;
        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ActivityDto>> FindAllAsync()
        {
            IReadOnlyList<Activity> activities = await _activityRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<ActivityDto>>(activities);
        }

        public async Task<ActivityDto?> FindByIdAsync(int id)
        {
            Activity? activity = await _activityRepository.FindByIdAsync(id);

            return _mapper.Map<ActivityDto>(activity);
        }

        public async Task<ActivityDto> CreateAsync(ActivitySaveDto activitySaveDto)
        {
            Activity activity = _mapper.Map<Activity>(activitySaveDto);
            activity.RegistrationDate = DateTime.Now;
            activity.State = true;

            Activity activitySaved = await _activityRepository.SaveAsync(activity);

            return _mapper.Map<ActivityDto>(activitySaved);
        }

        public async Task<ActivityDto> EditAsync(int id, ActivitySaveDto activitySaveDto)
        {
            Activity activity = await _activityRepository.FindByIdAsync(id);

            _mapper.Map<ActivitySaveDto, Activity>(activitySaveDto, activity);

            Activity activitySaved = await _activityRepository.SaveAsync(activity);

            return _mapper.Map<ActivityDto>(activitySaved);
        }

        public async Task<ActivityDto> DisabledAsync(int id)
        {
            Activity activity = await _activityRepository.FindByIdAsync(id);

            activity.State = false;

            Activity activitySaved = await _activityRepository.SaveAsync(activity);

            return _mapper.Map<ActivityDto>(activitySaved);
        }

    }
}

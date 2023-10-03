using Jazani.Application.Admins.Dtos.Processes;

namespace Jazani.Application.Admins.Services
{
    public interface IProcessService
    {
        Task<IReadOnlyList<ProcessDto>> FindAllAsync();
        Task<ProcessDto?> FindByIdAsync(int id);
        Task<ProcessDto> CreateAsync(ProcessSaveDto processSaveDto);
        Task<ProcessDto> EditAsync(int id, ProcessSaveDto processSaveDto);
        Task<ProcessDto> DisabledAsync(int id);

    }

}
    
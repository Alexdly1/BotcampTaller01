using Jazani.Application.Mcs.Dtos.Miningconcessions;

namespace Jazani.Application.Mcs.Services
{
    public interface IMiningconcessionService
    {
        Task<IReadOnlyList<MiningconcessionDto>> FindAllAsync();
        Task<MiningconcessionDto?> FindByIdAsync(int id);
        Task<MiningconcessionDto> CreateAsync(MiningconcessionSaveDto miningconcessionSaveDto);
        Task<MiningconcessionDto> EditAsync(int id, MiningconcessionSaveDto miningconcessionSaveDto);
        Task<MiningconcessionDto> DisabledAsync(int id);
    }
}

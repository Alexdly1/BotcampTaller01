using Jazani.Application.Socs.Dtos.Holders;

namespace Jazani.Application.Socs.Services
{
    public interface IHolderService
    {
        Task<IReadOnlyList<HolderDto>> FindAllAsync();
        Task<HolderDto?> FindByIdAsync(int id);
        Task<HolderDto> CreateAsync(HolderSaveDto holderSaveDto);
        Task<HolderDto> EditAsync(int id, HolderSaveDto holderSaveDto);
        Task<HolderDto> DisabledAsync(int id);
    }
}

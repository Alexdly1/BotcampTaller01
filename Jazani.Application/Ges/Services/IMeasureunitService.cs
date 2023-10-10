using Jazani.Application.Ges.Dtos.Measureunits;

namespace Jazani.Application.Ges.Services
{
    public interface IMeasureunitService
    {
        Task<IReadOnlyList<MeasureunitDto>> FindAllAsync();
        Task<MeasureunitDto?> FindByIdAsync(int id);
        Task<MeasureunitDto> CreateAsync(MeasureunitSaveDto measureunitSaveDto);
        Task<MeasureunitDto> EditAsync(int id, MeasureunitSaveDto measureunitSaveDto);
        Task<MeasureunitDto> DisabledAsync(int id);
    }
}

using Jazani.Application.Mcs.Dtos.Investments;

namespace Jazani.Application.Mcs.Services
{
    public interface IInvesmentService
    {
        Task<IReadOnlyList<InvestmentDto>> FindAllAsync();
        Task<InvestmentDto?> FindByIdAsync(int id);
        Task<InvestmentDto> CreateAsync(InvestmentSaveDto investmentSaveDto);
        Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSaveDto);
        Task<InvestmentDto> DisabledAsync(int id);
    }
}

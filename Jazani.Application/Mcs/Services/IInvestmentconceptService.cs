using Jazani.Application.Mcs.Dtos.Investmentconcepts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Mcs.Services
{
    public interface IInvestmentconceptService
    {
        Task<IReadOnlyList<InvestmentconceptDto>> FindAllAsync();
        Task<InvestmentconceptDto?> FindByIdAsync(int id);
        Task<InvestmentconceptDto> CreateAsync(InvestmentconceptSaveDto investmentconceptSaveDto);
        Task<InvestmentconceptDto> EditAsync(int id, InvestmentconceptSaveDto investmentconceptSaveDto);
        Task<InvestmentconceptDto> DisabledAsync(int id);
    }
}

using Jazani.Application.Mcs.Dtos.Investmenttypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Mcs.Services
{
    public interface IInvestmenttypeService
    {
        Task<IReadOnlyList<InvestmenttypeDto>> FindAllAsync();
        Task<InvestmenttypeDto?> FindByIdAsync(int id);
        Task<InvestmenttypeDto> CreateAsync(InvestmenttypeSaveDto investmenttypeSaveDto);
        Task<InvestmenttypeDto> EditAsync(int id, InvestmenttypeSaveDto investmenttypeSaveDto);
        Task<InvestmenttypeDto> DisabledAsync(int id);
    }
}

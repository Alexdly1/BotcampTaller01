using Jazani.Application.Ges.Dtos.Periodtypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Ges.Services
{
    public interface IPeriodtypeService
    {
        Task<IReadOnlyList<PeriodtypeDto>> FindAllAsync();
        Task<PeriodtypeDto?> FindByIdAsync(int id);
        Task<PeriodtypeDto> CreateAsync(PeriodtypeSaveDto periodtypeSaveDto);
        Task<PeriodtypeDto> EditAsync(int id, PeriodtypeSaveDto periodtypeSaveDto);
        Task<PeriodtypeDto> DisabledAsync(int id);
    }
}

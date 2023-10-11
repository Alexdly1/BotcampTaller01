using Jazani.Application.Cores.Services;
using Jazani.Application.Mcs.Dtos.Investments;

namespace Jazani.Application.Mcs.Services
{
    public interface IInvesmentService : ICrudService<InvestmentDto, InvestmentSaveDto, int>
    {
    }
}

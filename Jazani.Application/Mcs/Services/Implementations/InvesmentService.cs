using AutoMapper;
using Jazani.Application.Lias.Dtos.ActivitiesTemplates;
using Jazani.Application.Mcs.Dtos.Investments;
using Jazani.Domain.Lias.Models;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;

namespace Jazani.Application.Mcs.Services.Implementations
{
    public class InvesmentService : IInvesmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;

        public InvesmentService(IInvestmentRepository investmentRepository, IMapper mapper)
        {
            _investmentRepository = investmentRepository;
            _mapper = mapper;
        }

        public async Task<InvestmentDto> CreateAsync(InvestmentSaveDto investmentSaveDto)
        {
            Investment investment = _mapper.Map<Investment>(investmentSaveDto);
            investment.RegistrationDate = DateTime.Now;
            investment.State = true;

            await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investment);
        }

        public async Task<InvestmentDto> DisabledAsync(int id)
        {

            Investment investment = await _investmentRepository.FindByIdAsync(id);
            investment.State = false;

            await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investment);
        }

        public async Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSaveDto)
        {
            Investment investment = await _investmentRepository.FindByIdAsync(id);

            _mapper.Map<InvestmentSaveDto, Investment>(investmentSaveDto, investment);

            await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investment);
        }

        public async Task<IReadOnlyList<InvestmentDto>> FindAllAsync()
        {
            IReadOnlyList<Investment> investment = await _investmentRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmentDto>>(investment);
        }

        public async Task<InvestmentDto?> FindByIdAsync(int id)
        {
            Investment investment = await _investmentRepository.FindByIdAsync(id);

            return _mapper.Map<InvestmentDto>(investment);
        }
    }
}

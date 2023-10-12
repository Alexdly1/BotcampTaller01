using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Mcs.Dtos.Investments;
using Jazani.Core.Paginations;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Mcs.Services.Implementations
{
    public class InvesmentService : IInvesmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvesmentService> _logger;

        public InvesmentService(IInvestmentRepository investmentRepository, IMapper mapper, ILogger<InvesmentService> logger)
        {
            _investmentRepository = investmentRepository;
            _mapper = mapper;
            _logger = logger;
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

            Investment? investment = await _investmentRepository.FindByIdAsync(id);

            if (investment is null) throw InvestmentNotFound(id);

            investment.State = false;

            await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investment);
        }

        public async Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSaveDto)
        {
            Investment? investment = await _investmentRepository.FindByIdAsync(id);

            if (investment is null) throw InvestmentNotFound(id);
            _mapper.Map<InvestmentSaveDto, Investment>(investmentSaveDto, investment);

            await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investment);
        }

        public async Task<IReadOnlyList<InvestmentDto>> FindAllAsync()
        {
            IReadOnlyList<Investment> investment = await _investmentRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmentDto>>(investment);
        }

        public async Task<InvestmentDto> FindByIdAsync(int id)
        {
            Investment? investment = await _investmentRepository.FindByIdAsync(id);

            //if (investment is null) throw InvestmentNotFound(id);
            if (investment is null)
            {
                _logger.LogWarning("Investment no encontrado para el id: " + id);
                throw InvestmentNotFound(id);
            }

            _logger.LogInformation("Descripcion de invesment {description}", investment.Description);

            return _mapper.Map<InvestmentDto>(investment);
}

        public async Task<ResponsePagination<InvestmentDto>> PaginatedSearch(RequestPagination<InvestmentFilterDto> request)
        {
            var entity = _mapper.Map<RequestPagination<Investment>>(request);
            var response = await _investmentRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<InvestmentDto>>(response);
        }

        private NotFoundCoreException InvestmentNotFound(int id)
{
return new NotFoundCoreException("Investment no encontrado para el id: " + id);
}
}
}

using AutoMapper;
using Jazani.Application.Mcs.Dtos.Investmenttypes;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;

namespace Jazani.Application.Mcs.Services.Implementations
{
    public class InvestmenttypeService : IInvestmenttypeService
    {
        private readonly IInvestmenttypeRepository _investmenttypeRepository;
        private readonly IMapper _mapper;

        public InvestmenttypeService(IInvestmenttypeRepository investmenttypeRepository, IMapper mapper)
        {
            _investmenttypeRepository = investmenttypeRepository;
            _mapper = mapper;
        }

        public async Task<InvestmenttypeDto> CreateAsync(InvestmenttypeSaveDto investmenttypeSaveDto)
        {
            Investmenttype investmenttype = _mapper.Map<Investmenttype>(investmenttypeSaveDto);
            investmenttype.RegistrationDate = DateTime.Now;
            investmenttype.State = true;

            Investmenttype investmenttySaved = await _investmenttypeRepository.SaveAsync(investmenttype);

            return _mapper.Map<InvestmenttypeDto>(investmenttySaved);
        }

        public async Task<InvestmenttypeDto> DisabledAsync(int id)
        {
            Investmenttype investmenttype = await _investmenttypeRepository.FindByIdAsync(id);

            investmenttype.State = false;

            Investmenttype investmentSaved = await _investmenttypeRepository.SaveAsync(investmenttype);

            return _mapper.Map<InvestmenttypeDto>(investmentSaved);
        }

        public async Task<InvestmenttypeDto> EditAsync(int id, InvestmenttypeSaveDto investmenttypeSaveDto)
        {
            Investmenttype investmenttype = await _investmenttypeRepository.FindByIdAsync(id);

            _mapper.Map<InvestmenttypeSaveDto, Investmenttype>(investmenttypeSaveDto, investmenttype);

            Investmenttype investmentSaved = await _investmenttypeRepository.SaveAsync(investmenttype);

            return _mapper.Map<InvestmenttypeDto>(investmentSaved);
        }

        public async Task<IReadOnlyList<InvestmenttypeDto>> FindAllAsync()
        {
            IReadOnlyList<Investmenttype> investmenttypes = await _investmenttypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmenttypeDto>>(investmenttypes);
        }

        public async Task<InvestmenttypeDto?> FindByIdAsync(int id)
        {
            Investmenttype? investmenttype = await _investmenttypeRepository.FindByIdAsync(id);

            return _mapper.Map<InvestmenttypeDto>(investmenttype);
        }
    }
}

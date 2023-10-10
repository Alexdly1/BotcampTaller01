using AutoMapper;
using Jazani.Application.Ges.Dtos.Periodtypes;
using Jazani.Domain.Ges.Models;
using Jazani.Domain.Ges.Repositories;

namespace Jazani.Application.Ges.Services.Implementations
{
    public class PeriodtypeService : IPeriodtypeService
    {
        private readonly IPeriodtypeRepository _periodtypeRepository;
        private readonly IMapper _mapper;

        public PeriodtypeService(IPeriodtypeRepository periodtypeRepository, IMapper mapper)
        {
            _periodtypeRepository = periodtypeRepository;
            _mapper = mapper;
        }

        public async Task<PeriodtypeDto> CreateAsync(PeriodtypeSaveDto periodtypeSaveDto)
        {
            Periodtype periodtype = _mapper.Map<Periodtype>(periodtypeSaveDto);
            periodtype.RegistrationDate = DateTime.Now;
            periodtype.State = true;

            Periodtype periodtypeSaved = await _periodtypeRepository.SaveAsync(periodtype);

            return _mapper.Map<PeriodtypeDto>(periodtypeSaved);
        }

        public async Task<PeriodtypeDto> DisabledAsync(int id)
        {
            Periodtype periodtype = await _periodtypeRepository.FindByIdAsync(id);

            periodtype.State = false;

            Periodtype periodtypeSaved = await _periodtypeRepository.SaveAsync(periodtype);

            return _mapper.Map<PeriodtypeDto>(periodtypeSaved);
        }

        public async Task<PeriodtypeDto> EditAsync(int id, PeriodtypeSaveDto periodtypeSaveDto)
        {
            Periodtype periodtype = await _periodtypeRepository.FindByIdAsync(id);

            _mapper.Map<PeriodtypeSaveDto, Periodtype>(periodtypeSaveDto, periodtype);

            Periodtype periodtypeSaved = await _periodtypeRepository.SaveAsync(periodtype);

            return _mapper.Map<PeriodtypeDto>(periodtypeSaved);
        }

        public async Task<IReadOnlyList<PeriodtypeDto>> FindAllAsync()
        {
            IReadOnlyList<Periodtype> periodtypes = await _periodtypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<PeriodtypeDto>>(periodtypes);
        }

        public async Task<PeriodtypeDto?> FindByIdAsync(int id)
        {
            Periodtype? periodtype = await _periodtypeRepository.FindByIdAsync(id);

            return _mapper.Map<PeriodtypeDto>(periodtype);
        }
    }
}

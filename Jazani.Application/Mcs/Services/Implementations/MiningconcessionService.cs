using AutoMapper;
using Jazani.Application.Mcs.Dtos.Miningconcessions;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;

namespace Jazani.Application.Mcs.Services.Implementations
{
    public class MiningconcessionService : IMiningconcessionService
    {
        private readonly IMiningconcessionRepository _miningconcessionRepository;
        private readonly IMapper _mapper;

        public MiningconcessionService(IMiningconcessionRepository miningconcessionRepository, IMapper mapper)
        {
            _miningconcessionRepository = miningconcessionRepository;
            _mapper = mapper;
        }

        public async Task<MiningconcessionDto> CreateAsync(MiningconcessionSaveDto miningconcessionSaveDto)
        {
            Miningconcession miningconcession = _mapper.Map<Miningconcession>(miningconcessionSaveDto);
            miningconcession.RegistrationDate = DateTime.Now;
            miningconcession.State = true;

            Miningconcession miningconcessionSaved = await _miningconcessionRepository.SaveAsync(miningconcession);

            return _mapper.Map<MiningconcessionDto>(miningconcessionSaved);
        }

        public async Task<MiningconcessionDto> DisabledAsync(int id)
        {
            Miningconcession miningconcession = await _miningconcessionRepository.FindByIdAsync(id);

            miningconcession.State = false;

            Miningconcession miningconcessionSaved = await _miningconcessionRepository.SaveAsync(miningconcession);

            return _mapper.Map<MiningconcessionDto>(miningconcessionSaved);
        }

        public async Task<MiningconcessionDto> EditAsync(int id, MiningconcessionSaveDto miningconcessionSaveDto)
        {
            Miningconcession miningconcession = await _miningconcessionRepository.FindByIdAsync(id);

            _mapper.Map<MiningconcessionSaveDto, Miningconcession>(miningconcessionSaveDto, miningconcession);

            Miningconcession miningconcessionSaved = await _miningconcessionRepository.SaveAsync(miningconcession);

            return _mapper.Map<MiningconcessionDto>(miningconcessionSaved);
        }

        public async Task<IReadOnlyList<MiningconcessionDto>> FindAllAsync()
        {
            IReadOnlyList<Miningconcession> miningconcessions = await _miningconcessionRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MiningconcessionDto>>(miningconcessions);
        }

        public async Task<MiningconcessionDto?> FindByIdAsync(int id)
        {
            Miningconcession? miningconcession = await _miningconcessionRepository.FindByIdAsync(id);

            return _mapper.Map<MiningconcessionDto>(miningconcession);
        }
    }
}

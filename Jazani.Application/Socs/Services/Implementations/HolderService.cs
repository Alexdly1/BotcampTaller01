using AutoMapper;
using Jazani.Application.Socs.Dtos.Holders;
using Jazani.Domain.Socs.Models;
using Jazani.Domain.Socs.Repositories;

namespace Jazani.Application.Socs.Services.Implementations
{
    public class HolderService : IHolderService
    {
        private readonly IHolderRepository _holderRepository;
        private readonly IMapper _mapper;

        public HolderService(IHolderRepository holderRepository, IMapper mapper)
        {
            _holderRepository = holderRepository;
            _mapper = mapper;
        }

        public async Task<HolderDto> CreateAsync(HolderSaveDto holderSaveDto)
        {
            Holder holder = _mapper.Map<Holder>(holderSaveDto);
            holder.RegistrationDate = DateTime.Now;
            holder.State = true;

            Holder holderSaved = await _holderRepository.SaveAsync(holder);

            return _mapper.Map<HolderDto>(holderSaved);

        }

        public async Task<HolderDto> DisabledAsync(int id)
        {
            Holder holder = await _holderRepository.FindByIdAsync(id);

            holder.State = false;

            Holder holderSaved = await _holderRepository.SaveAsync(holder);

            return _mapper.Map<HolderDto>(holderSaved);
        }

        public async Task<HolderDto> EditAsync(int id, HolderSaveDto holderSaveDto)
        {
            Holder holder = await _holderRepository.FindByIdAsync(id);

            _mapper.Map<HolderSaveDto, Holder>(holderSaveDto, holder);

            Holder holderSaved = await _holderRepository.SaveAsync(holder);

            return _mapper.Map<HolderDto>(holderSaved);
        }

        public async Task<IReadOnlyList<HolderDto>> FindAllAsync()
        {
            IReadOnlyList<Holder> holders = await _holderRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<HolderDto>>(holders);
        }

        public async Task<HolderDto?> FindByIdAsync(int id)
        {
            Holder? holder = await _holderRepository.FindByIdAsync(id);

            return _mapper.Map<HolderDto>(holder);
        }
    }
}

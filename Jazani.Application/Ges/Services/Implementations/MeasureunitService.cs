using AutoMapper;
using Jazani.Application.Ges.Dtos.Measureunits;
using Jazani.Domain.Ges.Models;
using Jazani.Domain.Ges.Repositories;

namespace Jazani.Application.Ges.Services.Implementations
{
    public class MeasureunitService : IMeasureunitService
    {
        private readonly ImeasureunitRepository _measureunitRepository;
        private readonly IMapper _mapper;

        public MeasureunitService(ImeasureunitRepository measureunitRepository, IMapper mapper)
        {
            _measureunitRepository = measureunitRepository;
            _mapper = mapper;
        }

        public async Task<MeasureunitDto> CreateAsync(MeasureunitSaveDto measureunitSaveDto)
        {
            Measureunit measureunit = _mapper.Map<Measureunit>(source: measureunitSaveDto);
            measureunit.RegistrationDate = DateTime.Now;
            measureunit.State = true;

            Measureunit measureunitSaved = await _measureunitRepository.SaveAsync(measureunit);

            return _mapper.Map<MeasureunitDto>(measureunitSaved);
        }

        public async Task<MeasureunitDto> DisabledAsync(int id)
        {
            Measureunit measureunit = await _measureunitRepository.FindByIdAsync(id);

            measureunit.State = false;

            Measureunit measureunitSaved = await _measureunitRepository.SaveAsync(measureunit);

            return _mapper.Map<MeasureunitDto>(measureunitSaved);
        }

        public async Task<MeasureunitDto> EditAsync(int id, MeasureunitSaveDto measureunitSaveDto)
        {
            Measureunit measureunit = await _measureunitRepository.FindByIdAsync(id);

            _mapper.Map<MeasureunitSaveDto, Measureunit>(measureunitSaveDto, measureunit);

            Measureunit measureunitSaved = await _measureunitRepository.SaveAsync(measureunit);

            return _mapper.Map<MeasureunitDto>(measureunitSaved);
        }

        public async Task<IReadOnlyList<MeasureunitDto>> FindAllAsync()
        {
            IReadOnlyList<Measureunit> measureunits = await _measureunitRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MeasureunitDto>>(measureunits);
        }

        public async Task<MeasureunitDto?> FindByIdAsync(int id)
        {
            Measureunit? measureunit = await _measureunitRepository.FindByIdAsync(id);

            return _mapper.Map<MeasureunitDto>(measureunit);
        }
    }
}

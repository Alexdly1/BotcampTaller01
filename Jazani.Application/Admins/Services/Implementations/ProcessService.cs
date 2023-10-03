using AutoMapper;
using Jazani.Application.Admins.Dtos.Processes;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessRepository _processRepository;
        private readonly IMapper _mapper;
        public ProcessService(IProcessRepository processRepository, IMapper mapper)
        {
            _processRepository = processRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProcessDto>> FindAllAsync()
        {
            IReadOnlyList<Process> processes = await _processRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<ProcessDto>>(processes);
        }

        public async Task<ProcessDto?> FindByIdAsync(int id)
        {
            Process? process = await _processRepository.FindByIdAsync(id);

            return _mapper.Map<ProcessDto>(process);
        }

        public async Task<ProcessDto> CreateAsync(ProcessSaveDto processSaveDto)
        {
            Process process = _mapper.Map<Process>(processSaveDto);
            process.RegistrationDate = DateTime.Now;
            process.State = true;

            Process processSaved = await _processRepository.SaveAsync(process);

            return _mapper.Map<ProcessDto>(processSaved);
        }

        public async Task<ProcessDto> EditAsync(int id, ProcessSaveDto processSaveDto)
        {
            Process process = await _processRepository.FindByIdAsync(id);

            _mapper.Map<ProcessSaveDto, Process>(processSaveDto, process);

            Process processSaved = await _processRepository.SaveAsync(process);

            return _mapper.Map<ProcessDto>(processSaved);
        }

        public async Task<ProcessDto> DisabledAsync(int id)
        {
            Process process = await _processRepository.FindByIdAsync(id);

            process.State = false;

            Process processSaved = await _processRepository.SaveAsync(process);

            return _mapper.Map<ProcessDto>(processSaved);
        }

    }
}

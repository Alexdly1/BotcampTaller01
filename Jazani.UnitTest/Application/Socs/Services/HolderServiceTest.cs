using AutoFixture;
using AutoMapper;
using Jazani.Application.Socs.Dtos.Holders;
using Jazani.Application.Socs.Dtos.Holders.Profiles;
using Jazani.Application.Socs.Services;
using Jazani.Application.Socs.Services.Implementations;
using Jazani.Domain.Socs.Models;
using Jazani.Domain.Socs.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.UnitTest.Application.Socs.Services
{
    public class HolderServiceTest
    {
        Mock<IHolderRepository> _mockHolderRepository;
        Mock<Microsoft.Extensions.Logging.ILogger<HolderService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public HolderServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<HolderProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mockHolderRepository = new Mock<IHolderRepository>();

            _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<HolderService>>();
        }

        [Fact]
        public async void returnHolderDtoWhenFindByIdAsync()
        {
            // Arrange
            Holder holder = _fixture.Create<Holder>();

            _mockHolderRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(holder);


            // Act
            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper);
            HolderDto holderDto = await holderService.FindByIdAsync(holder.Id);

            // Assert
            Assert.Equal(holder.Name, holderDto.Name);
        }

        [Fact]
        public async void returnHoldersDtoWhenFindAllAsync()
        {
            // Arrage
            IReadOnlyList<Holder> holders = _fixture.CreateMany<Holder>(5)
                .ToList();

            _mockHolderRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(holders);

            // Act
            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper);
            IReadOnlyList<HolderDto> holderDtos = await holderService.FindAllAsync();

            // Assert
            Assert.Equal(holders.Count, holderDtos.Count);
        }

        [Fact]
        public async void returnHolderDtoWhenCreateAsync()
        {

            // Arrage
            Holder holder = new()
            {
                Name = "Prueba 01",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockHolderRepository
                .Setup(r => r.SaveAsync(It.IsAny<Holder>()))
                .ReturnsAsync(holder);


            // Act
            HolderSaveDto holderSaveDto = new()
            {
                Name = holder.Name
            };

            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper);
            HolderDto holderDto = await holderService.CreateAsync(holderSaveDto);


            // Assert
            Assert.Equal(holder.Name, holderDto.Name);
        }

        [Fact]
        public async void returnHolderDtoWhenEditAsync()
        {
            // Arrage
            int id = 1;

            Holder holder = new()
            {
                Name = "Prueba 01",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockHolderRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(holder);

            _mockHolderRepository
                .Setup(r => r.SaveAsync(It.IsAny<Holder>()))
                .ReturnsAsync(holder);

            // Act
            HolderSaveDto holderSaveDto = new()
            {
                Name = holder.Name
            };

            IHolderService HolderService = new HolderService(_mockHolderRepository.Object, _mapper);

            HolderDto holderDto = await HolderService.EditAsync(id, holderSaveDto);


            // Assert
            Assert.Equal(holder.Name, holderDto.Name);
        }

        [Fact]
        public async void returnHolderDtoWhenDisabledAsync()
        {

            // Arrage
            int id = 1;

            Holder holder = new()
            {
                Name = "Prueba 01",
                State = true,
                RegistrationDate = DateTime.Now
            };


            _mockHolderRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(holder);

            _mockHolderRepository
                .Setup(r => r.SaveAsync(It.IsAny<Holder>()))
                .ReturnsAsync(holder);

            // Act
            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper);
            HolderDto holderDto = await holderService.DisabledAsync(id);


            // Assert
            Assert.Equal(holder.State, holderDto.State);
        }
    }
}

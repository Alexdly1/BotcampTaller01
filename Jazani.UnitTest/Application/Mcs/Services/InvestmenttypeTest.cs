using AutoFixture;
using AutoMapper;
using Jazani.Application.Ges.Dtos.Measureunits.Profiles;
using Jazani.Application.Ges.Dtos.Periodtypes.Profiles;
using Jazani.Application.Mcs.Dtos.Investmentconcepts.Profiles;
using Jazani.Application.Mcs.Dtos.Investments;
using Jazani.Application.Mcs.Dtos.Investments.Profiles;
using Jazani.Application.Mcs.Dtos.Investmenttypes;
using Jazani.Application.Mcs.Dtos.Investmenttypes.Profiles;
using Jazani.Application.Mcs.Dtos.Miningconcessions.Profiles;
using Jazani.Application.Mcs.Services;
using Jazani.Application.Mcs.Services.Implementations;
using Jazani.Application.Socs.Dtos.Holders.Profiles;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Moq;

namespace Jazani.UnitTest.Application.Mcs.Services
{
    public class InvestmenttypeServiceTest
    {
        Mock<IInvestmenttypeRepository> _mockInvestmenttypeRepository;
        //Mock<Microsoft.Extensions.Logging.ILogger<InvestmenttypeService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public InvestmenttypeServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<InvestmenttypeProfile>();

            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mockInvestmenttypeRepository = new Mock<IInvestmenttypeRepository>();

            //_mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<InvestmenttypeService>>();
        }

        [Fact]
        public async void returnInvestmenttypeDtoFindByIdAsync()
        {
            //Arrange
            Investmenttype investmenttype = _fixture.Create<Investmenttype>();

            _mockInvestmenttypeRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investmenttype);

            //Act
            IInvestmenttypeService investmenttypeService = new InvestmenttypeService(_mockInvestmenttypeRepository.Object, _mapper);

            InvestmenttypeDto investmenttypeDto = await investmenttypeService.FindByIdAsync(investmenttype.Id);

            //Assert
            Assert.Equal(investmenttype.Name, investmenttypeDto.Name);
        }

        [Fact]
        public async void returnInvestmenttypeDtoWhenFindAllAsync()
        {
            // Arrage
            IReadOnlyList<Investmenttype> investmenttypes = _fixture.CreateMany<Investmenttype>(5)
                .ToList();

            _mockInvestmenttypeRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(investmenttypes);

            // Act
            IInvestmenttypeService investmenttypeService = new InvestmenttypeService(_mockInvestmenttypeRepository.Object, _mapper);

            IReadOnlyList<InvestmenttypeDto> investmenttypeDtos = await investmenttypeService.FindAllAsync();

            // Assert
            Assert.Equal(investmenttypes.Count, investmenttypeDtos.Count);
        }

        [Fact]
        public async void returnInvestmenttypeDtoDtoWhenCreateAsync()
        {

            // Arrage
            Investmenttype investmenttype = new()
            {
                Name = "Prueba 01",
                Description = "Prueba 02",
                RegistrationDate = DateTime.Now,
                State = false,
            };

            _mockInvestmenttypeRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investmenttype>()))
                .ReturnsAsync(investmenttype);


            // Act
            InvestmenttypeSaveDto investmenttypeSaveDto = new()
            {
                Name = investmenttype.Name,
                Description = investmenttype.Description
            };

            IInvestmenttypeService investmenttypeService = new InvestmenttypeService(_mockInvestmenttypeRepository.Object, _mapper);

            InvestmenttypeDto investmenttypeDto = await investmenttypeService.CreateAsync(investmenttypeSaveDto);


            // Assert
            Assert.Equal(investmenttype.Name, investmenttypeDto.Name);
        }

        [Fact]
        public async void returnInvestmenttypeDtoWhenEditAsync()
        {
            // Arrage

            int id = 1;

            Investmenttype investmenttype = new()
            {
                Id = id,
                Name = "Prueba 01",
                Description = "Prueba 02",
                RegistrationDate = DateTime.Now,
                State = false,
            };

            _mockInvestmenttypeRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investmenttype);

            _mockInvestmenttypeRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investmenttype>()))
                .ReturnsAsync(investmenttype);


            // Act
            InvestmenttypeSaveDto investmenttypeSaveDto = new()
            {
                Name = investmenttype.Name,
                Description = investmenttype.Description
            };

            IInvestmenttypeService investmenttypeService = new InvestmenttypeService(_mockInvestmenttypeRepository.Object, _mapper);

            InvestmenttypeDto investmenttypeDto = await investmenttypeService.EditAsync(id, investmenttypeSaveDto);


            // Assert
            Assert.Equal(investmenttype.Name, investmenttypeDto.Name);
        }

        [Fact]
        public async void returnInvestmenttypeDtoWhenDisabledAsync()
        {

            // Arrage
            int id = 1;

            Investmenttype investmenttype = new()
            {
                Id = id,
                Name = "Prueba 01",
                Description = "Prueba 02",
                RegistrationDate = DateTime.Now,
                State = false,
            };


            _mockInvestmenttypeRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investmenttype);

            _mockInvestmenttypeRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investmenttype>()))
                .ReturnsAsync(investmenttype);

            // Act

            IInvestmenttypeService investmenttypeService = new InvestmenttypeService(_mockInvestmenttypeRepository.Object, _mapper);

            InvestmenttypeDto investmenttypeDto = await investmenttypeService.DisabledAsync(id);


            // Assert
            Assert.Equal(investmenttype.Name, investmenttypeDto.Name);
        }
    }
}

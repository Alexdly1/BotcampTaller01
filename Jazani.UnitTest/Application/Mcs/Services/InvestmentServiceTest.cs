using AutoFixture;
using AutoMapper;
using Jazani.Application.Ges.Dtos.Measureunits.Profiles;
using Jazani.Application.Ges.Dtos.Periodtypes.Profiles;
using Jazani.Application.Mcs.Dtos.Investmentconcepts.Profiles;
using Jazani.Application.Mcs.Dtos.Investments;
using Jazani.Application.Mcs.Dtos.Investments.Profiles;
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
    public class InvestmentServiceTest
    {
        Mock<IInvestmentRepository> _mockInvestmentRepository;
        Mock<Microsoft.Extensions.Logging.ILogger<InvesmentService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public InvestmentServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<InvestmentProfile>();
                c.AddProfile<InvestmentconceptProfile>();
                c.AddProfile<InvestmenttypeProfile>();
                c.AddProfile<MiningconcessionProfile>();
                c.AddProfile<HolderProfile>();
                c.AddProfile<PeriodtypeProfile>();
                c.AddProfile<MeasureunitProfile>();

            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mockInvestmentRepository = new Mock<IInvestmentRepository>();

            _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<InvesmentService>>();
        }

        [Fact]
        public async void returnInvestmentDtoFindByIdAsync()
        {
            //Arrange
            Investment investment = _fixture.Create<Investment>();

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            //Act
            IInvesmentService investmentService = new InvesmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.FindByIdAsync(investment.Id);

            //Assert
            Assert.Equal(investment.Id, investmentDto.Id);
        }

        [Fact]
        public async void returnInvestmentDtoWhenFindAllAsync()
        {
            // Arrage
            IReadOnlyList<Investment> mineralTypes = _fixture.CreateMany<Investment>(5)
                .ToList();

            _mockInvestmentRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(mineralTypes);

            // Act
            IInvesmentService invesmentService = new InvesmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<InvestmentDto> mineralTypeDtos = await invesmentService.FindAllAsync();

            // Assert
            Assert.Equal(mineralTypes.Count, mineralTypeDtos.Count);
        }

        [Fact]
        public async void returnInvestmentDtoDtoWhenCreateAsync()
        {

            // Arrage
            Investment investment = new()
            {
                AmountInvested = 6,
                Year = 2023,
                Description = "Prueba 01",
                HolderId = 1,
                InvestmentconceptId = 1,
                InvestmenttypeId = 1,
                MiningconcessionId = 1,
                MeasureunitId = 1,
                PeriodtypeId = 1,
                CurrencyTypeId = 1,
                MonthName = "Junio",
                MonthId = 1,
                AccreditationCode = "x",
                AccountantCode = "y",
                DeclaredTypeId = 1,
                DocumentId = 1
            };

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);


            // Act
            InvestmentSaveDto investmentSaveDto = new()
            {
                AmountInvested = investment.AmountInvested,
                Year = investment.Year,
                Description = investment.Description,
                HolderId = investment.HolderId,
                InvestmentconceptId = investment.InvestmentconceptId,
                InvestmenttypeId = investment.InvestmentconceptId,
                MiningconcessionId = investment.MiningconcessionId,
                MeasureunitId = investment.MeasureunitId,
                PeriodtypeId = investment.PeriodtypeId,
                CurrencyTypeId = investment.CurrencyTypeId,
                MonthName = investment.MonthName,
                MonthId = investment.MonthId,
                AccreditationCode = investment.AccreditationCode,
                AccountantCode = investment.AccountantCode,
                DeclaredTypeId = investment.DeclaredTypeId,
                DocumentId = investment.DocumentId
            };

            IInvesmentService invesmentService = new InvesmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await invesmentService.CreateAsync(investmentSaveDto);


            // Assert
            Assert.Equal(investment.Description, investmentDto.Description);
        }

        [Fact]
        public async void returnInvestmentDtoWhenEditAsync()
        {
            // Arrage

            int id = 1;

            Investment investment = new()
            {
                Id = id,
                AmountInvested = 6,
                Year = 2023,
                Description = "Prueba 01",
                HolderId = 1,
                InvestmentconceptId = 1,
                InvestmenttypeId = 1,
                MiningconcessionId = 1,
                MeasureunitId = 1,
                PeriodtypeId = 1,
                CurrencyTypeId = 1,
                MonthName = "Junio",
                MonthId = 1,
                AccreditationCode = "x",
                AccountantCode = "y",
                DeclaredTypeId = 1,
                DocumentId = 1
            };

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);


            // Act
            InvestmentSaveDto investmentSaveDto = new()
            {
                AmountInvested = investment.AmountInvested,
                Year = investment.Year,
                Description = investment.Description,
                HolderId = investment.HolderId,
                InvestmentconceptId = investment.InvestmentconceptId,
                InvestmenttypeId = investment.InvestmentconceptId,
                MiningconcessionId = investment.MiningconcessionId,
                MeasureunitId = investment.MeasureunitId,
                PeriodtypeId = investment.PeriodtypeId,
                CurrencyTypeId = investment.CurrencyTypeId,
                MonthName = investment.MonthName,
                MonthId = investment.MonthId,
                AccreditationCode = investment.AccreditationCode,
                AccountantCode = investment.AccountantCode,
                DeclaredTypeId = investment.DeclaredTypeId,
                DocumentId = investment.DocumentId
            };

            IInvesmentService invesmentService = new InvesmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await invesmentService.EditAsync(id, investmentSaveDto);


            // Assert
            Assert.NotNull(investmentDto);
            Assert.Equal(investment.Description, investmentDto.Description);
        }

        [Fact]
        public async void returnInvestmentDtoWhenDisabledAsync()
        {

            // Arrage
            int id = 1;

            Investment investment = new()
            {
                Id = id,
                AmountInvested = 6,
                Year = 2023,
                Description = "Prueba 01",
                HolderId = 1,
                InvestmentconceptId = 1,
                InvestmenttypeId = 1,
                MiningconcessionId = 1,
                MeasureunitId = 1,
                PeriodtypeId = 1,
                CurrencyTypeId = 1,
                MonthName = "Junio",
                MonthId = 1,
                AccreditationCode = "x",
                AccountantCode = "y",
                DeclaredTypeId = 1,
                DocumentId = 1
            };


            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);

            // Act

            IInvesmentService invesmentService = new InvesmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await invesmentService.DisabledAsync(id);


            // Assert
            Assert.Equal(investment.State, investmentDto.State);
        }
    }
}

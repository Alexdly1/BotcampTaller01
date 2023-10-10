using Jazani.Application.Ges.Dtos.Measureunits;
using Jazani.Application.Ges.Dtos.Periodtypes;
using Jazani.Application.Mcs.Dtos.Investmentconcepts;
using Jazani.Application.Mcs.Dtos.Investmenttypes;
using Jazani.Application.Mcs.Dtos.Miningconcessions;
using Jazani.Application.Socs.Dtos.Holders;

namespace Jazani.Application.Mcs.Dtos.Investments
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public decimal AmountInvested { get; set; }
        public int? Year { get; set; }
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public int HolderId { get; set; }
        public int InvestmentconceptId { get; set; }
        public int InvestmenttypeId { get; set; }
        public int MiningconcessionId { get; set; }
        public int? MeasureunitId { get; set; }
        public int PeriodtypeId { get; set; }
        public int CurrencyTypeId { get; set; }
        public string? MonthName { get; set; }
        public int? MonthId { get; set; }
        public string? AccreditationCode { get; set; }
        public string? AccountantCode { get; set; }
        public int DeclaredTypeId { get; set; }
        public int? DocumentId { get; set; }

        public HolderSimpleDto Holder { get; set; }
        public InvestmentconceptSimpleDto InvestmentConcept { get; set; }
        public InvestmenttypeSimpleDto InvestmentType { get; set; }

        public MiningconcessionSimpleDto Miningconcession { get; set; }
        public MeasureunitSimpleDto Measureunit { get; set; }
        public PeriodtypeSimpleDto Periodtype { get; set; }


    }
}

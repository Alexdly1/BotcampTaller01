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
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public HolderSimpleDto Holder { get; set; }
        public InvestmentconceptSimpleDto InvestmentConcept { get; set; }
        public InvestmenttypeSimpleDto InvestmentType { get; set; }

        public MiningconcessionSimpleDto Miningconcession { get; set; }
        public MeasureunitSimpleDto Measureunit { get; set; }
        public PeriodtypeSimpleDto Periodtype { get; set; }
    }
}

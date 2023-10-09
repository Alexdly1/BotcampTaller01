using Jazani.Application.Lias.Dtos.Activities;
using Jazani.Application.Mcs.Dtos.Investmentconcepts;
using Jazani.Application.Mcs.Dtos.Investmenttypes;
using Jazani.Application.Mcs.Dtos.Miningconcessions;
using Jazani.Application.Socs.Dtos.Holders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Mcs.Dtos.Investments
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public HolderSimpleDto Holder { get; set; }
        public InvestmentconceptDto InvestmentConcept { get; set; }
        public InvestmenttypeDto InvestmentType { get; set; }

        public MiningconcessionDto Miningconcession { get; set; }
    }
}

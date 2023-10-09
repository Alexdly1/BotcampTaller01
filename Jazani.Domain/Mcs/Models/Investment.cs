using Jazani.Domain.Socs.Models;
using System;

namespace Jazani.Domain.Mcs.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public int HolderId { get; set; }
        public int InvestmentconceptId { get; set; }
        public int InvestmenttypeId { get; set; }
        public int MiningconcessionId { get; set; }

        public virtual Holder Holder { get; set; }
        public virtual Investmentconcept Investmentconcept { get; set; }
        public virtual Investmenttype Investmenttype { get; set; }
        public virtual Miningconcession Miningconcession { get; set; }
    }
}

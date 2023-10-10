using Jazani.Domain.Ges.Models;
using Jazani.Domain.Socs.Models;
using System;

namespace Jazani.Domain.Mcs.Models
{
    public class Investment
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
        public int? MeasureunitId  { get; set; }
        public int PeriodtypeId { get; set; }
        public int CurrencyTypeId { get; set; }
        public string? MonthName { get; set; }
        public int? MonthId { get; set; }        
        public string? AccreditationCode { get; set; }
        public string? AccountantCode { get; set; }
        public int DeclaredTypeId { get; set; }
        public int? DocumentId { get; set; }

        public virtual Holder Holder { get; set; }
        public virtual Investmentconcept Investmentconcept { get; set; }
        public virtual Investmenttype Investmenttype { get; set; }
        public virtual Miningconcession Miningconcession { get; set; }
        public virtual Measureunit Measureunit { get; set; }
        public virtual Periodtype Periodtype { get; set; }
    }
}

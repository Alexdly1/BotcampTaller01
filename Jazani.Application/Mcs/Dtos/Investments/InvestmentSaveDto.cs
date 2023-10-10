using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Mcs.Dtos.Investments
{
    public class InvestmentSaveDto
    {
        public decimal AmountInvested { get; set; }
        public int? Year { get; set; }
        public string? Description { get; set; }
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
    }
}

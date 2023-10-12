using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Mcs.Dtos.Investments
{
    public class InvestmentFilterDto
    {
        public string? Description { get; set; }

        public string? MonthName { get; set; }

        public string? AccreditationCode { get; set; }
        //public bool? State { get; set; }
        //public int? Year { get; set; }
    }
}

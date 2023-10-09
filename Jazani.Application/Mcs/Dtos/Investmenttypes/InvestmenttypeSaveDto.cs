using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Mcs.Dtos.Investmenttypes
{
    public class InvestmenttypeSaveDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Ges.Dtos.Measureunits
{
    public class MeasureunitSaveDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}

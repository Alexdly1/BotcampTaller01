﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Socs.Dtos.Holders
{
    public class HolderSaveDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}

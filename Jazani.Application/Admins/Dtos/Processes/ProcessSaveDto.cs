using System;

namespace Jazani.Application.Admins.Dtos.Processes
{
    public class ProcessSaveDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}

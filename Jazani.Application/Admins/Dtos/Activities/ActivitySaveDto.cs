using System;

namespace Jazani.Application.Admins.Dtos.Activities
{
    public class ActivitySaveDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}

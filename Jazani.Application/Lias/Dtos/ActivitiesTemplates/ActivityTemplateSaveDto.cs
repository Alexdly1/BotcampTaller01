using System;

namespace Jazani.Application.Lias.Dtos.ActivitiesTemplates
{
    public class ActivityTemplateSaveDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int ActivityTypeId { get; set; }
    }
}

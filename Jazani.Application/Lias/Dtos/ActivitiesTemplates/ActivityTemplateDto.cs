using Jazani.Application.Lias.Dtos.Activities;
using System;

namespace Jazani.Application.Lias.Dtos.ActivitiesTemplates
{
    public class ActivityTemplateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; } 
        public ActivitySimpleDto Activity { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}

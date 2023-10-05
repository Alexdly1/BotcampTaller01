namespace Jazani.Domain.Lias.Models
{
    public class ActivityTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int ActivityTypeId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual Activity Activity { get; set; }
    }
}

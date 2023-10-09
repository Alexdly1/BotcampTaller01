using Jazani.Domain.Mcs.Models;
using System;

namespace Jazani.Domain.Socs.Models
{
    public class Holder
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual ICollection<Investment> Investments { get; set; }
    }
}

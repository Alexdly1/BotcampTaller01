using Jazani.Domain.Socs.Models;
using System;

namespace Jazani.Domain.Mcs.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public int HolderId { get; set; }

        public virtual Holder Holder { get; set; }
    }
}

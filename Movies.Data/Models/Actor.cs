using System;
using System.Collections.Generic;

namespace Movies.Data.Models
{
    public partial class Actor
    {
        public Actor()
        {
            Movieactors = new HashSet<Movieactor>();
        }

        public string ActorId { get; set; } = null!;
        public string? ActorName { get; set; }
        public string? Bio { get; set; }
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }

        public virtual ICollection<Movieactor> Movieactors { get; set; }
    }
}

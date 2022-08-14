using System;
using System.Collections.Generic;

namespace Movies.Data.Models
{
    public partial class Movieactor
    {
        public string MovieActorId { get; set; } = null!;
        public string? MovieId { get; set; }
        public string? ActorId { get; set; }
        public string? Role { get; set; }

        public virtual Actor? Actor { get; set; }
        public virtual Movie? Movie { get; set; }
    }
}

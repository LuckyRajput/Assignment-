using System;
using System.Collections.Generic;

namespace Movies.Data.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Movieactors = new HashSet<Movieactor>();
        }

        public string MovieId { get; set; } = null!;
        public string? MovieName { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public string? ProducerId { get; set; }
        public byte[]? MoviePoster { get; set; }

        public virtual Producer? Producer { get; set; }
        public virtual ICollection<Movieactor> Movieactors { get; set; }
    }
}

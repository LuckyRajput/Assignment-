using System;
using System.Collections.Generic;

namespace Movies.Data.Models
{
    public partial class Producer
    {
        public Producer()
        {
            Movies = new HashSet<Movie>();
        }

        public string ProducerId { get; set; } = null!;
        public string? ProducerName { get; set; }
        public string? Bio { get; set; }
        public string? Company { get; set; }
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}

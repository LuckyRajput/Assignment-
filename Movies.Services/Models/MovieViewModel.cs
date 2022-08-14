using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Models
{
    public class MovieViewModel
    {
        public string MovieId { get; set; } = null!;
        public string? MovieName { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public byte[]? MoviePoster { get; set; }

        public ProducerViewModel Producer { get; set; } = new();
        public List<MovieActorViewModel> MovieActors { get; set; } = new();
    }
    public class MovieActorViewModel
    {
        public string? ActorId { get; set; }
        public string? ActorName { get; set; }
    }
    public class ProducerViewModel
    {
        public string? ProducerId { get; set; }
        public string? ProducerName { get; set; }
    }
}

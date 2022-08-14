using Movies.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Models
{
    public class MoviCommandModel
    {
        public string MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ProducerId { get; set; }
        public List<string> ActorIds { get; set; } = new();
        public byte[]? Poster { get; set; }

        public Movie GetMoviDbModel(string movieId)
        {
            movieId ??= Guid.NewGuid().ToString();
            return new Movie()
            {
                MovieId = movieId,
                MovieName = MovieName,
                Description = MovieDescription,
                DateOfRelease = ReleaseDate,
                MoviePoster = Poster,
                ProducerId = ProducerId,
                Movieactors = GetMovieActorDbModel(movieId, ActorIds)
            };
        }
        public List<Movieactor> GetMovieActorDbModel(string movieId,List<string> actorIds)
        {
            try
            {
                List<Movieactor> movieactors = new List<Movieactor>();
                actorIds.ForEach(actorId =>
                {
                    movieactors.Add(new Movieactor()
                    {
                        MovieActorId = Guid.NewGuid().ToString(),
                        ActorId = actorId,
                        MovieId = movieId,

                    });
                });
                return movieactors;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

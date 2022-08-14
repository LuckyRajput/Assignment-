using Movies.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Interfaces
{
    public interface IMovieService
    {
        public List<MovieViewModel> GetAllMovies();
        public bool CreateMovie(MoviCommandModel moviCommandModel);
        public bool UpdateMovie(MoviCommandModel moviCommandModel);
    }
}

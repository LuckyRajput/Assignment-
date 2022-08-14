using Microsoft.EntityFrameworkCore;
using Movies.Data.Models;
using Movies.Repository.Interface;
using Movies.Repository.UnitOfWork;
using Movies.Services.Interfaces;
using Movies.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepository<Movie> _moviesRepository;
        private IGenericRepository<Actor> _actorsRepository;
        private IGenericRepository<Movieactor> _actorsMovieRepository;
        private IGenericRepository<Producer> _producerRepository;
        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _moviesRepository = _unitOfWork.GetRepository<Movie>();
            _actorsRepository = _unitOfWork.GetRepository<Actor>();
            _producerRepository = _unitOfWork.GetRepository<Producer>();
            _actorsMovieRepository = _unitOfWork.GetRepository<Movieactor>();
        }
        public bool CreateMovie(MoviCommandModel moviCommandModel)
        {
            try
            {
                _moviesRepository.Add(moviCommandModel.GetMoviDbModel(moviCommandModel.MovieId));
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<MovieViewModel> GetAllMovies()
        {
            try
            {
                List<MovieViewModel> movieViewModels = (from movie in _moviesRepository.GetAll().Include(prod=> prod.Producer).Include(actor=> actor.Movieactors)
                                               select new MovieViewModel()
                                               {
                                                   MovieId = movie.MovieId,
                                                   MovieName = movie.MovieName,
                                                   Description = movie.Description,
                                                   MoviePoster = movie.MoviePoster,
                                                   DateOfRelease = movie.DateOfRelease,
                                                   Producer = new ProducerViewModel()
                                                   {
                                                       ProducerId = movie.Producer != null ? movie.Producer.ProducerId : null,
                                                       ProducerName = movie.Producer != null ? movie.Producer.ProducerName : null,
                                                   },
                                                   MovieActors = movie.Movieactors.Select(actor => new MovieActorViewModel() { ActorId = actor.ActorId,ActorName = actor.Actor.ActorName }).ToList(),
                                               }
                                               ).ToList();
             return movieViewModels;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool UpdateMovie(MoviCommandModel moviCommandModel)
        {
            try
            {
                var actors = _actorsMovieRepository.FindBy(movi => movi.MovieId == moviCommandModel.MovieId).Include(ac => ac.Actor).Select(data=>data.Actor).AsNoTracking().ToList();
                if(actors != null && actors.Count()>0)
                    _actorsRepository.HardDeleteMultiple(actors);
                _moviesRepository.Update(moviCommandModel.GetMoviDbModel(moviCommandModel.MovieId));
                _unitOfWork.Commit();
                return true;    
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}

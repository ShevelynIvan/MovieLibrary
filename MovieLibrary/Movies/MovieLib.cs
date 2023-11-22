using System.Collections;
using MoviesDAL.Models;
using MoviesDAL.EF;

namespace MovieLibrary.Movies
{
    public class MovieLib : IEnumerable<Movie>
    {
        private Dictionary<int, Movie> _ordinaryMovies = new Dictionary<int, Movie>();
        private Dictionary<int, Movie> _onlyAdultMovies = new Dictionary<int, Movie>();

        private TimeSpan _begin; 
        private TimeSpan _end; 

        /// <summary>
        /// Constructor to take movies from DB
        /// </summary>
        /// <param name="context">Db context to take movies from db</param>
        public MovieLib(MovieDbContext context)
        {
            foreach (var movie in context.Movies) 
            {
                if (movie.IsAdult)
                    _onlyAdultMovies.Add(movie.Id, movie);
                else
                    _ordinaryMovies.Add(movie.Id, movie);
            }

            _begin = TimeSpan.FromHours(7);
            _end = TimeSpan.FromHours(23);
        }

        public Movie? this[int article]
        {
            get => GetMovie(article);
        }

        /// <summary>
        /// Gets movie from appropriate article
        /// </summary>
        /// <param name="movieNum">Article of movie</param>
        /// <returns>Movie object from appropriate artcile. Returns null if it doesn't exist</returns>
        public Movie? GetMovie(int article)
        {
            if (!IsTimeToAllMovies())
            {
                if (_ordinaryMovies.ContainsKey(article))
                {
                    return _ordinaryMovies[article];
                }
            }
            else
            {
                if (_ordinaryMovies.ContainsKey(article))
                {
                    return _ordinaryMovies[article];
                }
                if (_onlyAdultMovies.ContainsKey(article))
                {
                    return _onlyAdultMovies[article];
                }
            }

            return null;
        }

        /// <summary>
        /// Checks the time and returns instructions on which movies can be shown
        /// </summary>
        /// <returns>True - if it's from 23:00 to 7:00. False - if it's from 7:00 to 23:00 </returns>
        private bool IsTimeToAllMovies()
        {
            var now = DateTime.Now.TimeOfDay;

            if (now >= _begin && now <= _end)
                return false;

            return true;
        }

        public IEnumerator<Movie> GetEnumerator()
        {
            if (!IsTimeToAllMovies())
            {
                return new MovieEnumerator(_ordinaryMovies.Values.ToList());
            }
            else
            {
                var allMovies = _ordinaryMovies.Values.ToList();
                allMovies.AddRange(_onlyAdultMovies.Values.ToList());
                return new MovieEnumerator(allMovies);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

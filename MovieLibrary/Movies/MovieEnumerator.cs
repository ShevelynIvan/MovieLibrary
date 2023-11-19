using System.Collections;

namespace MovieLibrary.Movies
{
    internal class MovieEnumerator : IEnumerator<string>
    {
        /// <summary>
        /// 1 array that contains all movies
        /// </summary>
        private string[] _movies;

        /// <summary>
        /// Number of movies
        /// </summary>
        private int _moviesLength;

        private int _position = -1;

        /// <summary>
        /// Checks arrays for null and creats from 2 arrays only 1 which contain only movies that can be shown
        /// </summary>
        /// <param name="ordinaryMovies">Array of ordinary movies</param>
        /// <param name="adultMovies">Array of adult movies</param>
        /// <param name="now">Now</param>
        /// <param name="begin">Start time to show only ordinary movies</param>
        /// <param name="end">From this time can be shown all movies until the begin time</param>
        public MovieEnumerator(string[] ordinaryMovies, string[] adultMovies, TimeSpan now, TimeSpan begin, TimeSpan end)
        {
            if (now >= begin && now <= end)
            {
                if (ordinaryMovies is null)
                    _moviesLength = 0;
                else
                {
                    _moviesLength = ordinaryMovies.Length;
                    _movies = ordinaryMovies;
                }
                return;
            }
            else
            {
                if (ordinaryMovies is not null && adultMovies is not null)
                {
                    _movies = ordinaryMovies.Concat(adultMovies).ToArray();
                    _moviesLength = ordinaryMovies.Length + adultMovies.Length;
                    return;
                }

                else if (ordinaryMovies is null && adultMovies is not null)
                {
                    _movies = adultMovies;
                    _moviesLength = adultMovies.Length;
                    return;
                }
                    
                else if (ordinaryMovies is not null && adultMovies is null)
                {
                    _movies = ordinaryMovies;
                    _moviesLength = ordinaryMovies.Length;
                    return;
                }

                else
                {
                    _moviesLength = 0;
                    return;
                }
            }
        }

        public string Current
        {
            get
            {
                if (_position == -1 || (_position >= _moviesLength))
                    throw new ArgumentException();
                return _movies[_position];
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_position < _moviesLength - 1)
            {
                _position++;
                return true;
            }
            else
                return false;
        }

        public void Reset() => _position = -1;

        public void Dispose() { }
    }
}

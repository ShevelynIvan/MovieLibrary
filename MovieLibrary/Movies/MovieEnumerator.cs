using System.Collections;
using MoviesDAL.Models;

namespace MovieLibrary.Movies
{
    internal class MovieEnumerator : IEnumerator<Movie>
    {
        private List<Movie> _movies = new List<Movie>();

        private int _position = -1;

        public MovieEnumerator(List<Movie> movies) => _movies = movies;

        public Movie Current
        {
            get => _movies.ElementAt(_position);
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            _position++;
            return (_position < _movies.Count);
        }

        public void Reset() => _position = -1;

        public void Dispose() { }
    }
}

namespace MovieLibrary.Movies
{
    public class MovieLib
    {
        private string[] _ordinaryMovies = { "1", "2", "3", "4" };
        private string[] _onlyAdultMovies = { "1a", "2a", "3a", "4a" };

        /// <summary>
        /// Number of all movies
        /// </summary>
        private int _length;

        private TimeSpan _begin; 
        private TimeSpan _end; 

        public MovieLib()
        {
            _length = _ordinaryMovies.Length + _onlyAdultMovies.Length;
            _begin = TimeSpan.FromHours(7);
            _end = TimeSpan.FromHours(23);
        }

        public string this[int index]
        {
            get
            {
                if (IsTimeToAllMovies())
                {
                    if (IsIndexOfAdultMovie(index))
                        return _onlyAdultMovies[index - _ordinaryMovies.Length];

                    else if (IsIndexNotOutOfOrdinaryMovies(index))
                        return _ordinaryMovies[index];

                    else
                        return "";
                }
                else
                {
                    if (IsIndexNotOutOfOrdinaryMovies(index))
                        return _ordinaryMovies[index];

                    else
                        return "";
                }
            }
            set
            {
                if (IsTimeToAllMovies())
                {
                    if (IsIndexOfAdultMovie(index))
                        _onlyAdultMovies[index - _ordinaryMovies.Length] = value;

                    else if (IsIndexNotOutOfOrdinaryMovies(index))
                        _ordinaryMovies[index] = value;
                }
                else
                {
                    if (IsIndexNotOutOfOrdinaryMovies(index))
                        _ordinaryMovies[index] = value;
                }
            }
        }

        /// <summary>
        /// Gets movie from appropriate index
        /// </summary>
        /// <param name="movieNum">Index of movie</param>
        /// <returns>String movie from appropriate index</returns>
        public string GetMovie(int movieNum)
        {
            if (IsTimeToAllMovies())
            {
                if (IsIndexOfAdultMovie(movieNum))
                    return _onlyAdultMovies[movieNum - _ordinaryMovies.Length];

                else if (IsIndexNotOutOfOrdinaryMovies(movieNum))
                    return _ordinaryMovies[movieNum];

                else
                    return "";
            }
            else
            {
                if (IsIndexNotOutOfOrdinaryMovies(movieNum))
                    return _ordinaryMovies[movieNum];

                else
                    return "";
            }
        }

        #region Validations
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

        /// <summary>
        /// Checks the index for membership to Adult movies
        /// </summary>
        /// <param name="index">Index of movie</param>
        /// <returns>True - if it's adult movie. False - if it isn't</returns>
        private bool IsIndexOfAdultMovie(int index)
        {
            if (index >= _ordinaryMovies.Length && index < _length)
                return true;
            
            return false;
        }

        /// <summary>
        /// Checks the index for membership to Ordinary movies
        /// </summary>
        /// <param name="index">Index of movie</param>
        /// <returns>True - if it's ordinary movie. False - if it isn't</returns>
        private bool IsIndexNotOutOfOrdinaryMovies(int index)
        {
            if ((index < _ordinaryMovies.Length) && (index >= 0))
                return true;

            return false;
        }
        #endregion

        public IEnumerator<string> GetEnumerator() 
            => new MovieEnumerator(_ordinaryMovies, _onlyAdultMovies, DateTime.Now.TimeOfDay, _begin, _end);
    }
}

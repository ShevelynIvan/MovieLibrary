using MovieLibrary.Movies;

namespace MovieClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieLib movieLib = new MovieLib();
            
            Console.WriteLine(movieLib.GetMovie(-2));
            Console.WriteLine(movieLib.GetMovie(4));
            Console.WriteLine(movieLib.GetMovie(0));
            Console.WriteLine(movieLib.GetMovie(1));

            movieLib[-2] = "-2";
            movieLib[5] = "555555";
            movieLib[1] = null;
            movieLib[10] = "100000";

            foreach (var item in movieLib)
            {
                Console.WriteLine($"Film: {item}");
            }
        }
    }
}
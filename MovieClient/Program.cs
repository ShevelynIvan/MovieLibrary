using Microsoft.EntityFrameworkCore.Update.Internal;
using MovieLibrary.Movies;
using MoviesDAL.EF;
using MoviesDAL.Models;

namespace MovieClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClearDB();
            AddMoviesToDB();
            //UpdateMovie();
            //DeleteMovie();

            using (MovieDbContext context = new MovieDbContext())
            {
                MovieLib movieLib = new MovieLib(context);
                var a = movieLib.GetMovie(2);
                foreach (var item in movieLib)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static void AddMoviesToDB()
        {
            Movie movie1 = new Movie()
            {
                Name = "movie1",
                IsAdult = true
            };
            Movie movie2 = new Movie()
            {
                Name = "movie2",
                IsAdult = false
            };
            Movie movie3 = new Movie()
            {
                Name = "movie3",
                IsAdult = true
            };
            Movie movie4 = new Movie()
            {
                Name = "movie4",
                IsAdult = false
            };
            Movie movie5 = new Movie()
            {
                Name = "movie5",
                IsAdult = false
            };
            Movie movie6 = new Movie()
            {
                Name = "movie6",
                IsAdult = false
            };
            Movie movie7 = new Movie()
            {
                Name = "movie7",
                IsAdult = false
            };
            Movie movie8 = new Movie()
            {
                Name = "movie8",
                IsAdult = true
            };
            Movie movie9 = new Movie()
            {
                Name = "movie9",
                IsAdult = false
            };

            using (MovieDbContext context = new MovieDbContext())
            {
                context.Movies.Add(movie1);
                context.Movies.Add(movie2);
                context.Movies.Add(movie3);
                context.Movies.Add(movie4);
                context.Movies.Add(movie5);
                context.Movies.Add(movie6);
                context.Movies.Add(movie7);
                context.Movies.Add(movie8);
                context.Movies.Add(movie9);
                context.SaveChanges();
            }
        }

        static void UpdateMovie()
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var movieToUpdate = context.Movies.FirstOrDefault();
                if (movieToUpdate is not null)
                {
                    movieToUpdate.Name = "Name was updated";
                    movieToUpdate.IsAdult = false;
                    context.Update(movieToUpdate);
                    context.SaveChanges();
                    Console.WriteLine($"Film with ID {movieToUpdate.Id} was changed.");
                }
            }
        }

        static void DeleteMovie()
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var movieToDelete = context.Movies.FirstOrDefault();
                if (movieToDelete is not null)
                {
                    context.Remove(movieToDelete);
                    context.SaveChanges();
                    Console.WriteLine($"Film: {movieToDelete.Name} was deleted from db.");
                }
            }
        }

        static void ClearDB()
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                context.RemoveRange(context.Movies);
                context.SaveChanges();
            }
        }
    }
}
using BlockBuster.Models;
using Microsoft.EntityFrameworkCore;

namespace BlockBuster
{
    public static class BasicFunctions
    {
        public static Movie? GetMovieById(int movieId)
        {
            using(var context = new Se407BlockBusterContext())
            {
                return context.Movies.Find(movieId);
            }
        }


        public static List<Movie> GetAllMovies()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context.Movies.ToList();
            }
        }


        public static List<Movie> GetCheckedOutMovies()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context
                        .Transactions
                        .Where(t => t.CheckedIn.Equals("N"))
                        .Join
                        (
                            context.Movies,
                            t => t.MovieId,
                            m => m.MovieId,
                            (t, m) => m
                        )
                        .ToList();
            }
        }
        public static List<Movie> GetMoviesByGenre(string genreDescription)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context
                    .Genres
                    .Where(g => g.GenreDescr == genreDescription)
                    .Join(
                    context.Movies,
                    g => g.GenreId,
                    m => m.GenreId,
                    (g, m) => m
                    )
                    .ToList();
            }
        }

        public static List<Movie> GetMoviesByDirectorLastName(string lastName)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context.Directors
                    .Where(d => d.LastName == lastName)
                    .Join(
                        context.Movies,
                        d => d.DirectorId,
                        m => m.DirectorId,
                        (d, m) => m
                    )
                    .ToList();
            }
        }
    }
}

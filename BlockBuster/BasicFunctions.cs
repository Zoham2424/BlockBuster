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

        public static List<Movie> GetAllMoviesWithDetails()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context
                        .Movies
                        .Include(movie => movie.Director)
                        .Include(movie => movie.Genre)
                        .ToList();

            }
        }

        public static Movie? GetMovieWithDetailsById(int movieId)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context
                        .Movies
                        .Include(movie => movie.Director)
                        .Include(movie => movie.Genre)
                        .FirstOrDefault(movie => movie.MovieId == movieId);
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

        public static List<Genre> GetAllGenres()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context.Genres.ToList();
            }
        }

        public static Genre? GetGenreById(int genreId)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context.Genres.FirstOrDefault(genre => genre.GenreId == genreId);
            }
        }

        public static List<Director> GetAllDirectors()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context.Directors.ToList();
            }
        }
        public static Director? GetDirectorById(int directorId)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context.Directors.FirstOrDefault(dir => dir.DirectorId == directorId);
            }
        }
        public static void UpdateMovie
       (
           int movieId,
           string updatedTitle,
           int updatedReleaseYear,
           Director updatedDirector,
           Genre updatedGenre
       )
        {
            using (var context = new Se407BlockBusterContext())
            {
                var movieToUpdate = GetMovieById(movieId);

                if (movieToUpdate != null)
                {
                    movieToUpdate.Title = updatedTitle;
                    movieToUpdate.ReleaseYear = updatedReleaseYear;
                    movieToUpdate.Director = updatedDirector;
                    movieToUpdate.Genre = updatedGenre;
                }

                context.Update(movieToUpdate);

                context.SaveChanges();
            }
        }
        public static void DeleteMovie(int id)
        {
            try
            {
                using (var db = new Se407BlockBusterContext())
                {
                    var movieToDelete = db.Movies.Find(id);
                    db.Movies.Remove(movieToDelete);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void EditMovie(Movie movie)
        {
            try
            {
                using (var db = new Se407BlockBusterContext())
                {
                    db.Movies.Update(movie);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}

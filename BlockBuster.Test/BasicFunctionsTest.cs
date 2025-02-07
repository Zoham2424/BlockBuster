using BlockBuster.Models;

namespace BlockBuster.Test
{
    public class BasicFunctionsTest
    {
        [Fact]
        public void TestGetMovieById()
        {
            Movie? testMovie = BasicFunctions.GetMovieById(14);
            Assert.Equal("The Godfather: Part II", testMovie?.Title);
        }


        [Fact]
        public void TestGetAllMovies()
        {
            int movieCount = BasicFunctions.GetAllMovies().Count;
            Assert.Equal(51, movieCount);
        }


        [Fact]
        public void TestGetCheckedOutMovies()
        {
            int checkedOutMoviesCount =
                BasicFunctions.GetCheckedOutMovies().Count;

            Assert.Equal(3, checkedOutMoviesCount);
        }
        [Fact]
        public void TestGetMoviesByGenre()
        {
            List<Movie> actionMovies = BasicFunctions.GetMoviesByGenre("Action");
            Assert.All(actionMovies, movie => Assert.Equal(
                5, movie.GenreId));     //replace this number depending on gen id
        }

        [Fact]
        public void TestGetMoviesByDirectorLastName()
        {
            List<Movie> ByDirecMovies = BasicFunctions.GetMoviesByDirectorLastName("Spielberg");
            Assert.All(ByDirecMovies, movie =>
            Assert.Equal(3, movie.DirectorId));  //replace this number depending on director id
        }
    }
}
using System;
using System.Collections.Generic;
using BlockBuster.Models;

namespace BlockBuster.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();


            Console.WriteLine("How would you like the output? (CSV or Console)");
            string outputType = Console.ReadLine()?.ToUpper();

            if (outputType != "CSV" && outputType != "CONSOLE")
            {
                Console.WriteLine("Invalid choice. Please enter CSV or Console.");
                return;
            }

            Console.WriteLine("Which function do you want to run? (GetAllMovies, GetMoviesByGenre, GetMoviesByDirectorLastName)");
            string function = Console.ReadLine();

            string parameter = "";
            if (function == "GetMoviesByGenre" || function == "GetMoviesByDirectorLastName")
            {
                Console.WriteLine("Enter the parameter (e.g., Genre name or Director's Last Name):");
                parameter = Console.ReadLine();
            }


            switch (function)
            {
                case "GetAllMovies":
                    movies = BasicFunctions.GetAllMovies();
                    break;
                case "GetMoviesByGenre":
                    movies = BasicFunctions.GetMoviesByGenre(parameter);
                    break;
                case "GetMoviesByDirectorLastName":
                    movies = BasicFunctions.GetMoviesByDirectorLastName(parameter);
                    break;
                default:
                    Console.WriteLine("Invalid function name.");
                    return;
            }

            if (movies.Count == 0)
            {
                Console.WriteLine("No movies found.");
                return;
            }

            if (outputType == "CSV")
                ConsoleUtils.WriteMoviesToCsv(movies);
            else
                ConsoleUtils.ListMovies(movies);
        }
    }
}

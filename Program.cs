using System;
using System.Collections.Generic;
using System.Linq;
using Lab10_movie_list.Properties;

namespace Lab10_movie_list
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            //Header statements
            Console.WriteLine("Welcome to the Movies List Application!");
            Console.WriteLine("");
            Console.WriteLine("There are 100 movies in this list.");

            //Get the list of Movies
            List<Movie> movies = GetListOfMovies();

            //Display logic
            DisplayListForUser(movies);

        }

        public static void DisplayListForUser(List<Movie> movies)
        {
            bool redo = false;
            string userInput = ""; 

            //Provide list based on user input
            do
            {
                //Get filtered list based on user input
                List<Movie> filteredlist = FilterListByCatagory(movies);

                foreach (var item in filteredlist)
                {
                    Console.WriteLine(item.Title);
                }

                bool inputerror = false;

                do
                {
                    Console.WriteLine("");
                    Console.WriteLine("Continue(y/n)?");

                    
                    userInput = Console.ReadLine();

                    if (!string.IsNullOrEmpty(userInput))
                    {
                        inputerror = true;
                        
                    }
                    else
                    {
                        Console.WriteLine("Sorry, your input is not valid. Try again.");
                        continue; 
                    }


                    if (userInput.Trim().ToLower() == "y")
                    {
                        //Do nothing. 
                    }
                    else
                    {
                        redo = true;
                    }
                } while (!inputerror);

            } while (!redo);

        }

        public static List<Movie> FilterListByCatagory(List<Movie> ListOfMovies)
        {
            bool inputerror = false;
            List<Movie> returnedfilteredMovieslist = new List<Movie>(); 
            do
            {
                int userInput;

                Console.WriteLine("What category are you interested in? (Animated = 1, Drama = 2, horror = 3, SciFi = 4)");
                bool successInput = int.TryParse(Console.ReadLine(), out userInput);

                if (successInput)
                {
                    inputerror = true;
                    List<Movie> filteredMovies = (List<Movie>)ListOfMovies
                                .Where(Movies => (int)Movies.Category == userInput) //Filters
                                .OrderBy(x => x.Title).ToList(); //Orders

                    returnedfilteredMovieslist = filteredMovies;
                }
                else
                {
                    Console.WriteLine("Sorry, your input is not valid. Try again.");
                    Console.WriteLine("");
                }

            } while (!inputerror);

            return returnedfilteredMovieslist;

        }

        public static List<Movie> GetListOfMovies()
        {
            List<Movie> movieList = new List<Movie>();
            movieList.Add(new Movie("Star Wars", MovieGenre.SciFi));
            movieList.Add(new Movie("Dune", MovieGenre.SciFi));
            movieList.Add(new Movie("Alien vs. Predator", MovieGenre.SciFi));
            movieList.Add(new Movie("IT", MovieGenre.horror));
            movieList.Add(new Movie("The Shining", MovieGenre.horror));
            movieList.Add(new Movie("Lion King", MovieGenre.Animated));
            movieList.Add(new Movie("Aladdin", MovieGenre.Animated));
            movieList.Add(new Movie("Rear Window", MovieGenre.Drama));
            movieList.Add(new Movie("Marriage Story", MovieGenre.Drama));
            movieList.Add(new Movie("Leave No Trace", MovieGenre.Drama));

            return movieList;
        }

    }
}

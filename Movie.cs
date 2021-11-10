using System;
using Lab10_movie_list.Properties;

namespace Lab10_movie_list
{
    public class Movie
    {

        private MovieGenre category;
        public MovieGenre Category
        {
            get { return category; }
            set { category = value; }
        }

        private string title; 
        public string Title
        {
            get { return title; }
            set { title = value; }
        }


        public Movie(string title, MovieGenre genre)
        {
            Title = title;
            Category = genre;
        }

    }
}

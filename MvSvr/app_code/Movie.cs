using System;
using System.Collections.Generic;
using System.Drawing;

namespace MvSvr {

    [Serializable()]

    public class Movie {

        // Attributes + Get Set
        private Image poster;
        public String Title { get; set; }
        public double Runtime { get; set; }
        public String Description { get; set; }
        public String Director { get; set; }
        public String Rating { get; set; }
        public String Genre { get; set; }
        public Image Poster { get; set; }
        public List<Show> Shows { get; set; }

        // https://msdn.microsoft.com/en-us/library/stf701f5(v=vs.110).aspx
        // e.Graphics.DrawImage(image2, 20.0F, 20.0F);

        // Constructors
        public Movie() { }
        public Movie(String title, String description, String genre, List<Show> shows) {
            Title = title;
            //Runtime = runtime;
            Description = description;
            Genre = genre;
            //Poster = poster;
            Shows = shows;
        }

        /*public Movie(String title, double runtime, String description,
                    String rating, String genre, Image poster, List<Show> shows)
        {
            Title = title;
            Runtime = runtime;
            Description = description;
            Rating = rating;
            Genre = genre;
            Poster = poster;
            Shows = shows;
        }   */

        public string toString()
        {
            return Title + " " + Genre;
        }
    }
}

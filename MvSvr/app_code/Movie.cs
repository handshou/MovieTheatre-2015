using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvSvr {
    class Movie {
        // Attributes
        private String title;
        private double runtime;
        private String description;
        private String rating;
        private String genre;
        private Image poster; // = Image.FromFile("poster\\the_dark_knight.jpg");
        private List<Show> shows;

        // https://msdn.microsoft.com/en-us/library/stf701f5(v=vs.110).aspx
        // e.Graphics.DrawImage(image2, 20.0F, 20.0F);

        // Constructors
        public Movie() { }
        public Movie(String title, double runtime, String description,
                    String rating, String genre, Image poster, List<Show> shows) {
            this.title = title;
            this.runtime = runtime;
            this.description = description;
            this.rating = rating;
            this.genre = genre;
            this.poster = poster;
            this.shows = shows;
        }

        // Get Set
        public String Title { get; set; }
        public double Runtime { get; set; }
        public String Description { get; set; }
        public String Rating { get; set; }
        public String Genre { get; set; }
        public Image Poster {
            get { return poster; }
            set { Image.FromFile(value.ToString()); }
        }
        
    }
}

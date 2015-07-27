using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MvSvr {
    [Serializable()]
    public class Movie {
        // Attributes + Get Set
        private Image poster;
        public String Title { get; set; }
        public double Runtime { get; set; }
        public String Description { get; set; }
        public String Rating { get; set; }
        public String Genre { get; set; }
        public Image Poster { // = Image.FromFile("poster\\the_dark_knight.jpg");
            get { return poster; }
            set { Image.FromFile(value.ToString()); }
        }
        public List<Show> Shows { get; set; }

        // https://msdn.microsoft.com/en-us/library/stf701f5(v=vs.110).aspx
        // e.Graphics.DrawImage(image2, 20.0F, 20.0F);

        // Constructors
        public Movie() { }
        public Movie(String title, double runtime, String description,
                    String rating, String genre, Image poster, List<Show> shows) {
            Title = title;
            Runtime = runtime;
            Description = description;
            Rating = rating;
            Genre = genre;
            Poster = poster;
            Shows = shows;
        }        
    }
}

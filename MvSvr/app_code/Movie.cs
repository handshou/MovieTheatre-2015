/* Windows Appliations Development Assignment
 * Hansel Chia: s10161147
 * Jack Chang: s10156590
 * This class covers the Movie object
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MvSvr {

    [Serializable()]

    public class Movie : IComparer<Show> {

        // Attributes + Get Set
        public String Title { get; set; }
        //public double Runtime { get; set; }
        public String Description { get; set; }
        public String Director { get; set; }
        //public String Rating { get; set; }
        public String Genre { get; set; }
        public Image Poster { get; set; }
        public List<Show> Shows { get; set; }

        // https://msdn.microsoft.com/en-us/library/stf701f5(v=vs.110).aspx
        // e.Graphics.DrawImage(image2, 20.0F, 20.0F);

        // Constructors
        public Movie() { }
        public Movie(String Title, String Description, String Director, 
            String Genre) {
            this.Title = Title;
            this.Description = Description;
            this.Director = Director;
            this.Genre = Genre;
            this.Shows = new List<Show>();
            this.Poster = Image.FromFile("poster\\no_image_available.png");
        }
        public Movie(String Title, String Description, String Director, 
            String Genre, List<Show> Shows, Image Poster) {
            this.Title = Title;
            this.Description = Description;
            this.Director = Director;
            this.Genre = Genre;
            this.Shows = Shows;
            this.Poster = Poster;
        }

        // Methods
        public List<Show> FindShows(int index) {
            // returns all shows that fall on given date by index
            List<Show> shows = new List<Show>();
            for (int i = 0; i < Shows.Count; i++) {
                String sdate = Shows[i].Date;
                if (sdate.Equals(GetDates()[index])) {
                    shows.Add(Shows[i]);
                }
            }
            shows.OrderBy(x => x.TimeStart);

            return shows;
        }
        public List<Show> FindShows(String date) {
            // returns all shows that fall on given date by date
            List<Show> shows = new List<Show>();
            for (int i = 0; i < Shows.Count; i++) {
                if (Shows[i].Date.ToLower().Equals(date)) {
                    shows.Add(Shows[i]);
                }
            }
            shows.OrderBy(x => x.TimeStart);

            return shows;
        }
        public List<String> GetDates() {
            List<String> showdates = new List<String>();
            foreach (Show s in Shows) {
                if (!showdates.Contains(s.Date))
                    showdates.Add(s.Date);
            }
            showdates.Sort();

            return showdates;
        }
        public List<String> FindShowTimes(String date) {
            List<String> showtimes = new List<String>();
            showtimes = new List<String>();
            for (int i = 0; i < Shows.Count; i++) {
                if (Shows[i].Date.Equals(date))
                    showtimes.Add(Shows[i].TimeStart);
            }
            showtimes.Sort();

            return showtimes;
        }
    }
}

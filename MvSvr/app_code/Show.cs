/* Windows Appliations Development Assignment
 * Hansel Chia: s10161147
 * Jack Chang: s10156590
 * This class covers the Show object
 */

using System;
using System.Collections.Generic;
using System.Globalization;

namespace MvSvr {
    [Serializable()]
    public class Show {
        // Attributes + Get Set
        public Movie Movie { get; set; }
        public String TimeStart { get; set; }
        public String TimeEnd { get; set; }
        public String Date { get; set; }
        public Hall Hall { get; set; }
        public double Price { get; set; }

        // Constructors
        public Show() { }

        public Show(Movie movie, String date, Hall hall, String timeStart, String timeEnd, double price) 
        {
            Movie = movie;
            Date = date;
            Hall = hall;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Price = price;
        }
    }
}

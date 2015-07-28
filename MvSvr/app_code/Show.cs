using System;
using System.Collections.Generic;
using System.Globalization;

namespace MvSvr {

    [Serializable()]

    public class Show {

        // Attributes + Get Set
        public Movie Movie { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public Calendar Date { get; set; }
        public Hall Hall { get; set; }
        public double Price { get; set; }
        public List<Booking> Bookings { get; set; }

        // Constructors
        public Show() { }
        public Show(Movie movie, Calendar date, Hall hall, DateTime timeStart,
                    DateTime timeEnd, double price, List<Booking> bookings) {
            Movie = movie;
            Date = date;
            Hall = hall;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Price = price;
            Bookings = bookings;
        }
    }
}

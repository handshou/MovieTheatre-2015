using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvSvr {
    class Show {
        // Attributes
        private Movie movie;
        private DateTime timeStart;
        private DateTime timeEnd;
        private Calendar date;
        private Hall hall;
        private double price;
        private List<Booking> bookings;

        // Constructors
        public Show() { }
        public Show(Movie movie, Calendar date, Hall hall, DateTime timeStart, 
                    DateTime timeEnd, double price, List<Booking> bookings) {
            this.date = date;
            this.hall = hall;
            this.timeStart = timeStart;
            this.timeEnd = timeEnd;
            this.price = price;
            this.bookings = bookings;
        }

        // Get Set
        public Movie Movie { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public Calendar Date { get; set; }
        public Hall Hall { get; set; }
        public double Price { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}

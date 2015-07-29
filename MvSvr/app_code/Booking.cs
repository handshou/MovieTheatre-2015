using System;
using System.Collections.Generic;

namespace MvSvr {

    [Serializable()]

    public class Booking {

        // Attributes + Get Set
        private static double fee = 1.50;
        public double Subtotal { get; set; }
        public String User { get; set; }
        public Show Show { get; set; }
        public List<Seat> Seats { get; set; }
        public DateTime BookingTime;

        // Constructors
        public Booking() { }
        public Booking(String user, Show show, List<Seat> seats) {
            User = user;
            Show = show;
            Seats = seats;
            BookingTime = DateTime.Now;
        }

        // Methods
        public double CalculateBaseCost() {
            return Show.Price * Seats.Count + fee;
        }

        public Hall GetHall() {
            return Show.Hall;
        }
    }
}

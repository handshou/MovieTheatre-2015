/* Windows Appliations Development Assignment
 * Hansel Chia: s10161147
 * Jack Chang: s10156590
 * This class covers the Booking object
 */

using System;
using System.Collections.Generic;

namespace MvSvr {

    [Serializable()]

    public class Booking {

        // Attributes + Get Set
        private static double fee = 1.50;
        //public double Subtotal { get; set; }
        public String User { get; set; }
        public Show Show { get; set; }
        public List<Seat> Seats { get; set; }
        public DateTime BookingTime;

        // Constructors
        public Booking() { }
        /// <summary>
        /// Creates a new ticket for booking - saving user's id, show and list of seats
        /// </summary>
        /// <param name="user">User identification</param>
        /// <param name="show">Show object</param>
        /// <param name="seats">List of Seats</param>
        public Booking(String user, Show show, List<Seat> seats) {
            User = user;
            Show = show;
            Seats = seats;
            BookingTime = DateTime.Now;
        }

        // Methods
        public double CalculateBaseCost(Boolean includeBookingFee) {
            if (includeBookingFee) {
                return Show.Price * Seats.Count + fee;
            } else
            return Show.Price * Seats.Count;
        }

        public Hall GetHall() {
            return Show.Hall;
        }

        public String ToString() {
            return User + " " + Show.Date + " " + Seats.ToString() ;
        }
    }
}

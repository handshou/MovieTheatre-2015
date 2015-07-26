using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvSysClient {
    class Booking {
        // Attributes + Get Set
        private static double fee = 1.50;
        public double Subtotal { get; set; }
        public int Id { get; set; }
        public Show Show { get; set; }
        public List<Seat> Seats { get; set; }

        // Constructors
        public Booking() { }
        public Booking(int id, Show show, List<Seat> seats) {
            Id = id;
            Show = show;
            Seats = seats;
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

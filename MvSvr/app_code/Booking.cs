using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvSvr {
    class Booking {
        // Attributes
        private double subtotal;
        private static double fee = 1.50;
        private int id;
        private Show show;
        private List<Seat> seats;

        // Constructors
        public Booking() { }
        public Booking(int id, Show show, List<Seat> seats) {
            this.id = id;
            this.show = show;
            this.seats = seats;
        }

        // Get Set
        public double Subtotal { get; set; }        
        public int Id { get; set; }
        public List<Seat> Seats { get; set; }

        // Methods
        public double CalculateBaseCost() {
            return show.Price * seats.Count + fee;
        }

        public Hall GetHall() {
            return show.Hall;
        }
    }
}

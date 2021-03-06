﻿/* Windows Appliations Development Assignment
 * Hansel Chia: s10161147
 * Jack Chang: s10156590
 * This class covers the Hall object
 */

using System;
using System.Collections.Generic;

namespace MvSvr {
    [Serializable()]
    public class Hall {
        // Attributes + Get Set
        private int capacity_max = 25;
        public String Name { get; set; }
        public List<Seat> Seats { get; set; }
        public int Capacity_Max {
            get { return capacity_max; }
            set { capacity_max = value; }
        }
        String[] seatNames =   {"A1", "A2", "A3", "A4", "A5",
                                "B1", "B2", "B3", "B4", "B5",
                                "C1", "C2", "C3", "C4", "C5",
                                "D1", "D2", "D3", "D4", "D5",
                                "E1", "E2", "E3", "E4", "E5"};

        // Constructors
        public Hall() {
            Seats = new List<Seat>();
            for (int i = 0; i < seatNames.Length; i++) {
                Seats.Add(new Seat(this, seatNames[i]));
            }
            Name = "";
        }

        public Hall(String name) {
            Seats = new List<Seat>();
            for (int i = 0; i < seatNames.Length; i++) {
                Seats.Add(new Seat(this, seatNames[i]));
            }
            Name = name;
        }

        // Methods
        public bool IsFull() {
            foreach(Seat seat in Seats){
                if (seat.Vacant)
                    return false;
            }
            return true;
        }

        public List<Seat> AvailableSeats() {
            List<Seat> avail = new List<Seat>();
            foreach (Seat seat in Seats) {
                if (seat.Vacant)
                    avail.Add(seat);
            }
            return avail;
        }
    }
}

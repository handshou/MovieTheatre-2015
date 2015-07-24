using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MvSvr {
    class Seat {
        // Attributes
        private Hall hall;
        private bool vacanct = true;
        private String name;
        private String row;
        private int num;

        // Constructors
        public Seat() { }
        public Seat(Hall hall, String row, int num) {
            this.hall = hall;
            this.row = row;
            this.num = num;
        }
        public Seat(Hall hall, String name) {    
            String p1 = @"^[a-zA-Z]";
            Regex r1 = new Regex(p1);
            String[] substrings = r1.Split(name);

            this.hall = hall;
            this.name = name;
            try {
                row = substrings[0];
                num = Convert.ToInt32(substrings[1]);
            } catch (FormatException) {
                row = "-";
                num = 0;
            } catch (IndexOutOfRangeException) {
                row = "-";
                num = 0;
            } catch (InvalidCastException) {
                row = "-";
                num = 0;
            }
        }

        // Get Set
        public bool Vacanct { get; set; }
        public String Name {
            get { return row + num; }
            set { Name = value; }
        }
        public String Row { get; set; }
        public int Num { get; set; }
        
    }
}

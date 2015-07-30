/* Windows Appliations Development Assignment
 * Hansel Chia: s10161147
 * Jack Chang: s10156590
 * This class covers the Seat object
 */

using System;
using System.Text.RegularExpressions;

namespace MvSvr {

    [Serializable()]

    public class Seat {

        // Attributes + Get Set
        private bool vacant = true;
        private String name;
        public Hall Hall { get; set; }
        public bool Vacant {
            get { return vacant; }
            set { vacant = value; }
        }
        public String Name {
            get { return Row + Num; }
            set { Name = value; }
        }
        public String Row { get; set; }
        public int Num { get; set; }

        // Constructors
        public Seat() { }
        public Seat(Hall hall, String row, int num) {
            Hall = hall;
            Row = row;
            Num = num;
        }
        public Seat(Hall hall, String name) {    
            //String p1 = @"^[a-zA-Z]";
            //Regex r1 = new Regex(p1);
            
            //String[] substrings = r1.Split(name);
            Hall = hall;
            this.name = name;
            try {
                Row = name.Substring(0, 1);
                Num = Convert.ToInt32(name.Substring(1, name.Length - 1));
            } catch (FormatException) {
                Row = "-";
                Num = 0;
            } catch (IndexOutOfRangeException) {
                Row = "-";
                Num = 0;
            } catch (InvalidCastException) {
                Row = "-";
                Num = 0;
            }
        }
    }
}

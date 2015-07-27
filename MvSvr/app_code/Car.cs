using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvSvr {
    [Serializable]
    public class Car {
        public string Name { get; set; }
        public int Number { get; set; }

        public Car() {
            Name = "Car name";
            Number = 1234;
        }
    }
}

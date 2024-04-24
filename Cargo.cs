using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoCLI
{
    class Cargo
    {
        private static int nextId = -1;

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string DeparturePlanet { get; set; }
        public string Destination { get; set; }
        public string Goods { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Cargo<{Date};{DeparturePlanet};{Destination};{Goods};{Quantity}>";
        }

        public string ToCSVLine()
        {
            return $"{Id};{Date};{DeparturePlanet};{Destination};{Goods};{Quantity}";
        }

        public static Cargo CreateFromLine(string line, char separator = ';')
        {
            string[] values = line.Split(separator);

            nextId++;
            return new Cargo()
            {
                Id = nextId,
                Date = DateTime.Parse(values[0]),
                DeparturePlanet = values[1],
                Destination = values[2],
                Goods = values[3],
                Quantity = int.Parse(values[4])
            };
        }
    }
}

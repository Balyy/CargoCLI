using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            CargoRepository.Path = "cargo.csv";

            List<Cargo> cargos = CargoRepository.FindAll();

            foreach (Cargo cargo in cargos)
            {
                Console.WriteLine(cargo);
            }

            Console.ReadKey();
        }
    }
}

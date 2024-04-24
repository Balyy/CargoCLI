using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CargoCLI
{
    class CargoRepository
    {
        public static string Path { get; set; }
        public static bool SkipHeader { get; set; } = false;
        public static char Separator { get; set; } = ';';

        public static List<Cargo> FindAll()
        {
            using (StreamReader reader = new StreamReader(Path))
            {
                if (SkipHeader)
                {
                    reader.ReadLine();
                }

                List<Cargo> cargos = new List<Cargo>();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Cargo cargo = Cargo.CreateFromLine(line, Separator);
                    cargos.Add(cargo);
                }

                return cargos;
            }
        }

        public static Cargo FindById(int id)
        {
            foreach (Cargo cargo in FindAll())
            {
                if (cargo.Id == id)
                {
                    return cargo;
                }
            }

            return null;
        }

        public static void Save(Cargo cargo)
        {
            List<Cargo> cargos = FindAll();
            cargos.Add(cargo);
            Cargo.nextId = -1;
            using (StreamWriter writer = new StreamWriter(Path))
            {
                foreach (var item in cargos)
                {
                    writer.WriteLine(item.ToCSVLine());
                }
            }
        }
    }
}

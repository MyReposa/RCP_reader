using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RCP_reader
{
    public class CSVParser
    {
        protected List<DzienPracy> firma1Records;
        protected List<DzienPracy> firma2Records;
        public void Parse(string file)
        {
            Console.WriteLine("Parsing started...");
            string[] allLines = File.ReadAllLines(file);

            foreach (string line in allLines)
            {
                string[] csvElements = line.Split(";");
                try
                {
                    GetDailyData(ParseSingleLine(csvElements));
                }
                catch (Exception error)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Something is wrong with entry \"{line}\" in file \"{file}\". {error.Message} This line will be ignored.\r\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

            }
            Console.WriteLine("Parsing of this file completed.\r\n");
        }

        protected virtual DzienPracy ParseSingleLine(string[] csvElements)
        {
            return null;
        }

        protected virtual void GetDailyData(DzienPracy entry)
        {

        }
    }
}

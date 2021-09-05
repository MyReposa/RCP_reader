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
            int errorsInFileCount = 0;

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
                    Console.Write($"ERROR: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"Entry \"{line}\" is invalid. {error.Message} This line will be ignored.");
                    errorsInFileCount++;
                }

            }
            Console.WriteLine("Parsing of this file completed.\r\n" +
                             $"Number of errors: {errorsInFileCount}\r\n");
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

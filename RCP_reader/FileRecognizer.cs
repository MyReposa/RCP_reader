using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RCP_reader
{
    public class FileRecognizer
    {
        string workingPath;
        DailyRCPData dailyRCPData;

        public FileRecognizer(DailyRCPData dailyRCPData)
        {
            this.dailyRCPData = dailyRCPData;
        }

        enum RCPType
        {
            firma1,
            firma2,
            invalid
        }

        public void GetWorkPath()
        {
            Console.WriteLine("CVS reader for RCP log files.\r\n\r\nPlease provide path to RCP SCV files:");
            string workingPath = Console.ReadLine();

            try
            {
                if (Directory.GetFiles(workingPath, "*.csv", SearchOption.AllDirectories).Length == 0)
                {
                    Console.WriteLine("Provided path contains no CSV files. Press any key to quit.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    this.workingPath = workingPath;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"{ error.Message} Press any key to quit.");
                Console.ReadKey();
                return;
            }

            ProcessFiles();
        }

        void ProcessFiles()
        {
            Console.WriteLine($"\r\nFile analysis started in directory (sub-dirs included):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{workingPath}\r\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            foreach (string file in Directory.GetFiles(workingPath, "*.csv", SearchOption.AllDirectories))
            {
                switch (Identify(file))
                {
                    case RCPType.firma1:
                        {
                            CSVParser_firma1 csvParser = new CSVParser_firma1(dailyRCPData);
                            csvParser.Parse(file);
                            break;

                        }

                    case RCPType.firma2:
                        {
                            CSVParser_firma2 csvParser = new CSVParser_firma2(dailyRCPData);
                            csvParser.Parse(file);
                            break;
                        }
                }
            }

            Console.Write($"All available files have been processed. Data has been stored in ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("DailyRCPData");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" object.\r\nPress any key to quit...");
            Console.ReadKey();
        }

        RCPType Identify(string fileName)
        {
            string firstLine = File.ReadLines(fileName).First();
            string[] CSVelements = firstLine.Split(';');

            if (CSVelements.Length == 5)
            {
                Console.WriteLine($"File \"{fileName}\" initially recognized as Firma1 type.\r\n");
                return RCPType.firma1;
            }

            else if (CSVelements.Length == 4)
            {
                Console.WriteLine($"File \"{fileName}\" initially recognized as Firma2 type.\r\n");
                return RCPType.firma2;
            }

            else
            {
                Console.WriteLine($"File \"{fileName}\" doesn't seem to match any known RCP pattern. This file will be ignored. Please verify.\r\n");
                return RCPType.invalid;
            }
        }

    }
}
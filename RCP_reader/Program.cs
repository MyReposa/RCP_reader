using System;
using System.Collections.Generic;

namespace RCP_reader
{
    class Program
    {
        static void Main(string[] args)
        {
            DailyRCPData dailyRCPData = new DailyRCPData(); //collected data is stored here

            FileRecognizer fileRecognizer = new FileRecognizer(dailyRCPData);
            fileRecognizer.GetWorkPath();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RCP_reader
{
    public class CSVParser_firma1 : CSVParser
    {
        public CSVParser_firma1(DailyRCPData dailyRCPData)
        {
            this.firma1Records = dailyRCPData.firma1Records;
        }
        protected override DzienPracy ParseSingleLine(string[] csvElements)
        {

            DzienPracy entry = new DzienPracy();
            entry.kodPracownika = csvElements[0].ToString();
            entry.data = DateTime.Parse(csvElements[1]);
            entry.godzinaWejscia = TimeSpan.Parse(csvElements[2]);
            entry.godzinaWyjscia = TimeSpan.Parse(csvElements[3]);

            return entry;
        }

        protected override void GetDailyData(DzienPracy entry)
        {
            bool alreadyExists = false;

            foreach (DzienPracy record in firma1Records)
            {
                if (record.kodPracownika == entry.kodPracownika)
                {
                    alreadyExists = true;
                    break;
                }
            }
            if (!alreadyExists)
                firma1Records.Add(entry);
        }
    }
}

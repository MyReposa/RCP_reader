using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RCP_reader
{
    public class CSVParser_firma2 : CSVParser
    {
        public CSVParser_firma2(DailyRCPData dailyRCPData)
        {
            this.firma2Records = dailyRCPData.firma2Records;
        }
        protected override DzienPracy ParseSingleLine(string[] csvElements)
        {

            DzienPracy entry = new DzienPracy();
            entry.kodPracownika = csvElements[0].ToString();
            entry.data = DateTime.Parse(csvElements[1]);

            if (csvElements[3] == "WE")
                entry.godzinaWejscia = TimeSpan.Parse(csvElements[2]);

            if (csvElements[3] == "WY")
                entry.godzinaWyjscia = TimeSpan.Parse(csvElements[2]);

            return entry;
        }
        protected override void GetDailyData(DzienPracy entry)
        {
            bool alreadyExists = false;

            for (int currentRecord = 0; currentRecord < firma2Records.Count; currentRecord++)
            {
                if (firma2Records[currentRecord].kodPracownika == entry.kodPracownika)
                {
                    alreadyExists = true;
                    if (firma2Records[currentRecord].godzinaWejscia == null && entry.godzinaWejscia != null)
                    {
                        firma2Records[currentRecord].godzinaWejscia = entry.godzinaWejscia;
                        break;
                    }

                    if (firma2Records[currentRecord].godzinaWyjscia == null && entry.godzinaWyjscia != null)
                    {
                        firma2Records[currentRecord].godzinaWyjscia = entry.godzinaWyjscia;
                        break;
                    }
                }
            }
            if (!alreadyExists)
                firma2Records.Add(entry);
        }
    }
}

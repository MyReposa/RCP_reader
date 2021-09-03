using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP_reader
{
    public class DailyRCPData
    {
        public List<DzienPracy> firma1Records { set; get; } = new List<DzienPracy>();
        public List<DzienPracy> firma2Records { set; get; } = new List<DzienPracy>();
    }
}

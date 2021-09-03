using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP_reader
{
    public class DzienPracy
    {
        public string kodPracownika { set; get; }
        public DateTime data { set; get; }
        public TimeSpan? godzinaWejscia { set; get; }
        public TimeSpan? godzinaWyjscia { set; get; }
    }
}

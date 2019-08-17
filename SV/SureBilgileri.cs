using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV
{
    public class SureBilgileri
    {
        public string zaman { get; set; }
        public string UNI_ID { get; set; }
        public SureBilgileri(string zmn,string ID)
        {
            zaman = zmn;
            UNI_ID = ID;
        }
    }
}

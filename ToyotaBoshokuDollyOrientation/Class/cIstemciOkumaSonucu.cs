using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaBoshokuDollyOrientation
{
    class cIstemciOkumaSonucu
    {

        public bool Basarili { get; private set; }

        public string Mesaj { get; private set; }

        public cIstemciOkumaSonucu(bool basarili, string mesaj = "")
        {
            Basarili = basarili;
            Mesaj = mesaj;
        }


    }
}

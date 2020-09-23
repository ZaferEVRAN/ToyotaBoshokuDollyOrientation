using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToyotaBoshokuDollyOrientation
{
    class cMesajlar
    {

        public void hata(Exception hata)
        {
            MessageBox.Show(hata.Message, "Hata Oluştu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        
    }
}

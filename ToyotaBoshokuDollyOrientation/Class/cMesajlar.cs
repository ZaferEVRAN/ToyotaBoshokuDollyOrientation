using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToyotaBoshokuDollyOrientation
{
    class cMesajlar
    {

        public void hata(Exception hata,string fonksiyon)
        {
            MessageBox.Show(hata.Message, string.Format("Hata Oluştu!-{0}",fonksiyon), MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToyotaBoshokuDollyOrientation
{
    public partial class frmRHKayitlar : Form
    {
        public frmRHKayitlar()
        {
            InitializeComponent();
        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            cGenel.frmMain.ViewForm(cGenel.frmAnasayfa);
        }
    }
}

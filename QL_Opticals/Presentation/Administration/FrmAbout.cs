using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QL_Opticals.Presentation.Administration
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
            InitFormStyle();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void InitFormStyle()
        {
            Utilities.clsApplication.InitForm(this);
            btnOk.Font = new Font("Arial Rounded MT", 12, FontStyle.Bold);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QL_Opticals.Presentation
{
    public partial class FrmDashboard : DevExpress.XtraEditors.XtraForm
    {
        public void FunPrevious()
        {

        }
        public void InitFormStyle()
        {
            Utilities.clsApplication.InitForm(this);
            
        }
        public FrmDashboard()
        {
            InitializeComponent();
            InitFormStyle();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            this.HScroll = false;
            this.VScroll = false;
            this.AutoScroll = false;
        }

        private void pnlDashboard_Paint(object sender, PaintEventArgs e)
        {
            this.HScroll = false;
            this.VScroll = false;
            this.AutoScroll = false;
        }

        private void FrmDashboard_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmDashboard_Enter(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.SendToBack();
            
        }

        private void dateEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void chartPendingJobs_Click(object sender, EventArgs e)
        {

        }
    }
}
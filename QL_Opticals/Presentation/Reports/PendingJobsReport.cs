using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QL_Opticals.Presentation.Reports
{
    public partial class PendingJobsReport : Form
    {

        #region "Declaration"
        #endregion

        #region "Constructor"
            public PendingJobsReport()
            {
                InitializeComponent();
            }
        #endregion

        #region "User Function"
            public void InitFormStyle()
            {
                Utilities.clsApplication.InitForm(this);
            }
            public void FunLoadCFL(int Left,int Top)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.DesktopLocation = new Point(Left + 15, Top + 15);
                this.ShowDialog();
            }

        #endregion

        #region "Events"
            private void PendingJobsReport_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }

            private void PendingJobsReport_Load(object sender, EventArgs e)
            {

            }
        #endregion
        

        
    }
}

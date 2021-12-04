using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Opticals.Presentation
{
    public partial class FrmGenSettings : Form
    {
        #region "Declaration"
        #endregion

        #region "User Function"
            public void FunPrevious()
            {

            }
            public FrmGenSettings()
            {
                InitializeComponent();
                InitFormStyle();
            }
            public void InitFormStyle()
            {
                Utilities.clsApplication.InitForm(this);
            }
        #endregion

        #region "Event"
            private void FrmGenSettings_Load(object sender, EventArgs e)
            {
                //LoadFormLookAndFeel();
            }

            private void gridControl1_Click(object sender, EventArgs e)
            {

            }

            private void FrmGenSettings_Enter(object sender, EventArgs e)
            {

            }

            private void FrmGenSettings_Resize(object sender, EventArgs e)
            {
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        #endregion


        
        
       
    }
}

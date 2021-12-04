using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QL_Opticals.Presentation.Master
{
    public partial class FrmCustomerList : DevExpress.XtraEditors.XtraForm, ICustomerList
    {

        #region "Declaration"
        #endregion

        #region "Constructor
            public FrmCustomerList()
            {
                InitializeComponent();
                InitFormStyle();
            }
        #endregion

        #region "Interface Functions"
            public void MovePreviousRecord() { }
            public void MoveNextRecord() { }
            public void MoveLastRecord() { }
            public void MoveFirstRecord() { }
            public void FindMode() { }
            public void AddMode() { }
            public void PrintLayout() { }
            public void PreviewLayout() { }
            public void RefreshRecord() { }
        #endregion

        #region "User Function"
            public void InitFormStyle()
            {
                Utilities.clsApplication.InitForm(this);
            }
        #endregion

        #region "Events"
        #endregion

    }
}
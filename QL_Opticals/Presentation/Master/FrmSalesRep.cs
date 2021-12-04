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
    public partial class FrmSalesRep : DevExpress.XtraEditors.XtraForm,ISalesRep
    {

        #region "Declaration"
            string strqry = "";
            DataTable dt = new DataTable();
            //int i = 0;
            //string oldsearch = "";
            //int oldsrow = 0;
        #endregion

        #region "Constructor"
            public FrmSalesRep()
            {
                InitializeComponent();
                InitFormStyle();
                dgvList.MultiSelect = false;
            }
        #endregion

        #region "Interface Functions"
            public void MovePreviousRecord() {
                if (dgvList.RowCount > 0)
                {
                    int currrow;
                    if (dgvList.CurrentRow.Index == 0)
                    {
                        currrow = dgvList.RowCount - 1;
                    }
                    else
                    {
                        currrow = dgvList.CurrentRow.Index - 1;
                    }
                    dgvList.Rows[currrow].Selected = true;
                    dgvList.CurrentCell = dgvList["QLKey", currrow];
                    QLLoadSelectedUser();
                    dgvList.Focus();
                }
            }
            public void MoveNextRecord() {
               
                if (dgvList.RowCount > 0)
                {
                    int currrow;
                    if (dgvList.CurrentRow.Index == dgvList.RowCount - 1)
                    {
                        currrow = 0;
                    }
                    else
                    {
                        currrow = dgvList.CurrentRow.Index + 1;
                    }
                    dgvList.Rows[currrow].Selected = true;
                    dgvList.CurrentCell = dgvList["QLKey", currrow];
                    QLLoadSelectedUser();
                    dgvList.Focus();
                }
            }
            public void MoveLastRecord() {

                if (dgvList.RowCount > 0)
                {
                    dgvList.Rows[dgvList.RowCount - 1].Selected = true;
                    dgvList.CurrentCell = dgvList["QLKey", dgvList.RowCount - 1];
                    QLLoadSelectedUser();
                    dgvList.Focus();
                }
            }
            public void MoveFirstRecord() {

                if (dgvList.RowCount > 0)
                {
                    dgvList.Rows[0].Selected = true;
                    dgvList.CurrentCell = dgvList["QLKey", 0];
                    QLLoadSelectedUser();
                    dgvList.Focus();
                }
            
            }
            public void FindMode() { }
            public void AddMode()
            {
                QLLoadData();
                QLClearData();
                QLClearError();
                txtCode.Focus();
            }
            public void PrintLayout() { }
            public void PreviewLayout() { }
            public void RefreshRecord() { }
        #endregion

        #region "User Function"
            public void InitFormStyle()
            {
                Utilities.clsApplication.InitForm(this);
                Utilities.clsApplication.RemoveStyle(btnSearch);
            }
            public bool QLSave()
            {
                try
                {
                    string ProcedureResult = "";
                    if (QLValidation() == true)
                    {
                        ProcedureResult = QLExecuteProcedure();
                        if (ProcedureResult == "SUCCESS")
                        {
                            Utilities.clsApplication.objUtil.SetAlert = "Info : Saved Successfully";
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Sales Rep Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show(this, ProcedureResult, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                    return false;
                }
                finally
                {

                }
            }
            public string QLExecuteProcedure()
            {
                try
                {
                    string srCode, srName, srPhoneNo, srbranch, srAddress, srEmail;

                    srCode = txtCode.Text.Trim();
                    srName = txtName.Text.Trim();
                    srbranch = txtBranch.Text.Trim();
                    srPhoneNo = txtPhoneNo.Text.Trim();
                    srEmail = txtEmail.Text.Trim();
                    srAddress = rtxtAddress.Text.Trim();


                    strqry = "exec CreOrUptSalesRep '" + srCode.ToUpper() + "','" + srName + "','" + srbranch + "','" + srPhoneNo + "','" + srEmail + "','" + srAddress + "'";

                    return Utilities.clsApplication.FunGetSingleValue(strqry);
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString().Trim();
                }

            }
            public bool QLValidation()
            {
                bool valflag = true;

                try
                {
                    if (txtCode.Text.Trim() == "")
                    {

                        lblerrSalesRepCode.ForeColor = Color.Red;
                        lblerrSalesRepCode.Text = "Enter Code";
                        valflag = false;
                    }
                    else
                        lblerrSalesRepCode.Text = "";

                    if (txtName.Text.Trim() == "")
                    {

                        lblerrSalesRepName.ForeColor = Color.Red;
                        lblerrSalesRepName.Text = "Enter Name";
                        valflag = false;
                    }
                    else
                        lblerrSalesRepName.Text = "";

                    if (txtBranch.Text.Trim() == "")
                    {

                        lblerrBranch.ForeColor = Color.Red;
                        lblerrBranch.Text = "Enter Branch";
                        valflag = false;
                    }
                    else
                        lblerrBranch.Text = "";

                    if (txtPhoneNo.Text.Trim() == "")
                    {
                         
                        lblerrPhoneNo.ForeColor = Color.Red;
                        lblerrPhoneNo.Text = "Enter Phone Number";
                        valflag = false;
                    }
                    else
                        lblerrPhoneNo.Text = "";

                    if (txtEmail.Text.Trim() == "")
                    {

                        lblerrEmail.ForeColor = Color.Red;
                        lblerrEmail.Text = "Enter Email";
                        valflag = false;
                    }
                    else
                        lblerrEmail.Text = "";

                    if (rtxtAddress.Text.Trim() == "")
                    {
                        lblerrAddress.ForeColor = Color.Red;
                        lblerrAddress.Text = "Enter Address";
                        valflag = false;
                    }
                    else
                        lblerrAddress.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    valflag = false;
                }

                return valflag;
            }
            public void QLLoadSelectedUser()
            {
                txtCode.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Code"].Value.ToString().Trim();
                txtName.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Name"].Value.ToString().Trim();
                txtPhoneNo.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Phone"].Value.ToString().Trim();
                rtxtAddress.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Adress"].Value.ToString().Trim();
                txtBranch.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Branch"].Value.ToString().Trim();
                txtEmail.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Email"].Value.ToString().Trim();
                txtCode.Enabled = false;
            }
            public void QLClearData()
            {
                txtCode.Enabled = true;
                txtCode.Text = "";
                txtName.Text = "";
                txtPhoneNo.Text = "";
                rtxtAddress.Text = "";
                txtEmail.Text = "";
                txtBranch.Text = "";
            }
            public void QLClearError()
            {
                lblerrAddress.Text = "";
                lblerrBranch.Text = "";
                lblerrEmail.Text = "";
                lblerrPhoneNo.Text = "";
                lblerrSalesRepCode.Text = "";
                lblerrSalesRepName.Text = "";
            }
            public void QLLoadData()
            {
                try
                {

                    dgvList.AllowUserToAddRows = false;
                    dgvList.AllowUserToDeleteRows = false;
                    dgvList.ReadOnly = true;
                    dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    strqry = " SELECT  [QLKey]";
                    strqry += " ,[Code]";
                    strqry += " ,[Name]";
                    strqry += " ,[Phone]";
                    strqry += " ,[Adress]";
                    strqry += " ,[Branch]";
                    strqry += " ,[Email]";

                    strqry += " FROM [QLSREP]";
                    if (dt != null)
                    {
                        dt = null;
                    }
                    dt = Utilities.clsApplication.FunFillDT(strqry);
                    if (dt.Rows.Count > 0)
                    {
                        dgvList.DataSource = dt;
                        dgvList.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }

        #endregion
           
        #region "Events"
            private void btnSave_Click(object sender, EventArgs e)
            {
                if (QLSave() == true)
                {
                    AddMode();
                }
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void FrmSalesRep_Load(object sender, EventArgs e)
            {
                AddMode();
            }

            private void FrmSalesRep_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.A)
                {
                    QLClearData();
                }
            }

            private void dgvList_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    QLLoadSelectedUser();
                }
                if (e.Control && e.KeyCode == Keys.Left)
                {
                    MovePreviousRecord();
                }
                if (e.Control && e.KeyCode == Keys.Right)
                {
                    MoveNextRecord();
                }
            }

            private void btnSearch_Click(object sender, EventArgs e)
            {
                QLLoadData();
            }

            private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                QLLoadSelectedUser();
            }

        #endregion

    }
}
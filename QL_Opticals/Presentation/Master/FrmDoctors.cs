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
    public partial class FrmDoctors : DevExpress.XtraEditors.XtraForm, IDoctors
    {

        #region "Declaration"
            string strqry = "";
            DataTable dt = new DataTable();
            //int i = 0;
            //string oldsearch = "";
            //int oldsrow = 0;
        #endregion

        #region "Constructor"
            public FrmDoctors()
            {
                InitializeComponent();
                InitFormStyle();
            }
        #endregion

        #region "Interface Functions"
            public void MovePreviousRecord() 
            {
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
            public void MoveNextRecord() 
            {
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
            public void MoveLastRecord() 
            {
                if (dgvList.RowCount > 0)
                {
                    dgvList.Rows[dgvList.RowCount - 1].Selected = true;
                    dgvList.CurrentCell = dgvList["QLKey", dgvList.RowCount - 1];
                    QLLoadSelectedUser();
                    dgvList.Focus();
                }
            }
            public void MoveFirstRecord() 
            {
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
                txtDoctorCode.Focus();
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
                Utilities.clsApplication.RemoveStyle(btnDoctorUpdate);
                dgvList.MultiSelect = false;
            }
            public string QLExecuteProcedure()
            {
                try
                {
                    string docCode, docName, docmobile, docphone, docAddress,docBranch,docHCode;

                    docCode = txtDoctorCode.Text.Trim();
                    docName = txtDoctorName.Text.Trim();
                    docphone = txtPhoneNo.Text.Trim();
                    docmobile = txtMobileNo.Text.Trim();
                    docAddress = rtxtAddress.Text.Trim();
                    docBranch = txtBranch.Text.Trim();
                    docHCode = txtbtnHospital.Text.Trim();

                    strqry = "exec CreOrUptDoctor '" + docCode.ToUpper() + "','" + docName + "','" + docphone + "','" + docmobile + "','" + docAddress + "','" + docBranch + "','" + docHCode + "'";

                    return Utilities.clsApplication.FunGetSingleValue(strqry);
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString().Trim();
                }
                finally
                {
                    GC.Collect();
                }
            }
            public bool QLValidation()
            {
                bool valflag = true;

                try
                {
                    if (txtDoctorCode.Text.Trim() == "")
                    {

                        lblerrDoctorCode.ForeColor = Color.Red;
                        lblerrDoctorCode.Text = "Enter Doctor Code";
                        valflag = false;
                    }
                    else
                        lblerrDoctorCode.Text = "";

                    if (txtDoctorName.Text.Trim() == "")
                    {

                        lblerrDoctorName.ForeColor = Color.Red;
                        lblerrDoctorName.Text = "Enter Doctor Name";
                        valflag = false;
                    }
                    else
                        lblerrDoctorName.Text = "";

                    if (txtPhoneNo.Text.Trim() == "")
                    {

                        lblerrPhoneNo.ForeColor = Color.Red;
                        lblerrPhoneNo.Text = "Enter Phone No";
                        valflag = false;
                    }
                    else
                        lblerrPhoneNo.Text = "";

                    if (txtMobileNo.Text.Trim() == "")
                    {

                        lblerrMobileNo.ForeColor = Color.Red;
                        lblerrMobileNo.Text = "Enter Mobile No";
                        valflag = false;
                    }
                    else
                        lblerrMobileNo.Text = "";

                    if (rtxtAddress.Text.Trim() == "")
                    {

                        lblerrAddress.ForeColor = Color.Red;
                        lblerrAddress.Text = "Enter Address";
                        valflag = false;
                    }
                    else
                        lblerrAddress.Text = "";

                    if (txtBranch.Text.Trim() == "")
                    {

                        lblerrBranch.ForeColor = Color.Red;
                        lblerrBranch.Text = "Enter Branch";
                        valflag = false;
                    }
                    else
                        lblerrBranch.Text = "";

                    if (txtbtnHospital.Text.Trim() == "")
                    {

                        lblerrHospital.ForeColor = Color.Red;
                        lblerrHospital.Text = "Select Hospital";
                        valflag = false;
                    }
                    else
                        lblerrHospital.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    valflag = false;
                }

                return valflag;
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
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Doctor Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            public void QLLoadSelectedUser()
            {
                txtDoctorCode.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Code"].Value.ToString().Trim();
                txtDoctorName.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Name"].Value.ToString().Trim();
                txtPhoneNo.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Phone"].Value.ToString().Trim();
                rtxtAddress.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Address"].Value.ToString().Trim();
                txtMobileNo.Text= dgvList.Rows[dgvList.CurrentRow.Index].Cells["Mobile"].Value.ToString().Trim();
                txtBranch.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Branch"].Value.ToString().Trim();
                txtbtnHospital.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["HCode"].Value.ToString().Trim();
                txtDoctorCode.Enabled = false;
                QLClearError();
            }
            public void QLClearData()
            {
                txtDoctorCode.Enabled = true;
                txtDoctorCode.Text = "";
                txtDoctorName.Text = "";
                txtPhoneNo.Text = "";
                rtxtAddress.Text = "";
                txtMobileNo.Text = "";
                txtBranch.Text = "";
                txtbtnHospital.Text = "";
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
                    strqry += " ,[Mobile]";
                    strqry += " ,[Address]";
                    strqry += " ,[Branch]";
                    strqry += " ,[HCode]";
                    strqry += " FROM [QLDOCR]";
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
            public void QLClearError()
            {
                lblerrDoctorCode.Text = "";
                lblerrDoctorName.Text = "";
                lblerrPhoneNo.Text = "";
                lblerrAddress.Text = "";
                lblerrMobileNo.Text = "";
                lblerrBranch.Text = "";
                lblerrHospital.Text = "";
            }
        #endregion

        #region "Events"
            private void FrmDoctors_Load(object sender, EventArgs e)
            {
                AddMode();
            }
            private void btnSave_Click(object sender, EventArgs e)
            {
                if (QLSave() == true)
                {
                    AddMode();
                }
            }
            private void dgvList_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    QLLoadSelectedUser();
                }
            }

            private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                QLLoadSelectedUser();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

        #endregion

    }
}
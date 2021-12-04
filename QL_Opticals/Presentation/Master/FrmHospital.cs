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
    public partial class FrmHospital : DevExpress.XtraEditors.XtraForm,IHospital
    {

        #region "Declaration"

            string strqry = "";
            DataTable dt = new DataTable();
            //int i = 0;
            //string oldsearch = "";
            //int oldsrow = 0;

        #endregion

        #region "Constructor"

            public FrmHospital()
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
                txtHospitalCode.Focus();
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
                dgvList.MultiSelect = false;
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
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Hospital Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    string hospCode, hospContactPerson, hospName, hospPhoneNo, hospFaxNo, hospAddress, hospEmail;

                    hospCode = txtHospitalCode.Text.Trim();
                    hospName = txtHospitalName.Text.Trim();
                    hospContactPerson = txtContactPerson.Text.Trim();
                    hospPhoneNo = txtPhoneNo.Text.Trim();
                    hospFaxNo = txtFaxNo.Text.Trim();
                    hospAddress = rtxtAddress.Text.Trim();
                    hospEmail = txtEmail.Text.Trim();

                    strqry = "exec CreOrUptHospital '" + hospCode.ToUpper() + "','" + hospName + "','" + hospContactPerson + "','" + hospPhoneNo + "','" + hospFaxNo + "','" + hospAddress + "','" + hospEmail + "'";

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
                    if (txtHospitalCode.Text.Trim() == "")
                    {

                        lblerrHospitalCode.ForeColor = Color.Red;
                        lblerrHospitalCode.Text = "Enter Hospital Code";
                        valflag = false;
                    }
                    else
                        lblerrHospitalCode.Text = "";

                    if (txtContactPerson.Text.Trim() == "")
                    {

                        lblerrContactPerson.ForeColor = Color.Red;
                        lblerrContactPerson.Text = "Enter Contact Person";
                        valflag = false;
                    }
                    else
                        lblerrContactPerson.Text = "";

                    if (txtHospitalName.Text.Trim() == "")
                    {

                        lblerrHospitalName.ForeColor = Color.Red;
                        lblerrHospitalName.Text = "Enter Hospital Name";
                        valflag = false;
                    }
                    else
                        lblerrHospitalName.Text = "";

                    if (txtPhoneNo.Text.Trim() == "")
                    {

                        lblerrPhoneNo.ForeColor = Color.Red;
                        lblerrPhoneNo.Text = "Enter Phone Number";
                        valflag = false;
                    }
                    else
                        lblerrPhoneNo.Text = "";

                    if (txtFaxNo.Text.Trim() == "")
                    {

                        lblerrFaxNo.ForeColor = Color.Red;
                        lblerrFaxNo.Text = "Enter Fax No";
                        valflag = false;
                    }
                    else
                        lblerrFaxNo.Text = "";

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

            public void QLClearData()
            {
                txtHospitalCode.Enabled = true;
                txtHospitalCode.Text = "";
                txtHospitalName.Text = "";
                txtPhoneNo.Text = "";
                rtxtAddress.Text = "";
                txtContactPerson.Text = "";
                txtFaxNo.Text = "";
                txtEmail.Text = "";
                txtHospitalCode.Text = "";
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
                    strqry += " ,[ContactPerson]";
                    strqry += " ,[Phone]";
                    strqry += " ,[FaxNo]";
                    strqry += " ,[Adress]";
                    strqry += " ,[Email]";
                    strqry += " FROM [QLHOSP]";

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
                lblerrAddress.Text = "";
                lblerrContactPerson.Text = "";
                lblerrEmail.Text = "";
                lblerrFaxNo.Text = "";
                lblerrHospitalCode.Text = "";
                lblerrHospitalName.Text = "";
                lblerrPhoneNo.Text = "";
            }
            
            public void QLLoadSelectedUser()
            {
                txtHospitalCode.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Code"].Value.ToString().Trim();
                txtHospitalName.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Name"].Value.ToString().Trim();
                txtPhoneNo.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Phone"].Value.ToString().Trim();
                rtxtAddress.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Adress"].Value.ToString().Trim();
                txtContactPerson.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["ContactPerson"].Value.ToString().Trim();
                txtFaxNo.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["FaxNo"].Value.ToString().Trim();
                txtEmail.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Email"].Value.ToString().Trim();
                txtHospitalCode.Enabled = false;
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
            private void FrmHospital_Load(object sender, EventArgs e)
            {
                AddMode();
            }
            private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                QLLoadSelectedUser();
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
            private void FrmHospital_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.A)
                {
                    QLClearData();
                }
            }
            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

        #endregion

    }
}
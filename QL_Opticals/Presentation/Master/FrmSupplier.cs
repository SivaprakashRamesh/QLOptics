using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QL_Opticals.Presentation.Master
{
    public partial class FrmSupplier : Form
    {
        #region "Declaration"
            string strqry = "";
            DataTable dt = new DataTable();
            //int i = 0;
            //string oldsearch = "";
            //int oldsrow = 0;
        #endregion

        #region "Constructor"
            public FrmSupplier()
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
        public void FindMode()
        {

        }
        public void AddMode()
        {
            QLLoadData();
            QLClearData();
            QLClearError();
            txtSuplCode.Focus();
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

        public string QLExecuteProcedure()
        {
            try
            {
                string suplCode, suplName, suplGroup, suplAddress, suplCity, suplState, suplPincode, suplMobile, suplEmail, suplDOB, suplAge;

                suplCode = txtSuplCode.Text.Trim();
                suplName = txtSuplName.Text.Trim();
                suplGroup = txtSuplGroup.Text.Trim();
                suplAddress = rtxtAddress.Text.Trim();
                suplCity = txtCity.Text.Trim();
                suplState = txtState.Text.Trim();
                suplPincode = txtPinCode.Text.Trim();
                suplMobile = txtMobile.Text.Trim();
                suplEmail = txtEmailid.Text.Trim();
                suplDOB = dateDOB.DateTime.ToString("yyyyMMdd");
                suplAge = txtAge.Text.Trim();
                strqry = "exec CreOrUptSupplier '" + suplCode.ToUpper() + "','" + suplName + "','" + suplGroup + "','" + suplAddress + "','" + suplCity + "','" + suplState + "','" + suplPincode + "','" + suplMobile + "','" + suplEmail + "','" + suplDOB + "'," + suplAge;

                return Utilities.clsApplication.FunGetSingleValue(strqry);
            }
            catch (Exception ex)
            {
                return ex.Message.ToString().Trim();
            }

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
                        XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Supplier Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool QLValidation()
        {
            bool valflag = true;

            try
            {
                if (txtSuplCode.Text.Trim() == "")
                {

                    lblerrSuplCode.ForeColor = Color.Red;
                    lblerrSuplCode.Text = "Enter Supplier Code";
                    valflag = false;
                }
                else
                    lblerrSuplCode.Text = "";

                if (txtSuplName.Text.Trim() == "")
                {

                    lblerrSuplName.ForeColor = Color.Red;
                    lblerrSuplName.Text = "Enter Supplier Name";
                    valflag = false;
                }
                else
                    lblerrSuplName.Text = "";

                if (txtSuplGroup.Text.Trim() == "")
                {

                    lblerrSuplGroup.ForeColor = Color.Red;
                    lblerrSuplGroup.Text = "Enter Supplier Group";
                    valflag = false;
                }
                else
                    lblerrSuplGroup.Text = "";

                if (rtxtAddress.Text.Trim() == "")
                {

                    lblerrAddress.ForeColor = Color.Red;
                    lblerrAddress.Text = "Enter Address";
                    valflag = false;
                }
                else
                    lblerrAddress.Text = "";

                if (txtCity.Text.Trim() == "")
                {


                    lblerrCity.ForeColor = Color.Red;
                    lblerrCity.Text = "Enter City";
                    valflag = false;
                }
                else
                    lblerrCity.Text = "";

                if (txtState.Text.Trim() == "")
                {

                    lblerrState.ForeColor = Color.Red;
                    lblerrState.Text = "Enter State";
                    valflag = false;
                }
                else
                    lblerrState.Text = "";

                if (txtPinCode.Text.Trim() == "")
                {

                    lblerrPinCode.ForeColor = Color.Red;
                    lblerrPinCode.Text = "Enter Pin Code";
                    valflag = false;
                }
                else
                    lblerrPinCode.Text = "";

                if (txtMobile.Text.Trim() == "")
                {

                    lblerrMobile.ForeColor = Color.Red;
                    lblerrMobile.Text = "Enter Mobile";
                    valflag = false;
                }
                else
                    lblerrMobile.Text = "";

                if (txtEmailid.Text.Trim() == "")
                {

                    lblerrEmailid.ForeColor = Color.Red;
                    lblerrEmailid.Text = "Enter Email Id";
                    valflag = false;
                }
                else
                    lblerrEmailid.Text = "";

                if (dateDOB.Text.Trim() == "")
                {

                    lblerrDOB.ForeColor = Color.Red;
                    lblerrDOB.Text = "Enter DOB";
                    valflag = false;
                }
                else
                    lblerrDOB.Text = "";

                if (txtAge.Text.Trim() == "")
                {

                    lblerrAge.ForeColor = Color.Red;
                    lblerrAge.Text = "Enter Age";
                    valflag = false;
                }
                else
                    lblerrAge.Text = "";

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
            txtSuplCode.Enabled = true;
            txtSuplCode.Text = "";
            txtSuplName.Text = "";
            txtSuplGroup.Text = "";
            rtxtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtPinCode.Text = "";
            txtMobile.Text = "";
            txtEmailid.Text = "";
            dateDOB.Text = "";
            txtAge.Text = "";
        }

        public void QLLoadData()
        {
            try
            {

                dgvList.AllowUserToAddRows = false;
                dgvList.AllowUserToDeleteRows = false;
                dgvList.ReadOnly = true;
                dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                strqry = " SELECT [QLKey]";
                strqry += " ,[Code]";
                strqry += " ,[Name]";
                strqry += " ,[Grp]";
                strqry += " ,[Adress]";
                strqry += " ,[City]";
                strqry += " ,[StateName]";
                strqry += " ,[Pin]";
                strqry += " ,[Mobile]";
                strqry += " ,[Email]";
                strqry += " ,[DOB]";
                strqry += " ,[Age]";
                strqry += " FROM [QLSUPL]";
                if (dt != null)
                {
                    dt = null;
                }
                dt = Utilities.clsApplication.FunFillDT(strqry);
                if (dt.Rows.Count > 0)
                {
                    dgvList.DataSource = dt;
                    //dgvList.Columns["UserPassword"].Visible = false;
                    //dgvList.Rows[0].Cells[0].Selected = true;
                    //QLLoadSelectedUser();
                    dgvList.Refresh();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        public void QLLoadSelectedUser()
        {
            txtSuplCode.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Code"].Value.ToString().Trim();
            txtSuplName.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Name"].Value.ToString().Trim();
            txtSuplGroup.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Grp"].Value.ToString().Trim();
            rtxtAddress.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Adress"].Value.ToString().Trim();
            txtCity.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["City"].Value.ToString().Trim();
            txtState.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["StateName"].Value.ToString().Trim();
            txtPinCode.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Pin"].Value.ToString().Trim();
            txtMobile.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Mobile"].Value.ToString().Trim();
            txtEmailid.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Email"].Value.ToString().Trim();
            dateDOB.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["DOB"].Value.ToString().Trim();
            txtAge.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Age"].Value.ToString().Trim();
            txtSuplCode.Enabled = false;
            QLClearError();
        }

        public void QLClearError()
        {
            lblerrSuplCode.Text = "";
            lblerrSuplName.Text = "";
            lblerrSuplGroup.Text = "";
            lblerrAddress.Text = "";
            lblerrCity.Text = "";
            lblerrState.Text = "";
            lblerrPinCode.Text = "";
            lblerrMobile.Text = "";
            lblerrEmailid.Text = "";
            lblerrDOB.Text = "";
            lblerrAge.Text = "";
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

        private void FrmSupplier_Load(object sender, EventArgs e)
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

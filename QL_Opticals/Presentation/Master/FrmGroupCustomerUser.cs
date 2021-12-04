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
    public partial class FrmGroupCustomerUser : DevExpress.XtraEditors.XtraForm, IGroupCustomerUser
    {

        #region "Declaration"
            string strqry = "";
            DataTable dt = new DataTable();
            //int i = 0;
            //string oldsearch = "";
            //int oldsrow = 0;
        #endregion

        #region "Constructor"
            public FrmGroupCustomerUser()
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
                cmbGroupType.Focus();
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
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Group Customer User Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    string grpType, grpCode, grpDesc, grpName, grpSubGrp, grpDispOrder, grpMaxDiscount;

                    grpType = cmbGroupType.Text.Trim();
                    grpCode = txtGroupCode.Text.Trim();
                    grpDesc = txtGroupDesc.Text.Trim();
                    grpName = txtGroupName.Text.Trim();
                    grpSubGrp = txtSubGroupOf.Text.Trim();
                    grpDispOrder = txtDispOrder.Text.Trim();
                    grpMaxDiscount = txtMaxDiscount.Text.Trim();

                    strqry = "exec CreOrUptGroup '" + grpType + "','" + grpCode.ToUpper() + "','" + grpDesc + "','" + grpName + "','" + grpSubGrp + "','" + grpDispOrder + "','" + grpMaxDiscount + "'";

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
                    if (cmbGroupType.Text.Trim() == "")
                    {

                        lblerrGroupType.ForeColor = Color.Red;
                        lblerrGroupType.Text = "Select Group Type";
                        valflag = false;
                    }
                    else
                        lblerrGroupType.Text = "";

                    if (txtGroupCode.Text.Trim() == "")
                    {

                        lblerrGroupCode.ForeColor = Color.Red;
                        lblerrGroupCode.Text = "Enter Group Code";
                        valflag = false;
                    }
                    else
                        lblerrGroupCode.Text = "";

                    if (txtGroupDesc.Text.Trim() == "")
                    {

                        lblerrGroupDesc.ForeColor = Color.Red;
                        lblerrGroupDesc.Text = "Enter Group Description";
                        valflag = false;
                    }
                    else
                        lblerrGroupDesc.Text = "";

                    if (txtGroupName.Text.Trim() == "")
                    {

                        lblerrGroupName.ForeColor = Color.Red;
                        lblerrGroupName.Text = "Enter Group Name";
                        valflag = false;
                    }
                    else
                        lblerrGroupName.Text = "";

                    /*if (txtSubGroupOf.Text.Trim() == "")
                    {

                        lblerrSubGroupOf.ForeColor = Color.Red;
                        lblerrSubGroupOf.Text = "Enter Sub Group of";
                        valflag = false;
                    }
                    else
                        lblerrSubGroupOf.Text = "";*/

                    if (txtDispOrder.Text.Trim() == "")
                    {

                        lblerrDisplayOrder.ForeColor = Color.Red;
                        lblerrDisplayOrder.Text = "Enter Display Order";
                        valflag = false;
                    }
                    else
                        lblerrDisplayOrder.Text = "";

                    if (txtMaxDiscount.Text.Trim() == "")
                    {

                        lblerrMaxDiscount.ForeColor = Color.Red;
                        lblerrMaxDiscount.Text = "Enter Max Discount";
                        valflag = false;
                    }
                    else
                        lblerrMaxDiscount.Text = "";

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
                cmbGroupType.SelectedItem = null;
                cmbGroupType.SelectedItem = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Code"].Value.ToString().Trim();
                txtGroupCode.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Types"].Value.ToString().Trim();
                txtGroupDesc.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Descrip"].Value.ToString().Trim();
                txtGroupName.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Name"].Value.ToString().Trim();
                txtSubGroupOf.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SubGroup"].Value.ToString().Trim();
                txtDispOrder.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["DisplayOrder"].Value.ToString().Trim();
                txtMaxDiscount.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["MaxDiscount"].Value.ToString().Trim();
                cmbGroupType.Enabled = false;
            }

            public void QLClearData()
            {
                cmbGroupType.Enabled = true;
                cmbGroupType.SelectedItem = null;
                txtGroupCode.Text = "";
                txtGroupDesc.Text = "";
                txtGroupName.Text = "";
                txtSubGroupOf.Text = "";
                txtDispOrder.Text = "";
                txtMaxDiscount.Text = "0";
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
                    strqry += " ,[Types]";
                    strqry += " ,[Descrip]";
                    strqry += " ,[Name]";
                    strqry += " ,[SubGroup]";
                    strqry += " ,[DisplayOrder]";
                    strqry += " ,[MaxDiscount]";

                    strqry += " FROM [QLOGRP]";
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
                lblerrDisplayOrder.Text = "";
                lblerrGroupCode.Text = "";
                lblerrGroupDesc.Text = "";
                lblerrGroupName.Text = "";
                lblerrGroupType.Text = "";
                lblerrMaxDiscount.Text = "";
                lblerrSubGroupOf.Text = "";
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

            private void FrmGroupCustomerUser_Load(object sender, EventArgs e)
            {
                AddMode();
            }

            private void FrmGroupCustomerUser_KeyDown(object sender, KeyEventArgs e)
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
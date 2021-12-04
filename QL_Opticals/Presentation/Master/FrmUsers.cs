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
    public partial class FrmUsers : DevExpress.XtraEditors.XtraForm, IUsers
    {
        #region "Declarations"
            string strqry = "";
            DataTable dt = new DataTable();
            //int i  = 0;
            string oldsearch = "";
            int oldsrow = 0;
            //DialogResult fdResult = new DialogResult();
        #endregion

        #region "Constructor"
            public FrmUsers()
            {
                InitializeComponent();
                InitFormStyle();
            }
        #endregion

        #region "Interface Functions"
            public void MovePreviousRecord() 
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
                dgvList.CurrentCell = dgvList["UserName", currrow];
                QLLoadSelectedUser();
            }
            public void MoveNextRecord() 
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
                dgvList.CurrentCell = dgvList["UserName", currrow];
                QLLoadSelectedUser();
            }
            public void MoveLastRecord() 
            {
                dgvList.Rows[dgvList.RowCount - 1].Selected = true;
                dgvList.CurrentCell = dgvList["UserName", dgvList.RowCount - 1];
                QLLoadSelectedUser();
            }
            public void MoveFirstRecord() 
            {
                dgvList.Rows[0].Selected = true;
                dgvList.CurrentCell = dgvList["UserName", 0];
                QLLoadSelectedUser();
            }
            public void FindMode() 
            {
                
            }
            public void AddMode() 
            {
                QLClearData();
                QLLoadData();
                QLClearError();
                txtUserID.Focus();
            }
            public void PrintLayout() { }
            public void PreviewLayout() { }
            public void RefreshRecord() { }
        #endregion

        #region "User Functions"
            
            public string QLExecuteProcedure()
            {
                string UserId, UserName, Password, UserType, Branch;
                UserId = txtUserID.Text.Trim();
                UserName = txtUserName.Text.Trim();
                Password = Base64Encode(txtPassword.Text.Trim());
                UserType = cmbUserType.Text.Trim();
                Branch = txtBranch.Text.Trim();
                strqry = "exec CreOrUptUser '" + UserId.ToUpper() + "','" + UserName + "','" + Password + "','" + UserType + "','" +Branch + "'";

                return Utilities.clsApplication.FunGetSingleValue(strqry);
            }
            public void QLLoadData()
            {
                try
                {
                    dgvList.AllowUserToAddRows = false;
                    dgvList.AllowUserToDeleteRows = false;
                    dgvList.ReadOnly = true;
                    dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    strqry = "SELECT \"QLKey\",\"UserID\",\"UserName\" ,\"UserPassword\",\"UserType\",\"Branch\" FROM \"QLUSER\"";
                    if (dt != null)
                    {
                        dt = null;
                    }
                    dt = Utilities.clsApplication.FunFillDT(strqry);
                    if (dt.Rows.Count > 0)
                    {
                        dgvList.DataSource = dt;
                        dgvList.Columns["UserPassword"].Visible = false;
                        dgvList.Rows[0].Cells[0].Selected = true;
                        QLLoadSelectedUser();
                        dgvList.Refresh();
                    }
                    
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
            public void LoadUserCombo()
            {
                try
                {
                    strqry = "Select 'Normal' as \"GroupType\"  Union  Select 'Administrative' as \"GroupType\"  Union  Select 'Others' as \"GroupType\" ";
                    dt = Utilities.clsApplication.FunFillDT(strqry);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string str = Convert.ToString(dt.Rows[i][0]);
                        cmbUserType.Properties.Items.Add(str);
                    }
                    cmbUserType.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
            public void QLLoadSelectedUser()
            {
                txtUserID.Text  = dgvList.Rows[dgvList.CurrentRow.Index].Cells["UserID"].Value.ToString().Trim();
                txtUserName.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["UserName"].Value.ToString().Trim();
                txtPassword.Text = Base64Decode(dgvList.Rows[dgvList.CurrentRow.Index].Cells["UserPassword"].Value.ToString().Trim());
                txtConPassword.Text = txtPassword.Text;
                cmbUserType.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["UserType"].Value.ToString().Trim();
                txtBranch.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Branch"].Value.ToString().Trim();
                txtUserID.Enabled = false;
            }
            public bool Validation()
            {
                bool valflag = true;
                
                try
                {
                    if (txtUserID.Text.Trim() == "")
                    {
                        lblerrUserID.ForeColor = Color.Red;
                        lblerrUserID.Text = "Enter User ID";
                        valflag = false;
                    }
                    else
                        lblerrUserID.Text = "";

                    if ( txtUserName.Text.Trim() == "")
                    {
                        lblerrUserName.ForeColor = Color.Red;
                        lblerrUserName.Text = "Enter User Name";
                        valflag = false;
                    }
                    else
                        lblerrUserName.Text = "";

                    if (txtPassword.Text.Trim() == "")
                    {
                        lblerrPassword.ForeColor = Color.Red;
                        lblerrPassword.Text = "Enter Password";
                        valflag = false;
                    }
                    else
                    {
                        lblerrPassword.Text = "";

                        if (txtConPassword.Text.Trim() != txtPassword.Text.Trim())
                        {
                            lblerrConPassword.ForeColor = Color.Red;
                            lblerrConPassword.Text = "Confirm Password Must Match";
                            valflag = false;
                        }
                        else
                            lblerrConPassword.Text = "";
                    }

                    if (cmbUserType.Text.Trim() == "")
                    {
                        lblerrUserType.ForeColor = Color.Red;
                        lblerrUserType.Text = "Select User Type";
                        valflag = false;
                    }
                    else
                        lblerrUserType.Text = "";

                    //if (txtBranch.Text.Trim() == "")
                    //{
                    //    lblerrBranch.ForeColor = Color.Red;
                    //    lblerrBranch.Text = "Select Branch";
                    //    valflag = false;
                    //}
                    //else
                    //    lblerrUserType.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    valflag = false;
                }

                return valflag;
            }
            public void InitFormStyle()
            {
                Utilities.clsApplication.InitForm(this);
                Utilities.clsApplication.RemoveStyle(btnSearch);
                dgvList.MultiSelect = false;
                LoadUserCombo();
            }
            public static string Base64Encode(string plainText)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                return System.Convert.ToBase64String(plainTextBytes);
            }
            public static string Base64Decode(string base64EncodedData)
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            public void FunSearch()
            {
                try
                {
                    if (txtSearch.Text != oldsearch)
                    {
                        oldsrow = 0;
                    }

                    if (oldsrow == dgvList.RowCount)
                    {
                        oldsearch = "";
                    }

                    if (txtSearch.Text.Trim() != "")
                    {
                        for (int i = oldsrow; i < dgvList.RowCount; i++)
                        {
                            if (dgvList.Rows[i].Cells["UserName"].Value.ToString().Trim().ToLower().Contains(txtSearch.Text.Trim().ToLower()))
                            {
                                dgvList.Rows[i].Selected = true;
                                dgvList.CurrentCell = dgvList["UserName", i];
                                oldsearch = txtSearch.Text;
                                oldsrow = i + 1;
                                break;
                            }
                            else
                            {
                                dgvList.CurrentCell = null;
                            }
                        }
                    }
                    else
                    {
                        dgvList.CurrentCell = null;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Search User");
                }

            }
            public bool QLSave()
            {
                try
                {
                    string ProcedureResult = "";
                    if (Validation() == true)
                    {
                        ProcedureResult = QLExecuteProcedure();
                        if (ProcedureResult == "SUCCESS")
                        {
                            Utilities.clsApplication.objUtil.SetAlert = "Info : Saved Successfully";
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "User Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            public void QLClearData()
            {
                txtBranch.Text = "";
                txtConPassword.Text = "";
                txtPassword.Text = "";
                txtSearch.Text = "";
                txtUserID.Text = "";
                txtUserName.Text = "";

            }
            public void QLClearError()
            {
                lblerrUserID.Text = "";
                lblerrUserName.Text = "";
                lblerrPassword.Text = "";
                lblerrConPassword.Text = "";
                lblerrBranch.Text = "";
                lblerrUserType.Text = "";
            }
        #endregion

        #region "Events"
            
            private void FrmUsers_Load(object sender, EventArgs e)
            {
                
                AddMode();
            }
            
            private void btnSave_Click(object sender, EventArgs e)
            {
                if(QLSave())
                {
                    AddMode();
                }
            }

            private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                QLLoadSelectedUser();
                QLClearError();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void dgvList_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    QLLoadSelectedUser();
                }
            }
        #endregion

    }
}
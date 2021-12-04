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
using DevExpress.XtraEditors.Controls;
using System.Data.SqlClient;

namespace QL_Opticals.Presentation
{
    

    public partial class FrmUtil : DevExpress.XtraEditors.XtraForm, Administration.IUtil 
    {
        #region "Declaration"

            string strqry = "";
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DialogResult fdResult = new DialogResult();

        #endregion

        #region "Constructor"
            public FrmUtil()
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
                    FunLoadSelectedUser();
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
                    FunLoadSelectedUser();
                    dgvList.Focus();
                }
            }
            public void MoveLastRecord() 
            {
                if (dgvList.RowCount > 0)
                {
                    dgvList.Rows[dgvList.RowCount - 1].Selected = true;
                    dgvList.CurrentCell = dgvList["QLKey", dgvList.RowCount - 1];
                    FunLoadSelectedUser();
                    dgvList.Focus();
                }
            }
            public void MoveFirstRecord() 
            {
                if (dgvList.RowCount > 0)
                {
                    dgvList.Rows[0].Selected = true;
                    dgvList.CurrentCell = dgvList["QLKey", 0];
                    FunLoadSelectedUser();
                    dgvList.Focus();
                }
            }
            public void FindMode() 
            {
                
            }
            public void AddMode() 
            {
                cmbUser.SelectedIndex = 0;
                Utilities.clsApplication.FunDefaultStyle();
                cpBackColor.Color = Utilities.clsApplication.objUtil.BackColor;
                cpForeColor.Color = Utilities.clsApplication.objUtil.ForeColor;
                cpBorderColor.Color = Utilities.clsApplication.objUtil.BorderColor;
                ebtnFontFamily.Font = Utilities.clsApplication.objUtil.FontFont;
                LoadUtilGrid();

            }
            public void PrintLayout() { }
            public void PreviewLayout() { }
            public void RefreshRecord() { }

        #endregion

        #region "User Function"

            public string FunExecuteProcedure()
            {
                string usercode, bkcolor, forecolor, focuscolor, bordercolor, fontfamily, fontname, fontstyle, fontsize;
                usercode = cmbUser.Text.ToString().Trim();
                bkcolor = System.Drawing.ColorTranslator.ToHtml(cpBackColor.Color).Trim();
                forecolor = System.Drawing.ColorTranslator.ToHtml(cpForeColor.Color).Trim();
                focuscolor = System.Drawing.ColorTranslator.ToHtml(cpBorderColor.Color).Trim();
                bordercolor = System.Drawing.ColorTranslator.ToHtml(cpBorderColor.Color).Trim();
                fontfamily = fdialogUtil.Font.ToString().Trim();
                fontname = fdialogUtil.Font.Name.ToString().Trim();
                fontstyle = fdialogUtil.Font.Style.ToString().Trim();
                fontsize = fdialogUtil.Font.Size.ToString().Trim();
                strqry = "exec CreOrUptUtilty '" + usercode + "','" + bkcolor + "','" + forecolor + "','" + focuscolor + "','" + bordercolor + "','" + fontfamily + "','" + fontname + "','" + fontstyle + "'," + fontsize;
                
                return Utilities.clsApplication.FunGetSingleValue(strqry);

                //SqlParameter param2 = new SqlParameter();
                //SqlConnection Connection1 = new SqlConnection();
                //SqlCommand cmd = new SqlCommand();
                //Connection1 = new SqlConnection(Utilities.clsApplication.ConnectionString);
                //Connection1.Open();
                //cmd = new SqlCommand();
                //cmd.Connection = Connection1;
                //cmd.CommandText = strqry;//"CreOrUptUtilty";
                ////cmd.CommandType = CommandType.StoredProcedure;
                ////cmd.Parameters.Add("@UserCode", SqlDbType.NVarChar).Value = usercode;
                ////cmd.Parameters.Add("@BackColor", SqlDbType.NVarChar).Value = bkcolor;
                ////cmd.Parameters.Add("@ForeColor", SqlDbType.NVarChar).Value = forecolor;
                ////cmd.Parameters.Add("@FocusColor", SqlDbType.NVarChar).Value = focuscolor;
                ////cmd.Parameters.Add("@BorderColor", SqlDbType.NVarChar).Value = bordercolor;
                ////cmd.Parameters.Add("@FontFamily", SqlDbType.NVarChar).Value = fontfamily;
                ////cmd.Parameters.Add("@FontName", SqlDbType.NVarChar).Value = fontname;
                ////cmd.Parameters.Add("@FontStyle", SqlDbType.NVarChar).Value = fontstyle;
                ////cmd.Parameters.Add("@FontSize", SqlDbType.Int).Value = fontsize;
                //SqlDataAdapter DataAdapter1 = new SqlDataAdapter(cmd);
                //if (dt != null) { dt = null; }
                //dt = new DataTable();
                //DataAdapter1.Fill(dt);

                //return dt.Rows[0][0].ToString().Trim();
            }

            public bool Validation(){
                try
                {
                    bool valflag = true;
                    var color = cpBackColor.Color;

                    if (cmbUser.Text.ToString().Trim() == "")
                    {
                        lblerrUser.ForeColor = Color.Red;
                        lblerrUser.Text = "Select User Code";
                        valflag = false;
                    }
                    else
                        lblerrUser.Text = "";

                    if (cpBackColor.Color.ToString() == "Color [Empty]")
                    {
                        lblerrBackColor.ForeColor = Color.Red;
                        lblerrBackColor.Text = "Select Back Color";
                        valflag = false;
                    }
                    else
                        lblerrBackColor.Text = "";
                    if (cpForeColor.Color.ToString() == "Color [Empty]")
                    {

                        lblerrForeColor.ForeColor = Color.Red;
                        lblerrForeColor.Text = "Select Fore Color";
                        valflag = false;
                    }
                    else
                        lblerrForeColor.Text = "";
                    if (cpBorderColor.Color.ToString() == "Color [Empty]")
                    {
                        lblerrBorderColor.ForeColor = Color.Red;
                        lblerrBorderColor.Text = "Select Border Color";
                        valflag = false;
                    }
                    else
                        lblerrBorderColor.Text = "";
                    if (ebtnFontFamily.Text.ToString() == "")
                    {
                        lblerrFont.ForeColor = Color.Red;
                        lblerrFont.Text = "Select Font";
                        valflag = false;
                    }
                    else
                        lblerrFont.Text = "";
                    
                    return valflag;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return false;
                }
               
            }
            
            public void InitFormStyle()
            {
                Utilities.clsApplication.InitForm(this);
                cpBackColor.Color = Utilities.clsApplication.objUtil.BackColor;
                cpForeColor.Color = Utilities.clsApplication.objUtil.ForeColor;
                cpBorderColor.Color = Utilities.clsApplication.objUtil.BorderColor;
                ebtnFontFamily.Text = Utilities.clsApplication.objUtil.FontFont.ToString().Trim();
                fdialogUtil.Font = Utilities.clsApplication.objUtil.FontFont;
                ebtnFontFamily.Properties.ReadOnly = true;
                Utilities.clsApplication.RemoveStyle(btnSearch);
            }

            public void LoadUsersCombo()
            {
                try
                {
                    strqry = "select * from (";
                    strqry += "select '' 'User'";
                    strqry += "Union ";
                    strqry += "select Concat(\"UserID\" , CONCAT(' - ', \"UserType\")) 'User' from QLUSER";
                    strqry += ") a";
                    dt1 = Utilities.clsApplication.FunFillDT(strqry);
                    for (int i = 0; i < dt1.Rows.Count; i++ )
                    {
                        string str = Convert.ToString(dt1.Rows[i][0]);
                        cmbUser.Properties.Items.Add(str);
                    }
                    cmbUser.SelectedIndex = 0;
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
            
            public void LoadUtilGrid()
            {
                try
                {
                    strqry = "select \"UserID\" as \"Util Code\", \"BackColor\" as \"Back Color\", \"ForeColor\" as \"Fore Color\", \"BorderColor\" as \"Border Color\",\"FontFamily\" as \"Font\" from QLUTIL as \"T0\"";
                    if (dt != null)
                    {
                        dt = null;
                    }
                    dt = Utilities.clsApplication.FunFillDT(strqry);
                    if (dt.Rows.Count > 0)
                    {
                        dgvList.DataSource = dt;
                        dgvList.Refresh();
                        dgvList.Rows[0].Cells[0].Selected = true;
                        
                    }
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }

            public void FunLoadSelectedUser()
            {
                cmbUser.SelectedIndex = dgvList.CurrentRow.Index;
                cmbUser.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Util Code"].Value.ToString().Trim();
                cpBackColor.Color = System.Drawing.ColorTranslator.FromHtml(dgvList.Rows[dgvList.CurrentRow.Index].Cells["Back Color"].Value.ToString().Trim());
                cpForeColor.Color = System.Drawing.ColorTranslator.FromHtml(dgvList.Rows[dgvList.CurrentRow.Index].Cells["Fore Color"].Value.ToString().Trim());
                cpBorderColor.Color = System.Drawing.ColorTranslator.FromHtml(dgvList.Rows[dgvList.CurrentRow.Index].Cells["Border Color"].Value.ToString().Trim());
                ebtnFontFamily.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Font"].Value.ToString().Trim();
            }

            public void QLSave()
            {
                try
                {
                    string ProcedureResult = "";
                    if (Validation() == true)
                    {
                        ProcedureResult = FunExecuteProcedure();
                        if (ProcedureResult == "SUCCESS")
                        {
                            Utilities.clsApplication.objUtil.BackColor = cpBackColor.Color;
                            Utilities.clsApplication.objUtil.ForeColor = cpForeColor.Color;
                            Utilities.clsApplication.objUtil.BorderColor = cpBorderColor.Color;
                            Utilities.clsApplication.objUtil.FocusColor = Color.DeepSkyBlue;
                            Utilities.clsApplication.objUtil.FontFont = fdialogUtil.Font;

                            Utilities.clsApplication.objUtil.SetStyle = true;

                            Utilities.clsApplication.objUtil.SetAlert = "Info : Saved Successfully";
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Utlities Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show(this, ProcedureResult, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
                finally
                {

                }
                AddMode();
            }
        #endregion

        #region "Events"

            private void FrmUtil_Load(object sender, EventArgs e)
            {
                dgvList.MultiSelect = false;
                LoadUsersCombo();
                LoadUtilGrid();
            }
        
            private void ebtnFontFamily_EditValueChanged(object sender, EventArgs e)
            {
                if (fdResult == DialogResult.OK)
                {
                    Control ctl = this.GetNextControl(this, true);
                    do
                    {
                        if (ctl.Name.StartsWith("btn"))
                        {
                            ctl.Font = new Font(fdialogUtil.Font.Name, fdialogUtil.Font.Size + 5, fdialogUtil.Font.Style);
                        }
                        else
                        {
                            ctl.Font = new Font(fdialogUtil.Font.Name, fdialogUtil.Font.Size, fdialogUtil.Font.Style);
                        }
                        ctl = this.GetNextControl(ctl, true);
                    } while (ctl != null);
                }
            }
            
            private void ebtnFontFamily_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
            {
                fdialogUtil.ShowEffects = false;
                fdialogUtil.ShowColor = false;
                fdialogUtil.AllowScriptChange = false;
                fdResult = fdialogUtil.ShowDialog();
                if (fdResult == DialogResult.OK)
                {
                    ebtnFontFamily.Text = fdialogUtil.Font.Name.ToString() + "," + fdialogUtil.Font.Size.ToString() + "pt," + fdialogUtil.Font.Style.ToString();
                }
            }

            private void btnSave_Click(object sender, EventArgs e)
            {

                QLSave();
               
            }
           
           private void cpBackColor_EditValueChanged(object sender, EventArgs e)
           {
                pnlLineTop.Appearance.BackColor = Color.White;
                pnlLineTop.Appearance.BackColor2 = cpBackColor.Color;
                pnlLineBottom.Appearance.BackColor = Color.White;
                pnlLineBottom.Appearance.BackColor2 = cpBackColor.Color;
                btnSave.Appearance.BackColor = Color.White;
                btnSave.Appearance.BackColor2 = cpBackColor.Color;
                btnCancel.Appearance.BackColor2 = Color.White;
                btnCancel.Appearance.BackColor2 = cpBackColor.Color;
                btnRestore.Appearance.BackColor2 = Color.White;
                btnRestore.Appearance.BackColor2 = cpBackColor.Color;
            }

            private void cpForeColor_EditValueChanged(object sender, EventArgs e)
            {
                Control ctl = this.GetNextControl(this, true);
                do
                {
                    ctl.ForeColor = cpForeColor.Color;
                    ctl = this.GetNextControl(ctl, true);
                } while (ctl != null);
            }

            private void cpBorderColor_EditValueChanged(object sender, EventArgs e)
            {
                cpBackColor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                cpBackColor.LookAndFeel.UseDefaultLookAndFeel = false;
                cpBackColor.Properties.Appearance.BorderColor = cpBorderColor.Color;
                
                cpForeColor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                cpForeColor.LookAndFeel.UseDefaultLookAndFeel = false;
                cpForeColor.Properties.Appearance.BorderColor = cpBorderColor.Color;
                
                cpBorderColor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                cpBorderColor.LookAndFeel.UseDefaultLookAndFeel = false;
                cpBorderColor.Properties.Appearance.BorderColor = cpBorderColor.Color;
                
                ebtnFontFamily.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                ebtnFontFamily.LookAndFeel.UseDefaultLookAndFeel = false;
                ebtnFontFamily.Properties.Appearance.BorderColor = cpBorderColor.Color;
            }

            private void btnRestore_Click(object sender, EventArgs e)
            {
                Utilities.clsApplication.FunDefaultStyle();
                cpBackColor.Color = Utilities.clsApplication.objUtil.BackColor;
                cpForeColor .Color = Utilities.clsApplication.objUtil.ForeColor;
                cpBorderColor.Color = Utilities.clsApplication.objUtil.BorderColor;
                ebtnFontFamily.Font = Utilities.clsApplication.objUtil.FontFont;
                btnSave.PerformClick();
            }

            private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
            {
                //string[] tokens = str.Split(new[] { "is Marco and" }, StringSplitOptions.None);

                string[] strs = cmbUser.Text.Split('-');
                cmbUser.Text = strs[0].Trim();
                Utilities.clsApplication.objUtil.Empno = cmbUser.Text;
                cmbUser.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            }

            private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                FunLoadSelectedUser();
            }
            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        #endregion
    }
}
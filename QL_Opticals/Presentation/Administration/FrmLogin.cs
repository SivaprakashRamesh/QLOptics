using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Opticals.Presentation.Administration
{
    public partial class FrmLogin : Form
    {
        #region "Declarations"
        DataTable dt = new DataTable();
        string strqry = "";
        #endregion

        //#region "LooselyCoupledFunctions"
        //    public bool getLoginResult()
        //    {
        //        return LoginResult;
        //    }
            
        //#endregion

        #region "Functions"
            public void AutoLogin()
            {
                txtLogin.Text = "SUPPORT";
                txtPassword.Text = "1234";
                btnLogin.PerformClick();
            }
            public void InitFormStyle()
            {
                Utilities.clsApplication.InitForm(this);
            }
            public FrmLogin()
            {
                InitializeComponent();
                InitFormStyle();
            }
            public static string Base64Decode(string base64EncodedData)
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            public bool QLValidate()
            {
                bool valflag = true;
                try
                {
                    if (txtLogin.Text.Trim() == "")
                    {
                        lblerrUserId.ForeColor = Color.Red;
                        lblerrUserId.Text = "Enter User Name";
                        valflag = false;
                    }
                    else
                        lblerrUserId.Text = "";

                    if (txtPassword.Text.Trim() == "")
                    {
                        lblerrPassword.ForeColor = Color.Red;
                        lblerrPassword.Text = "Enter Password";
                        valflag = false;
                    }
                    else
                        lblerrPassword.Text = "";

                    if (valflag != false)
                    {

                        strqry = "select Top 1 \"UserID\",\"UserPassword\" from QLUSER where \"UserID\" = '" + txtLogin.Text.Trim().ToUpper() + "'";
                        dt = Utilities.clsApplication.FunFillDT(strqry);
                        string UserName = "";
                        string UserPassword = "";
                        if (dt.Rows.Count > 0)
                        {
                            UserName = dt.Rows[0]["UserID"].ToString().Trim();
                            UserPassword = Base64Decode(dt.Rows[0]["UserPassword"].ToString().Trim());
                        }

                        if (UserName.ToUpper() != txtLogin.Text.Trim().ToUpper())
                        {
                            lblerrUserId.ForeColor = Color.Red;
                            lblerrUserId.Text = "User Id Not Found";
                            valflag = false;
                        }
                        else
                            lblerrUserId.Text = "";

                        if (valflag != false)
                        {
                            if (UserPassword != txtPassword.Text.Trim())
                            {
                                lblerrPassword.ForeColor = Color.Red;
                                lblerrPassword.Text = "Password Not Match";
                                valflag = false;
                            }
                        }
                        else
                            lblerrPassword.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    valflag = false;
                }

                return valflag;
            }
            public void QLLogin()
            {
                if (QLValidate() == true)
                {
                    Utilities.clsApplication.FunSavedStyle(txtLogin.Text.Trim().ToUpper());
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        #endregion

        #region "Events"
            private void btnLogin_Click(object sender, EventArgs e)
            {
                QLLogin();
            }
            private void btnCancel_Click(object sender, EventArgs e)
            {
                if(Utilities.clsApplication.IsRelogin == true)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    Application.Exit();
                }
                
            }

            private void FrmLogin_Load(object sender, EventArgs e)
            {
                txtLogin.Focus();
                txtPassword.Text = "";
                AutoLogin();
            }

            private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLogin.PerformClick();
                }
            }
        #endregion

            
    }
}

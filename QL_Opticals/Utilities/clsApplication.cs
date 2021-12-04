using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Opticals.Utilities
{
    public class clsUtil
    {

        #region "Declaration"
        private string strqry = "";
        private string empno = "";
        private Color backColor ;
        private Color foreColor;
        private Color focusColor;
        private Color borderColor;
        private string fontFamily = "";
        private string fontName = "";
        private string fontStyle = "";
        private Double  fontSize;
        private Font fontFont;
        private bool setStyle;
        private string setAlert = "";
       
       /* private Presentation.FrmCrePrescription frmCrePre = new Presentation.FrmCrePrescription();
        private Presentation.FrmUtil frmUtil = new Presentation.FrmUtil();
        private Presentation.FrmDashboard frmdashboard = new Presentation.FrmDashboard();
        private Presentation.FrmBookOrder frmOrderbook = new Presentation.FrmBookOrder();
        private Presentation.FrmMdi frmMdi = new Presentation.FrmMdi();*/
        #endregion


        #region "Properties"
       
        public string SetAlert
        {
            get { return setAlert; }
            set { setAlert = value; }
        }
        public string Strqry
        {
            get { return strqry; }
            set { strqry = value; }
        }
        public string Empno
        {
            get { return empno; }
            set { empno = value; }
        }
        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }
        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }
        public Color FocusColor
        {
            get { return focusColor; }
            set { focusColor = value; }
        }
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }
        public string FontFamily
        {
            get { return fontFamily; }
            set { fontFamily = value; }
        }
        public string FontName
        {
            get { return fontName; }
            set { fontName = value; }
        }
        public string FontStyle
        {
            get { return fontStyle; }
            set { fontStyle = value; }
        }
        public Double FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }

        public Font FontFont
        {
            get { return fontFont; }
            set { fontFont = value; }
        }

        public bool SetStyle
        {
            get { return setStyle; }
            set { setStyle = value; }
        }
        #endregion


    }
    public static class  clsApplication
    {

        #region "Declaration"

        public static string ApplicationPath = Application.StartupPath;
        public static string ImagePath = Application.StartupPath + "/Images";
        public static string CompanyLogoPath;
        public static string CompanySignPath;
        public static char kchar;
        public static string str_query;
        public static string ServerName;
        public static string DBName;
        public static string DBUser;
        public static string DBPassword;
        public static string User;
        public static string Password;
        public static string time = "";
        public static string[] ColumnValue;
        public static string[] cflAddNewValues;
        public static DataRow cflSelectedRow;

        public static SqlConnection con;
        public static SqlDataAdapter da;
        public static SqlCommand cmd = new SqlCommand();
        public static SqlParameter param2 = new SqlParameter();
        public static DataTable dt, dt1, dt2, dt3, dtspl, crydt1, crydt2;
        public static DataView dv;
        public static DataRow dtrow;
        public static StyleController BodyStyle = new StyleController();

        public static clsUtil objUtil = new clsUtil();
        public static DevExpress.LookAndFeel.UserLookAndFeel lookfeel;
        public static string ConnectionString;
        public static int CFLXLocation;
        public static int CFLYLocation;

        public static bool IsRelogin;
        #endregion


        #region "Properties"
            
        #endregion


        #region "User Function"
        
        #region "Common Util Function"

            public static bool FunCheckLicense()
            {
                try
                {
                    string TDate = DateTime.Today.ToString("yyyyMMdd");
                    if (int.Parse(TDate) < 20211001)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                    return false;
                }
            }

            public static bool IsDBFound()
            {
                return true;
            }

            public static void CreateDB()
            {

            }
            public static bool FunExecuteQuery(string strQuery)
            {
                try
                {
                    if (con == null)
                    {
                        FunConnectDB();
                    }
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = strQuery;
                    cmd.CommandTimeout = 120;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    XtraMessageBox.Show(ex.Message.ToString(), "On Execute Query");
                    return false;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }

            public static DataTable FunFillDT(string str_query)
            {
                try
                {
                    if (con == null)
                    {
                        FunConnectDB();
                    }
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    dtspl = new DataTable();
                    da = new SqlDataAdapter(str_query, con);
                    da.Fill(dtspl);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString(), "Fill Data");
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                }
                return dtspl;
            }

            public static string FunGetSingleValue(string strSQL)
            {
                try
                {
                    if (con == null)
                    {
                        FunConnectDB();
                    }
                    dt = new DataTable();
                    da = new SqlDataAdapter(strSQL, con);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        return "";
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString(), "On Get Single Data");
                    return "";
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
         
            public static void FunConnectDB()
            {
                try
                {

                    System.IO.StreamReader objreader = new System.IO.StreamReader(ApplicationPath + @"\DBInfo.ini");

                    while (!objreader.EndOfStream)
                    {
                        var TxtLine = objreader.ReadLine().ToString().Trim();
                        if (TxtLine.StartsWith("Servername"))
                            ServerName = TxtLine.Substring(TxtLine.LastIndexOf(":") + 1).Trim();
                        else if (TxtLine.StartsWith("DBName"))
                            DBName = TxtLine.Substring(TxtLine.LastIndexOf(":") + 1).Trim();
                        else if (TxtLine.StartsWith("DBUSER"))
                            DBUser = TxtLine.Substring(TxtLine.LastIndexOf(":") + 1).Trim();
                        else if (TxtLine.StartsWith("DBPASSWORD"))
                            DBPassword = TxtLine.Substring(TxtLine.LastIndexOf(":") + 1).Trim();
                        else if (TxtLine.StartsWith("USER"))
                            User = TxtLine.Substring(TxtLine.LastIndexOf(":") + 1).Trim();
                        else if (TxtLine.StartsWith("PASSWORD"))
                            Password = TxtLine.Substring(TxtLine.LastIndexOf(":") + 1).Trim();
                    }

                    if (IsDBFound() == false)
                    {
                        CreateDB();
                    }

                    if (con != null)
                        con = null;
                    ConnectionString = "DATA SOURCE ='" + ServerName + "';INITIAL CATALOG ='" + DBName + "'; INTEGRATED SECURITY = false;USER ID='" + DBUser + "'; PASSWORD='" + DBPassword + "';";
                    con = new SqlConnection(ConnectionString);
                    con.Open();
                    con.Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString(), "Connect DB");
                    Application.Exit();
                }
                finally
                {
                    GC.Collect();
                }
            }

            public static string QLOpticSPExec(String SPName, DataTable HeadData, DataTable LineData, int QLKey = 0)
            {
                try
                {
                    if (con == null)
                    {
                        FunConnectDB();
                    }

                    cmd = null;
                    cmd = new SqlCommand();

                    //SqlParameter param2 = new SqlParameter();
                    //SqlConnection con = new SqlConnection();
                    //SqlCommand cmd = new SqlCommand();
                    //SqlConnection Connection1;
                    //string ConnectionString = "DATA SOURCE ='" + Utilities.clsApplication.ServerName + "';INITIAL CATALOG ='" + Utilities.clsApplication.DBName + "'; INTEGRATED SECURITY = false;USER ID='" + Utilities.clsApplication.DBUser + "'; PASSWORD='" + Utilities.clsApplication.DBPassword + "';";
                    //Connection1 = new SqlConnection(ConnectionString);

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = Utilities.clsApplication.DBName + ".[dbo]." + SPName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@HeadData", SqlDbType.Structured).Value = HeadData;
                    cmd.Parameters.Add("@LineData", SqlDbType.Structured).Value = LineData;
                    cmd.Parameters.Add("@QLKey", SqlDbType.Int).Value = QLKey;
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);

                    return dt.Rows[0][0].ToString().Trim();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString(), "On Get Single Data");
                    return "";
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    GC.Collect();
                }
            }

        #endregion

        #region "Style & LookandFeel User Function"
            public static void FunDefaultStyle()
            {
                objUtil.BackColor = Color.FromArgb(0, 176, 240);
                objUtil.ForeColor = Color.FromArgb(64, 64, 64);
                objUtil.BorderColor = Color.Silver;
                objUtil.FocusColor = Color.DeepSkyBlue;
                objUtil.FontFont = new Font("Arial Rounded MT", 9, FontStyle.Bold);
            }

            public static bool FunSavedStyle(string EmpNum)
            {
                objUtil.Empno = EmpNum;
                objUtil.Strqry = "SELECT Top 1 ";
                objUtil.Strqry += " \"UserID\" ";
                objUtil.Strqry += ",\"BackColor\" ";
                objUtil.Strqry += ",\"ForeColor\" ";
                objUtil.Strqry += ",\"FocusColor\" ";
                objUtil.Strqry += ",\"BorderColor\" ";
                objUtil.Strqry += ",\"FontFamily\" ";
                objUtil.Strqry += ",\"FontName\" ";
                objUtil.Strqry += ",\"FontStyle\" ";
                objUtil.Strqry += ",\"FontSize\" ";
                objUtil.Strqry += "FROM \"QLUTIL\" ";
                objUtil.Strqry += "WHERE \"UserID\" = '" + objUtil.Empno + "' ";

                dt = FunFillDT(objUtil.Strqry);
                if (dt.Rows.Count > 0)
                {
                    objUtil.BackColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["BackColor"].ToString().Trim());
                    objUtil.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["ForeColor"].ToString().Trim());
                    objUtil.FocusColor = Color.DeepSkyBlue;
                    objUtil.BorderColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["BorderColor"].ToString().Trim());
                    objUtil.FontFamily = dt.Rows[0]["FontFamily"].ToString().Trim();
                    objUtil.FontName = dt.Rows[0]["FontName"].ToString().Trim();
                    objUtil.FontStyle = dt.Rows[0]["FontStyle"].ToString().Trim();
                    objUtil.FontSize = Convert.ToDouble(dt.Rows[0]["FontSize"].ToString().Trim());

                    if (objUtil.FontStyle.Trim() == "Regular")
                        objUtil.FontFont = new Font(objUtil.FontName.Trim(), (float)objUtil.FontSize, FontStyle.Regular);
                    else if (objUtil.FontStyle.Trim() == "Bold")
                        objUtil.FontFont = new Font(objUtil.FontName.Trim(), (float)objUtil.FontSize, FontStyle.Bold);
                    else if (objUtil.FontStyle.Trim() == "Italic")
                        objUtil.FontFont = new Font(objUtil.FontName.Trim(), (float)objUtil.FontSize, FontStyle.Italic);
                    else if (objUtil.FontStyle.Trim() == "Bold, Italic")
                        objUtil.FontFont = new Font(objUtil.FontName.Trim(), (float)objUtil.FontSize, FontStyle.Bold | FontStyle.Italic);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static void InitForm(XtraForm frmCommon)
            {
                try
                {
                    Control ctl = frmCommon.GetNextControl(frmCommon, true);
                    do
                    {
                        string ctrlType = ctl.GetType().ToString();
                        if (ctrlType == "DevExpress.XtraEditors.TextEdit")
                        {
                            TextEdit txtControl = ctl as TextEdit;
                            txtLookFeel(ref txtControl);
                        }
                        else if (ctrlType == "DevExpress.XtraEditors.SimpleButton")
                        {
                            SimpleButton btnControl = ctl as SimpleButton;
                            btnControl.Font = new Font(objUtil.FontFont.Name, objUtil.FontFont.Size + 5, objUtil.FontFont.Style);
                            buttonLookFeel(ref btnControl);
                        }
                        else if (ctrlType == "DevExpress.XtraEditors.PanelControl")
                        {
                            PanelControl pnlControl = ctl as PanelControl;
                            panelLookFeel(ref pnlControl);
                        }
                        else if (ctrlType == "System.Windows.Forms.ComboBox")
                        {
                            System.Windows.Forms.ComboBox cmbControl = ctl as System.Windows.Forms.ComboBox;
                            comboLookFeel(ref cmbControl);
                        }
                        else if (ctrlType == "DevExpress.XtraEditors.DateEdit")
                        {
                            DateEdit dateEditControl = ctl as DateEdit;
                            dateEditLookFeel(ref dateEditControl);
                        }
                        else if (ctrlType == "System.Windows.Forms.RichTextBox")
                        {
                            System.Windows.Forms.RichTextBox rtxtControl = ctl as System.Windows.Forms.RichTextBox;
                            richTextLookFeel(ref rtxtControl);
                        }
                        else if (ctrlType == "System.Windows.Forms.MenuStrip")
                        {
                            System.Windows.Forms.MenuStrip menuStrip = ctl as System.Windows.Forms.MenuStrip;
                            menuStripLookFeel(ref menuStrip);
                        }
                        else if (ctrlType == "DevExpress.XtraNavBar.NavBarControl")
                        {
                            DevExpress.XtraNavBar.NavBarControl navbargroupControl = ctl as DevExpress.XtraNavBar.NavBarControl;
                            navbarLookFeel(ref navbargroupControl);
                        }
                        else if (ctrlType == "System.Windows.Forms.Label")
                        {
                            ctl.Font = objUtil.FontFont;
                        }
                        else if (ctrlType == "System.Windows.Forms.DataGridView")
                        {
                            System.Windows.Forms.DataGridView dgvControl = ctl as System.Windows.Forms.DataGridView
                            dataGridViewLookFeel(ref dgvControl);
                        }
                        ctl = frmCommon.GetNextControl(ctl, true);
                    } while (ctl != null);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }

            public static void InitForm(Form frmCommon)
            {
                Control ctl = frmCommon.GetNextControl(frmCommon, true);
                do
                {
                    string ctrlType = ctl.GetType().ToString();
                    if (ctrlType == "DevExpress.XtraEditors.TextEdit")
                    {
                        TextEdit txtControl = ctl as TextEdit;
                        txtLookFeel(ref txtControl);
                    }
                    else if (ctrlType == "DevExpress.XtraEditors.SimpleButton")
                    {
                        SimpleButton btnControl = ctl as SimpleButton;
                        buttonLookFeel(ref btnControl);
                    }
                    else if (ctrlType == "DevExpress.XtraEditors.PanelControl")
                    {
                        PanelControl pnlControl = ctl as PanelControl;
                        panelLookFeel(ref pnlControl);
                    }
                    else if (ctrlType == "System.Windows.Forms.ComboBox")
                    {
                        System.Windows.Forms.ComboBox cmbControl = ctl as System.Windows.Forms.ComboBox;
                        comboLookFeel(ref cmbControl);
                    }
                    else if (ctrlType == "DevExpress.XtraEditors.DateEdit")
                    {
                        DateEdit dateEditControl = ctl as DateEdit;
                        dateEditLookFeel(ref dateEditControl);
                    }
                    else if (ctrlType == "System.Windows.Forms.RichTextBox")
                    {
                        System.Windows.Forms.RichTextBox rtxtControl = ctl as System.Windows.Forms.RichTextBox;
                        richTextLookFeel(ref rtxtControl);
                    }
                    else
                    {
                        ctl.Font = Utilities.clsApplication.objUtil.FontFont;
                    }
                    ctl = frmCommon.GetNextControl(ctl, true);
                } while (ctl != null);
            }

            public static void RemoveStyle(Control ctrlCommon)
            {
                string ctrlType = ctrlCommon.GetType().ToString();
                if (ctrlType == "DevExpress.XtraEditors.TextEdit")
                {
                    TextEdit txtControl = ctrlCommon as TextEdit;
                    txtControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
                    txtControl.LookAndFeel.UseDefaultLookAndFeel = true;
                }
                else if (ctrlType == "System.Windows.Forms.Button")
                {
                    ctrlCommon.Font = new Font("Arial Rounded MT", 8, FontStyle.Bold);
                }
                else if (ctrlType == "DevExpress.XtraEditors.SimpleButton")
                {
                    SimpleButton btnControl = ctrlCommon as SimpleButton;
                    btnControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
                    btnControl.LookAndFeel.UseDefaultLookAndFeel = true;
                    btnControl.Font = new Font("Arial Rounded MT", 8, FontStyle.Bold);
                }
                else if (ctrlType == "DevExpress.XtraEditors.PanelControl")
                {
                    PanelControl pnlControl = ctrlCommon as PanelControl;
                    pnlControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
                    pnlControl.LookAndFeel.UseDefaultLookAndFeel = true;
                }
                else if (ctrlType == "System.Windows.Forms.ComboBox")
                {
                    System.Windows.Forms.ComboBox cmbControl = ctrlCommon as System.Windows.Forms.ComboBox;

                }
                else if (ctrlType == "DevExpress.XtraEditors.DateEdit")
                {
                    DateEdit dateEditControl = ctrlCommon as DateEdit;
                    dateEditControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
                    dateEditControl.LookAndFeel.UseDefaultLookAndFeel = true;
                }
                else if (ctrlType == "System.Windows.Forms.RichTextBox")
                {
                    System.Windows.Forms.RichTextBox rtxtControl = ctrlCommon as System.Windows.Forms.RichTextBox;

                }
                else if (ctrlType == "System.Windows.Forms.Label")
                {
                    System.Windows.Forms.Label lblControl = ctrlCommon as System.Windows.Forms.Label;
                    lblControl.Font = new Font("Arial Rounded MT", 9, FontStyle.Bold);
                }

            }

            public static DevExpress.LookAndFeel.UserLookAndFeel FunSetLookFeel(object frm)
            {
                lookfeel = new DevExpress.LookAndFeel.UserLookAndFeel(frm);
                lookfeel.UseDefaultLookAndFeel = false;
                lookfeel.SetFlatStyle();
                lookfeel.SetSkinStyle("DevExpress Dark Style");
                return lookfeel;
            }
            public static void navbarLookFeel(ref DevExpress.XtraNavBar.NavBarControl navbarCommon)
            {
                navbarCommon.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                navbarCommon.LookAndFeel.UseDefaultLookAndFeel = false;
                navbarCommon.Appearance.GroupHeader.BackColor = Color.White;
                navbarCommon.Appearance.GroupHeader.BackColor2 = objUtil.BackColor;
                navbarCommon.Appearance.ItemHotTracked.ForeColor = Color.DeepSkyBlue;
                navbarCommon.Appearance.ItemPressed.ForeColor = objUtil.BackColor;
                navbarCommon.Appearance.GroupHeader.Font = new Font(objUtil.FontFont.Name.Trim(), objUtil.FontFont.Size + 1, objUtil.FontFont.Style);
                navbarCommon.Appearance.Item.Font = objUtil.FontFont;

                foreach (DevExpress.XtraNavBar.NavBarItem navitem in navbarCommon.Items)
                {
                    navitem.Appearance.Font = objUtil.FontFont;
                }
            }
            public static void menuStripLookFeel(ref System.Windows.Forms.MenuStrip mstripCommon)
            {
                mstripCommon.Font = objUtil.FontFont;
            }
            public static void comboLookFeel(ref System.Windows.Forms.ComboBox cmbCommon)
            {
                cmbCommon.DropDownStyle = ComboBoxStyle.DropDown;
                cmbCommon.FlatStyle = FlatStyle.Standard;
                cmbCommon.BackColor = Color.FromArgb(255, 255, 255);

                cmbCommon.ForeColor = objUtil.ForeColor;
                cmbCommon.Font = objUtil.FontFont;
            }
            public static void dateEditLookFeel(ref DateEdit dateEditCommon)
            {
                dateEditCommon.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                dateEditCommon.LookAndFeel.UseDefaultLookAndFeel = false;
                dateEditCommon.Properties.Appearance.BorderColor = objUtil.BorderColor;
                dateEditCommon.Properties.AppearanceFocused.BorderColor = Color.DeepSkyBlue;
                dateEditCommon.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                dateEditCommon.ForeColor = objUtil.ForeColor;
                dateEditCommon.Font = objUtil.FontFont;
            }
            public static void richTextLookFeel(ref System.Windows.Forms.RichTextBox rtxtCommon)
            {
                rtxtCommon.BorderStyle = BorderStyle.FixedSingle;
            }
            public static void  dataGridViewLookFeel(ref System.Windows.Forms.DataGridView dgvCommon)
            {
                dgvCommon.GridColor = Utilities.clsApplication.objUtil.BackColor;
                dgvCommon.DefaultCellStyle.SelectionBackColor = Color.FromArgb((Utilities.clsApplication.objUtil.BackColor.R < 128 ? Utilities.clsApplication.objUtil.BackColor.R + 128 : Utilities.clsApplication.objUtil.BackColor.R), (Utilities.clsApplication.objUtil.BackColor.G < 128 ? Utilities.clsApplication.objUtil.BackColor.G + 128 : Utilities.clsApplication.objUtil.BackColor.G), (Utilities.clsApplication.objUtil.BackColor.B < 128 ? Utilities.clsApplication.objUtil.BackColor.B + 128 : Utilities.clsApplication.objUtil.BackColor.B));
                dgvCommon.DefaultCellStyle.SelectionForeColor = Color.Black;

                dgvCommon.ForeColor = Color.Black;
                dgvCommon.MultiSelect = false;
            }
            public static void buttonLookFeel(ref SimpleButton btnCommon)
            {
                btnCommon.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                btnCommon.LookAndFeel.UseDefaultLookAndFeel = false;
                btnCommon.Appearance.BackColor2 = Color.White;
                btnCommon.Appearance.BackColor2 = objUtil.BackColor;
                btnCommon.Font = new Font(objUtil.FontFont.Name, objUtil.FontFont.Size + 5, objUtil.FontFont.Style);
            }

            public static void panelLookFeel(ref PanelControl pnlCommon)
            {
                if (pnlCommon.Name.StartsWith("pnlLine"))
                {
                    pnlCommon.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                    pnlCommon.LookAndFeel.UseDefaultLookAndFeel = false;
                    pnlCommon.Appearance.BackColor = Color.White;
                    pnlCommon.Appearance.BackColor2 = objUtil.BackColor;
                    pnlCommon.Font = objUtil.FontFont;
                }
                if (pnlCommon.Name.StartsWith("pnlCFL"))
                {
                    pnlCommon.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                    pnlCommon.LookAndFeel.UseDefaultLookAndFeel = false;
                    pnlCommon.Appearance.BackColor = Color.Transparent;
                    pnlCommon.Appearance.BackColor2 = objUtil.BackColor;
                    pnlCommon.Appearance.BorderColor = objUtil.BackColor;
                    pnlCommon.Font = objUtil.FontFont;
                }
            }

            public static void btneditLookFeel(ref ButtonEdit btneditCommon)
            {
                btneditCommon.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                btneditCommon.LookAndFeel.UseDefaultLookAndFeel = false;
                btneditCommon.Properties.Appearance.BorderColor = objUtil.BorderColor;
                btneditCommon.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                btneditCommon.Properties.AppearanceFocused.BorderColor = Color.DeepSkyBlue;
                btneditCommon.ForeColor = objUtil.ForeColor;
                btneditCommon.Font = objUtil.FontFont;
            }
            public static void colorpickLookFeel(ref ColorPickEdit colpickCommon)
            {
                colpickCommon.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                colpickCommon.LookAndFeel.UseDefaultLookAndFeel = false;
                colpickCommon.Properties.Appearance.BorderColor = objUtil.BorderColor;
                colpickCommon.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                colpickCommon.Properties.AppearanceFocused.BorderColor = Color.DeepSkyBlue;
                colpickCommon.ForeColor = objUtil.ForeColor;
                colpickCommon.Font = objUtil.FontFont;
            }
            public static void txtLookFeel(ref TextEdit txtCommon)
            {
                txtCommon.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                txtCommon.LookAndFeel.UseDefaultLookAndFeel = false;
                txtCommon.Properties.Appearance.BorderColor = objUtil.BorderColor;
                txtCommon.Properties.AppearanceFocused.BorderColor = Color.DeepSkyBlue;
                txtCommon.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                txtCommon.ForeColor = objUtil.ForeColor;
                txtCommon.Font = objUtil.FontFont;
            }
            #endregion
            

        
       #endregion


    }   
}

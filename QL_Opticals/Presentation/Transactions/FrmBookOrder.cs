using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Opticals.Presentation
{
   
    public partial class FrmBookOrder : Form, Transactions.IBookOrder, IWin32Window
    {

        #region "Declaration"
            string strqry = "";
            DataTable dt = new DataTable();
            //int i = 0;
            //string oldsearch = "";
            //int oldsrow = 0;
        #endregion

        #region "Constructor"
            public FrmBookOrder()
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
                dgvList.CurrentCell = dgvList["QLKey", currrow];
                QLLoadSelectedBookOrder();
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
                dgvList.CurrentCell = dgvList["QLKey", currrow];
                QLLoadSelectedBookOrder();
            }
            public void MoveLastRecord() 
            {
                dgvList.Rows[dgvList.RowCount - 1].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", dgvList.RowCount - 1];
                QLLoadSelectedBookOrder();
            }
            public void MoveFirstRecord() 
            {
                dgvList.Rows[0].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", 0];
                QLLoadSelectedBookOrder();
            }
            public void FindMode() { }
            public void AddMode() 
            {
                try
                {
                    QLLoadData();
                    QLClearData();
                    QLClearErrorLabels();
                    txtCustomerCode.Focus();
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
                
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
                Utilities.clsApplication.RemoveStyle(btnBookOrder);

                dgvList.MultiSelect = false;
                dateDeliveryTime.Format = DateTimePickerFormat.Time;
                dateDeliveryTime.ShowUpDown = true;
                txtCustomerCode.Properties.ReadOnly = true;
                txtSupplier.Properties.ReadOnly = true;
            }
            public bool QLValidation()
            {
                bool valflag = true;

                try
                {
                    if (txtCustomerCode.Text.Trim() == "")
                    {

                        lblerrCustCode.ForeColor = Color.Red;
                        lblerrCustCode.Text = "Enter Customer Code";
                        valflag = false;
                    }
                    else
                        lblerrCustCode.Text = "";

                    if (txtCustomerName.Text.Trim() == "")
                    {

                        lblerrCustName.ForeColor = Color.Red;
                        lblerrCustName.Text = "Enter Customer Name";
                        valflag = false;
                    }
                    else
                        lblerrCustName.Text = "";

                    if (txtMobileNo.Text.Trim() == "")
                    {

                        lblerrMobile.ForeColor = Color.Red;
                        lblerrMobile.Text = "Enter Mobile No";
                        valflag = false;
                    }
                    else
                        lblerrMobile.Text = "";

                    if (txtEmailId.Text.Trim() == "")
                    {

                        lblerrEmail.ForeColor = Color.Red;
                        lblerrEmail.Text = "Enter Email Id";
                        valflag = false;
                    }
                    else
                        lblerrEmail.Text = "";

                    if (rtxtNarration.Text.Trim() == "")
                    {

                        lblerrNarration.ForeColor = Color.Red;
                        lblerrNarration.Text = "Enter Narration";
                        valflag = false;
                    }
                    else
                        lblerrNarration.Text = "";

                    if (txtSupplier.Text.Trim() == "")
                    {

                        lblerrSupplier.ForeColor = Color.Red;
                        lblerrSupplier.Text = "Enter Supplier";
                        valflag = false;
                    }
                    else
                        lblerrSupplier.Text = "";

                    if (txtOrderNo.Text.Trim() == "")
                    {

                        lblerrOrderNo.ForeColor = Color.Red;
                        lblerrOrderNo.Text = "Select Order No";
                        valflag = false;
                    }
                    else
                    {
                        if (cmbOrderType.SelectedIndex == 0)
                        {
                            lblerrOrderNo.ForeColor = Color.Red;
                            lblerrOrderNo.Text = "Select Order Type";
                            valflag = false;
                        }
                        else
                            lblerrOrderNo.Text = "";
                    }
                        

                    if (dateOrderDate.Text.Trim() == "")
                    {

                        lblerrOrderDate.ForeColor = Color.Red;
                        lblerrOrderDate.Text = "Select Order Date";
                        valflag = false;
                    }
                    else
                        lblerrOrderDate.Text = "";

                    if (dateDeliveryDate.Text.Trim() == "")
                    {

                        lblerrDeliveryDate.ForeColor = Color.Red;
                        lblerrDeliveryDate.Text = "Select Delivery Date";
                        valflag = false;
                    }
                    else
                        lblerrDeliveryDate.Text = "";

                    if (dateDeliveryTime.Text.Trim() == "")
                    {

                        lblerrDeliveryTime.ForeColor = Color.Red;
                        lblerrDeliveryTime.Text = "Select Delivery Time";
                        valflag = false;
                    }
                    else
                        lblerrDeliveryTime.Text = "";

                    if (datePaymentDate.Text.Trim() == "")
                    {

                        lblerrPaymentDate.ForeColor = Color.Red;
                        lblerrPaymentDate.Text = "Select Payment Date";
                        valflag = false;
                    }
                    else
                        lblerrPaymentDate.Text = "";

                    if (dgvBarcode.Rows.Count > 1)
                    {
                        lblerrLineDetails.Text = "";
                    }
                    else
                    {
                        lblerrLineDetails.ForeColor = Color.Red;
                        lblerrLineDetails.Text = "Add Atleast One Row Detail";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    valflag = false;
                }


                return valflag;
            }
            public DataTable ToDataTable(DataGridView dgv)
            {
                try
                {
                    //Creating DataTable.
                    DataTable dt = new DataTable();

                    //Adding the Columns.
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.ValueType == null)
                            column.ValueType = typeof(String);
                        dt.Columns.Add(column.HeaderText, column.ValueType);
                    }

                    //Adding the Rows.
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells[1].Value != null)
                        {
                            dt.Rows.Add();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                //if (cell.ColumnIndex == 0)
                                //{
                                //    if(txtQLKey.Text.Trim() != "")
                                //    {
                                //        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = txtQLKey.Text.Trim();
                                //    }
                                //}
                                //else
                                //{
                                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = (cell.Value == null) ? "0" : cell.Value.ToString();
                                //}
                                
                            }
                        }
                    }
                    return dt;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());

                    return null;
                }

            }
            public DataTable QLHeadData()
            {
                DataTable HeadData = new DataTable();
                //HeadData.Columns.Add("QLKey", typeof(int));
                HeadData.Columns.Add("CustomerCode", typeof(string));
                HeadData.Columns.Add("Narration", typeof(string));
                HeadData.Columns.Add("SupplierCode", typeof(string));
                HeadData.Columns.Add("OrderNo", typeof(string));
                HeadData.Columns.Add("OrderDate", typeof(DateTime));
                HeadData.Columns.Add("DeliveryDate", typeof(DateTime));
                HeadData.Columns.Add("DeliveryTime", typeof(DateTime));
                HeadData.Columns.Add("DiscountRemarks", typeof(string));
                HeadData.Columns.Add("PaymentDate", typeof(DateTime));
                HeadData.Columns.Add("TotBefDiscount", typeof(double));
                HeadData.Columns.Add("Discount", typeof(double));
                HeadData.Columns.Add("OtherCharges", typeof(double));
                HeadData.Columns.Add("VATAmt", typeof(double));
                HeadData.Columns.Add("Roundoff", typeof(double));
                HeadData.Columns.Add("InvoiceAmt", typeof(double));
                HeadData.Columns.Add("CurrentAdvanse", typeof(double));
                HeadData.Columns.Add("BalanceAmt", typeof(double));
                HeadData.Columns.Add("OrderType", typeof(string));
                
                
                DataRow HeadDataRow;
                HeadDataRow = HeadData.NewRow();
                //HeadDataRow["QLKey"] = 1;
                HeadDataRow["CustomerCode"] = txtCustomerCode.Text.Trim();
                HeadDataRow["Narration"] = rtxtNarration.Text.Trim();
                HeadDataRow["SupplierCode"] = txtSupplier.Text.Trim();
                HeadDataRow["OrderNo"] = txtOrderNo.Text.Trim();
                HeadDataRow["OrderDate"] = dateOrderDate.Text.Trim();
                HeadDataRow["DeliveryDate"] = dateDeliveryDate.Text.Trim();
                HeadDataRow["DeliveryTime"] = dateDeliveryTime.Text.Trim();
                HeadDataRow["DiscountRemarks"] = rtxtDiscountRemarks.Text.Trim();
                HeadDataRow["PaymentDate"] = datePaymentDate.Text.Trim();
                HeadDataRow["TotBefDiscount"] = txtTotBefDiscount.Text.Trim();
                HeadDataRow["Discount"] = txtDiscount.Text.Trim();
                HeadDataRow["OtherCharges"] = txtOtherCharges.Text.Trim();
                HeadDataRow["VATAmt"] = txtTaxAmt.Text.Trim();
                HeadDataRow["Roundoff"] = txtRoundoff.Text.Trim();
                HeadDataRow["InvoiceAmt"] = txtInvAmt.Text.Trim();
                HeadDataRow["CurrentAdvanse"] = txtCurrAdvance.Text.Trim();
                HeadDataRow["InvoiceAmt"] = txtInvAmt.Text.Trim();
                HeadDataRow["BalanceAmt"] = txtBalAmt.Text.Trim();
                HeadDataRow["OrderType"] = cmbOrderType.Text.Trim();
                HeadData.Rows.Add(HeadDataRow);

                return HeadData;
            }
            public DataTable QLLineData()
            {
                DataTable LineData = new DataTable();
                LineData = ToDataTable(dgvBarcode);
                return LineData;
            }
            public string QLExecuteProcedure(int QLKey = 0)
            {
                try
                {
                    SqlParameter param2 =new SqlParameter();
                    SqlConnection con =  new SqlConnection();
                    SqlCommand cmd = new SqlCommand();
                    SqlConnection Connection1;

                    string ConnectionString = "DATA SOURCE ='" + Utilities.clsApplication.ServerName + "';INITIAL CATALOG ='" + Utilities.clsApplication.DBName + "'; INTEGRATED SECURITY = false;USER ID='" + Utilities.clsApplication.DBUser + "'; PASSWORD='" + Utilities.clsApplication.DBPassword + "';";
                    Connection1 = new SqlConnection(ConnectionString);
                    Connection1.Open();
                    cmd.Connection = Connection1;
                    cmd.CommandText = Utilities.clsApplication.DBName + ".[dbo].[CreOrUptBookOrder]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dthead = QLHeadData();
                    DataTable dtline = QLLineData();
                    cmd.Parameters.Add("@HeadData", SqlDbType.Structured).Value = dthead;
                    cmd.Parameters.Add("@LineData", SqlDbType.Structured).Value = dtline;
                    cmd.Parameters.Add("@QLKey", SqlDbType.Int).Value = QLKey;
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);

                    return dt.Rows[0][0].ToString().Trim();

                }
                catch (Exception ex)
                {
                    return ex.Message.ToString().Trim();
                }
            }
            public bool QLSave(int QLKey = 0)
            {
                try
                {
                    string ProcedureResult = "";
                    if (QLValidation() == true)
                    {
                        ProcedureResult = QLExecuteProcedure(QLKey);
                        if (ProcedureResult == "SUCCESS")
                        {
                            QLLoadData();
                            Utilities.clsApplication.objUtil.SetAlert = "Info : Saved Successfully";
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Book Order Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
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
            public void QLLoadData()
            {
                try
                {
                    dgvList.AllowUserToAddRows = false;
                    dgvList.AllowUserToDeleteRows = false;
                    dgvList.ReadOnly = true;
                    dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    strqry = "select \"OrderDate\",\"DeliveryDate\",\"CustomerCode\",\"SupplierCode\",\"QLKey\" from QLOBOK";
                    if (dt != null)
                    {
                        dt = null;
                    }
                    dt = Utilities.clsApplication.FunFillDT(strqry);
                    if (dt.Rows.Count > 0)
                    {
                        dgvList.DataSource = null;
                        dgvList.DataSource = dt;
                        //dgvList.Columns["QLKey"].Visible = false;
                        dgvList.Rows[0].Cells[0].Selected = true;
                        //QLLoadSelectedBookOrder();
                        dgvList.Refresh();
                    }
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
            public void QLLoadSelectedBookOrder()
            {
                try
                {
                    QLClearErrorLabels();
                    string currentQLKey = dgvList.Rows[dgvList.CurrentRow.Index].Cells["QLKey"].Value.ToString().Trim();
                    strqry = " select T0.QLKey,T0.CustomerCode,";
                    strqry += " (select Name from QLCUST where Code = T0.CustomerCode) 'CustomerName',";
                    strqry += " (select Mobile from QLCUST where Code = T0.CustomerCode) 'MobileNo',";
                    strqry += " (select Email from QLCUST where Code = T0.CustomerCode) 'EmailId',";
                    strqry += " T0.Narration,T0.SupplierCode,T0.OrderNo,T0.OrderType,T0.OrderDate,T0.DeliveryDate,";
                    strqry += " T0.DeliveryTime,T0.DiscountRemarks,T0.PaymentDate,T0.TotBefDiscount,T0.Discount,T0.OtherCharges,";
                    strqry += " T0.TaxAmt,T0.Roundoff,T0.InvoiceAmt,T0.CurrentAdvanse,T0.BalanceAmt,T1.QLKey 'LQLKey',T1.LineNum,";
                    strqry += " T1.Barcode,T1.Product,T1.Quantity,T1.UOM,T1.Rate,T1.Discount,T1.TaxPercent";
                    strqry += " from QLOBOK T0 ";
                    strqry += " inner join QLBOK1 T1 on T1.QLKey = T0.QLKey";
                    strqry += " where T0.QLKey = " + currentQLKey;

                    dt = Utilities.clsApplication.FunFillDT(strqry);

                    txtQLKey.Text = dt.Rows[0]["QLKey"].ToString().Trim();
                    txtCustomerCode.Text = dt.Rows[0]["CustomerCode"].ToString().Trim();
                    txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString().Trim();
                    txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString().Trim();
                    txtEmailId.Text = dt.Rows[0]["EmailId"].ToString().Trim();
                    rtxtNarration.Text = dt.Rows[0]["Narration"].ToString().Trim();
                    txtSupplier.Text = dt.Rows[0]["SupplierCode"].ToString().Trim();
                    txtOrderNo.Text = dt.Rows[0]["OrderNo"].ToString().Trim();
                    dateOrderDate.Text = dt.Rows[0]["OrderDate"].ToString().Trim();
                    dateDeliveryDate.Text = dt.Rows[0]["DeliveryDate"].ToString().Trim();
                    dateDeliveryTime.Text = dt.Rows[0]["DeliveryTime"].ToString().Trim();
                    rtxtDiscountRemarks.Text = dt.Rows[0]["DiscountRemarks"].ToString().Trim();
                    datePaymentDate.Text = dt.Rows[0]["PaymentDate"].ToString().Trim();
                    txtTotBefDiscount.Text = dt.Rows[0]["TotBefDiscount"].ToString().Trim();
                    txtDiscount.Text = dt.Rows[0]["Discount"].ToString().Trim();
                    txtOtherCharges.Text = dt.Rows[0]["OtherCharges"].ToString().Trim();
                    txtTaxAmt.Text = dt.Rows[0]["TaxAmt"].ToString().Trim();
                    txtRoundoff.Text = dt.Rows[0]["Roundoff"].ToString().Trim();
                    txtInvAmt.Text = dt.Rows[0]["InvoiceAmt"].ToString().Trim();
                    txtCurrAdvance.Text = dt.Rows[0]["CurrentAdvanse"].ToString().Trim();
                    txtBalAmt.Text = dt.Rows[0]["BalanceAmt"].ToString().Trim();
                    cmbOrderType.Text = dt.Rows[0]["OrderType"].ToString().Trim();

                    //dgvBarcode.Columns["LQLKey"].Visible = true;
                    dgvBarcode.DataSource = null;
                    dgvBarcode.Rows.Clear();
                    for(int i=0;i<=dt.Rows.Count -1;i++)
                    {
                        dgvBarcode.Rows.Add();
                        dgvBarcode.Rows[i].Cells["LQLKey"].Value = dt.Rows[i]["LQLKey"].ToString().Trim();
                        dgvBarcode.Rows[i].Cells["LLineNo"].Value = dt.Rows[i]["LineNum"].ToString().Trim();
                        dgvBarcode.Rows[i].Cells["LBarcode"].Value = dt.Rows[i]["Barcode"].ToString().Trim();
                        dgvBarcode.Rows[i].Cells["LProduct"].Value = dt.Rows[i]["Product"].ToString().Trim();
                        dgvBarcode.Rows[i].Cells["LUOM"].Value = dt.Rows[i]["UOM"].ToString().Trim();
                        dgvBarcode.Rows[i].Cells["LQuantity"].Value = dt.Rows[i]["Quantity"].ToString().Trim();
                        dgvBarcode.Rows[i].Cells["LRate"].Value = dt.Rows[i]["Rate"].ToString().Trim();
                        dgvBarcode.Rows[i].Cells["LDiscount"].Value = dt.Rows[i]["Discount"].ToString().Trim();
                        dgvBarcode.Rows[i].Cells["LTaxPercent"].Value = dt.Rows[i]["TaxPercent"].ToString().Trim();
                        
                    }
                    //dgvBarcode.Columns["LQLKey"].Visible = false;
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
            public void QLFetch(int QLKey)
            {

            }
            public void QLClearErrorLabels()
            {
                lblerrCustCode.Text = "";
                lblerrCustName.Text = "";
                lblerrDeliveryDate.Text = "";
                lblerrDeliveryTime.Text = "";
                lblerrEmail.Text = "";
                lblerrLineDetails.Text = "";
                lblerrMobile.Text = "";
                lblerrNarration.Text = "";
                lblerrOrderDate.Text = "";
                lblerrOrderNo.Text = "";
                lblerrPaymentDate.Text = "";
                lblerrSupplier.Text = "";
            }
            public void QLClearData()
            {
                dgvBarcode.Rows.Clear();
                txtCustomerCode.Text = "";
                txtCustomerName.Text = "";
                txtMobileNo.Text = "";
                txtEmailId.Text = "";
                rtxtNarration.Text = "";
                txtSupplier.Text = "";
                txtOrderNo.Text = "";
                dateOrderDate.Text = "";
                dateDeliveryDate.Text = "";
                dateDeliveryTime.Text = "";
                rtxtDiscountRemarks.Text = "";
                datePaymentDate.Text = "";
                txtTotBefDiscount.Text = "";
                txtDiscount.Text = "";
                txtOtherCharges.Text = "";
                txtTaxAmt.Text = "";
                txtRoundoff.Text = "";
                txtInvAmt.Text = "";
                txtCurrAdvance.Text = "";
                txtBalAmt.Text = "";
                txtQLKey.Text = "";
                cmbOrderType.SelectedIndex = 0;
            }
            public void QLLoadCustomerCFL()
            {
                int CFLX = Utilities.clsApplication.CFLXLocation + this.Location.X + pnlCustCode.Location.X +6;
                int CFLY = 0;
                if(this.WindowState == FormWindowState.Maximized)
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlCustCode.Height + pnlLineTop.Height + txtCustomerCode.Height + 22;
                }
                else
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlCustCode.Height + pnlLineTop.Height + txtCustomerCode.Height + 2;
                }
                string CFLQuery = "SELECT \"Code\" 'CustomerCode',\"Name\" 'CustomerName',\"Grp\",\"Adress\",\"City\",\"StateName\",\"Pin\",\"Mobile\",\"Email\",\"DOB\",\"Age\",\"QLKey\" FROM QLCUST order by \"Code\"";
                int CFLWidth = txtCustomerCode.Width;
                int CFLHeight = tpnlTop.Height - pnlCustCode.Height;
                QLControls.CFLControl cfl = new QLControls.CFLControl();
                cfl.QLLoadCFL(CFLX, CFLY, CFLQuery, 2, CFLWidth, CFLHeight);
               
                if (Utilities.clsApplication.cflSelectedRow != null)
                {
                    DataRow cflSelection = Utilities.clsApplication.cflSelectedRow;
                    txtCustomerCode.Text = cflSelection["CustomerCode"].ToString();
                    txtCustomerName.Text = cflSelection["CustomerName"].ToString();
                    txtMobileNo.Text = cflSelection["Mobile"].ToString();
                    txtEmailId.Text = cflSelection["Email"].ToString();
                }
            }
            public void QLLoadSupplierCFL()
            {
                int CFLX = Utilities.clsApplication.CFLXLocation + this.Location.X + tpnlTopRight.Location.X + pnlSupplier.Location.X + 2;
                int CFLY = 0;
                if (this.WindowState == FormWindowState.Maximized)
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlSupplier.Height + pnlLineTop.Height + txtSupplier.Height + 20;
                }
                else
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlSupplier.Height + pnlLineTop.Height + txtSupplier.Height + 0;
                }
                string CFLQuery = "SELECT \"Code\" 'SupplierCode',\"Name\" 'SupplierName',\"Grp\",\"Adress\",\"City\",\"StateName\",\"Pin\",\"Mobile\",\"Email\",\"DOB\",\"Age\",\"QLKey\"  FROM QLSUPL order by \"Code\" ";
                int CFLWidth = txtSupplier.Width;
                int CFLHeight = tpnlTop.Height - pnlCustCode.Height;
                QLControls.CFLControl cfl = new QLControls.CFLControl();
                cfl.QLLoadCFL(CFLX, CFLY, CFLQuery, 2, CFLWidth, CFLHeight);
                if (Utilities.clsApplication.cflSelectedRow != null)
                {
                    DataRow cflSelection = Utilities.clsApplication.cflSelectedRow;
                    txtSupplier.Text = cflSelection["SupplierCode"].ToString();
                }
            }
            public void QLLoadOrderNoCFL()
            {
                int CFLX = Utilities.clsApplication.CFLXLocation + this.Location.X + tpnlTopRight.Location.X + pnlOrderNo.Location.X + 2;
                int CFLY = 0;
                if (this.WindowState == FormWindowState.Maximized)
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlOrderNo.Height + pnlLineTop.Height + txtOrderNo.Height + 40;
                }
                else
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlOrderNo.Height + pnlLineTop.Height + txtOrderNo.Height + 0;
                }
                string CFLQuery = "SELECT \"OrderNo\" 'OrderNo',\"CustomerCode\" 'CutomerCode',\"Narration\",\"OrderDate\",\"DeliveryDate\",\"DeliveryTime\",\"DiscountRemarks\",\"PaymentDate\",\"TotBefDiscount\",\"Discount\",\"OtherCharges\",\"TaxAmt\",\"Roundoff\",\"InvoiceAmt\",\"CurrentAdvanse\",\"BalanceAmt\",\"QLKey\" FROM QLOBOK  where \"CustomerCode\" =  \"OrderNo\" ";
                int CFLWidth = txtOrderNo.Width;
                int CFLHeight = tpnlTop.Height - pnlCustName.Height;
                QLControls.CFLControl cfl = new QLControls.CFLControl();
                cfl.QLLoadCFL(CFLX, CFLY, CFLQuery, 2, CFLWidth, CFLHeight);
                if (Utilities.clsApplication.cflSelectedRow != null)
                {
                    DataRow cflSelection = Utilities.clsApplication.cflSelectedRow;
                    txtOrderNo.Text = cflSelection["OrderNo"].ToString();
                    rtxtNarration.Text = cflSelection["Narration"].ToString();
                    dateOrderDate.Text = cflSelection["OrderDate"].ToString();
                    dateDeliveryDate.Text = cflSelection["DeliveryDate"].ToString();
                    dateDeliveryTime.Text = cflSelection["DeliveryTime"].ToString();
                    rtxtDiscountRemarks.Text = cflSelection["DiscountRemarks"].ToString();
                    datePaymentDate.Text = cflSelection["PaymentDate"].ToString();
                    txtTotBefDiscount.Text = cflSelection["TotBefDiscount"].ToString();
                    txtDiscount.Text = cflSelection["Discount"].ToString();
                    txtOtherCharges.Text = cflSelection["OtherCharges"].ToString();
                    txtTaxAmt.Text = cflSelection["TaxAmt"].ToString();
                    txtRoundoff.Text = cflSelection["Roundoff"].ToString();
                    txtInvAmt.Text = cflSelection["InvoiceAmt"].ToString();
                    txtCurrAdvance.Text = cflSelection["CurrentAdvanse"].ToString();
                    txtBalAmt.Text = cflSelection["BalanceAmt"].ToString();
                }
            }
        #endregion
           
        #region "Events"
            private void FrmBookOrder_Load(object sender, EventArgs e)
            {
                AddMode();
            }
            private void btnSave_Click(object sender, EventArgs e)
            {
                if(QLSave(Convert.ToInt32(txtQLKey.Text.Trim() == "" ? "0" : txtQLKey.Text.Trim())) == true)
                {
                    AddMode();
                }
            }
            private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                QLLoadSelectedBookOrder();
            }
            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }
            private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        QLLoadCustomerCFL();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
               
            }
            private void txtCustomerCode_Click(object sender, EventArgs e)
            {
                QLLoadCustomerCFL();
            }
            private void txtSupplier_Click(object sender, EventArgs e)
            {
                QLLoadSupplierCFL();
            }
            private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        QLLoadSupplierCFL();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            private void txtOrderNo_Click(object sender, EventArgs e)
            {
                QLLoadOrderNoCFL();
            }
        #endregion   

    }
}

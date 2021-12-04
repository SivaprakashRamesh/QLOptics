using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QL_Opticals.Presentation.Transactions
{
    public partial class FrmReceiveAdvance : DevExpress.XtraEditors.XtraForm,IReceiveAdvance
    {

        #region "Declaration"
        string strqry = "";
        DataTable dt = new DataTable();
        QLControls.CFLControl cfl = new QLControls.CFLControl();
        //int i = 0;
        //string oldsearch = "";
        //int oldsrow = 0;
        #endregion

        #region "Constructor"
            public FrmReceiveAdvance()
            {
                InitializeComponent();
                InitFormStyle();
                dgvList.MultiSelect = false;
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
                QLLoadSelectedReciveAdvance();
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
                QLLoadSelectedReciveAdvance();
            }
            public void MoveLastRecord() 
            {
                dgvList.Rows[dgvList.RowCount - 1].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", dgvList.RowCount - 1];
                QLLoadSelectedReciveAdvance();
            }
            public void MoveFirstRecord() 
            {
                dgvList.Rows[0].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", 0];
                QLLoadSelectedReciveAdvance();
            }
            public void FindMode() { }
            public void AddMode()
            {
                try
                {
                    QLLoadData();
                    QLClearErrorLabels();
                    QLClearData();
                    txtCustomerCode.Focus();
                }
                catch (Exception ex)
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
                Utilities.clsApplication.RemoveStyle(btnRefreshPrescription);
                txtCustomerCode.Properties.ReadOnly = true;
                txtSupplier.Properties.ReadOnly = true;
                dgvList.MultiSelect = false;
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

                        lblerrMobileNo.ForeColor = Color.Red;
                        lblerrMobileNo.Text = "Enter Mobile No";
                        valflag = false;
                    }
                    else
                        lblerrMobileNo.Text = "";

                    if (txtEmailId.Text.Trim() == "")
                    {

                        lblerrEmilid.ForeColor = Color.Red;
                        lblerrEmilid.Text = "Enter Email Id";
                        valflag = false;
                    }
                    else
                        lblerrEmilid.Text = "";

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

                        lblerrOrderno.ForeColor = Color.Red;
                        lblerrOrderno.Text = "Select Order No";
                        valflag = false;
                    }
                    else
                        lblerrOrderno.Text = "";

                    if (dateOrderdate.Text.Trim() == "")
                    {

                        lblerrOrderdate.ForeColor = Color.Red;
                        lblerrOrderdate.Text = "Select Order Date";
                        valflag = false;
                    }
                    else
                        lblerrOrderdate.Text = "";

                    if (dateDeliveryDate.Text.Trim() == "")
                    {

                        lblerrDeliverydate.ForeColor = Color.Red;
                        lblerrDeliverydate.Text = "Select Delivery Date";
                        valflag = false;
                    }
                    else
                        lblerrDeliverydate.Text = "";

                    if (dateDeleveryTime.Text.Trim() == "")
                    {

                        lblerrdeliverytime.ForeColor = Color.Red;
                        lblerrdeliverytime.Text = "Select Delivery Time";
                        valflag = false;
                    }
                    else
                        lblerrdeliverytime.Text = "";

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
            public string QLExecuteProcedure(int QLKey = 0)
            {
                try
                {
                    DataTable dthead = QLHeadData();
                    DataTable dtline = QLLineData();
                    string spResult = Utilities.clsApplication.QLOpticSPExec("CreOrUptRecAdvance", dthead, dtline, QLKey);
                    return spResult;
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString().Trim();
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
                HeadData.Columns.Add("TaxAmt", typeof(double));
                HeadData.Columns.Add("Roundoff", typeof(double));
                HeadData.Columns.Add("InvoiceAmt", typeof(double));
                HeadData.Columns.Add("CurrentAdvanse", typeof(double));
                HeadData.Columns.Add("BalanceAmt", typeof(double));

                DataRow HeadDataRow;
                HeadDataRow = HeadData.NewRow();
                //HeadDataRow["QLKey"] = 1;
                HeadDataRow["CustomerCode"] = txtCustomerCode.Text.Trim();
                HeadDataRow["Narration"] = rtxtNarration.Text.Trim();
                HeadDataRow["SupplierCode"] = txtSupplier.Text.Trim();
                HeadDataRow["OrderNo"] = txtOrderNo.Text.Trim();
                HeadDataRow["OrderDate"] = dateOrderdate.Text.Trim();
                HeadDataRow["DeliveryDate"] = dateDeliveryDate.Text.Trim();
                HeadDataRow["DeliveryTime"] = dateDeleveryTime.Text.Trim(); 

                HeadDataRow["DiscountRemarks"] = rtxtDiscountRemarks.Text.Trim();
                HeadDataRow["PaymentDate"] = datePaymentDate.Text.Trim();
                
                HeadDataRow["TotBefDiscount"] = (txtTotBefDiscount.Text.Trim() == "" ? "0" : txtTotBefDiscount.Text.Trim());
                HeadDataRow["OtherCharges"] = (txtOtherCharges.Text.Trim() == "" ? "0" : txtOtherCharges.Text.Trim());
                HeadDataRow["TaxAmt"] = (txtTaxAmt.Text.Trim() == "" ? "0" : txtTaxAmt.Text.Trim());
                HeadDataRow["RoundOff"] = (txtRoundoff.Text.Trim() == "" ? "0" : txtRoundoff.Text.Trim());
                HeadDataRow["InvoiceAmt"] = (txtInvAmt.Text.Trim() == "" ? "0" : txtInvAmt.Text.Trim());
                HeadDataRow["CurrentAdvanse"] = (txtCurrAdvance.Text.Trim() == "" ? "0" : txtCurrAdvance.Text.Trim());
                HeadDataRow["BalanceAmt"] = (txtBalAmt.Text.Trim() == "" ? "0" : txtBalAmt.Text.Trim());
                HeadDataRow["Discount"] = (txtDiscount.Text.Trim() == "" ? "0" : txtDiscount.Text.Trim());
                

                HeadData.Rows.Add(HeadDataRow);

                return HeadData;
            }
            public DataTable QLLineData()
            {
                DataTable LineData = new DataTable();
                LineData = ToDataTable(dgvBarcode);
                return LineData;
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
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Advance Receive Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    strqry = "select \"OrderDate\",\"DeliveryDate\",\"CustomerCode\",\"SupplierCode\",\"QLKey\" from QLOADV";
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
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
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

                                dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = (cell.Value == null) ? "0" : cell.Value.ToString();
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
            public void QLClearErrorLabels()
            {
                lblerrCustCode.Text = "";
                lblerrCustName.Text = "";
                lblerrDeliverydate.Text = "";
                lblerrdeliverytime.Text = "";
                lblerrEmilid.Text = "";
                lblerrLineDetails.Text = "";
                lblerrMobileNo.Text = "";
                lblerrNarration.Text = "";
                lblerrOrderdate.Text = "";
                lblerrOrderno.Text = "";
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
                dateOrderdate.Text = "";
                dateDeliveryDate.Text = "";
                dateDeleveryTime.Text = "";
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
            }
            public void QLLoadSelectedReciveAdvance()
            {
                try
                {
                    QLClearErrorLabels();
                    string currentQLKey = dgvList.Rows[dgvList.CurrentRow.Index].Cells["QLKey"].Value.ToString().Trim();
                    strqry = " select T0.CustomerCode,T0.Narration,T0.SupplierCode,T0.OrderNo,T0.OrderDate,";
                    strqry += " T0.DeliveryDate,T0.DeliveryTime,T0.DiscountRemarks,T0.PaymentDate,T0.TotBefDiscount,T0.Discount,T0.OtherCharges,";
                    strqry += " T0.TaxAmt,T0.RoundOff,T0.InvoiceAmt,T0.CurrentAdvanse,T0.BalanceAmt";
                    strqry += " ,T1.QLKey,T1.LineNum,T1.Barcode,T1.Product,";
                    strqry += " T1.Quantity,T1.UOM,T1.Rate,T1.Discount,T1.TaxPercent ";
                    strqry += " from QLOADV T0 ";
                    strqry += " inner join QLADV1 T1 on T0.QLKey = T1.QLKey";
                    strqry += " where T0.QLKey = " + currentQLKey;

                    dt = Utilities.clsApplication.FunFillDT(strqry);

                    txtQLKey.Text = dt.Rows[0]["QLKey"].ToString().Trim();
                    txtCustomerCode.Text = dt.Rows[0]["CustomerCode"].ToString().Trim();
                    rtxtNarration.Text = dt.Rows[0]["Narration"].ToString().Trim();
                    txtSupplier.Text = dt.Rows[0]["SupplierCode"].ToString().Trim();
                    txtOrderNo.Text = dt.Rows[0]["OrderNo"].ToString().Trim();
                    dateOrderdate.Text = dt.Rows[0]["OrderDate"].ToString().Trim();
                    dateDeliveryDate.Text = dt.Rows[0]["DeliveryDate"].ToString().Trim();
                    dateDeleveryTime.Text = dt.Rows[0]["DeliveryTime"].ToString().Trim();
                    rtxtDiscountRemarks.Text = dt.Rows[0]["DiscountRemarks"].ToString().Trim();
                    datePaymentDate.Text = dt.Rows[0]["PaymentDate"].ToString().Trim();
                   
                    txtTotBefDiscount.Text = dt.Rows[0]["TotBefDiscount"].ToString().Trim();
                    txtDiscount.Text = dt.Rows[0]["Discount"].ToString().Trim();
                    txtOtherCharges.Text = dt.Rows[0]["OtherCharges"].ToString().Trim();
                    txtTaxAmt.Text = dt.Rows[0]["TaxAmt"].ToString().Trim();
                    txtRoundoff.Text = dt.Rows[0]["RoundOff"].ToString().Trim();
                    txtTaxAmt.Text = dt.Rows[0]["InvoiceAmt"].ToString().Trim();
                    txtCurrAdvance.Text = dt.Rows[0]["CurrentAdvanse"].ToString().Trim();
                    txtBalAmt.Text = dt.Rows[0]["BalanceAmt"].ToString().Trim();
                    

                    //dgvBarcode.Columns["LQLKey"].Visible = true;
                    dgvBarcode.DataSource = null;
                    dgvBarcode.Rows.Clear();
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dgvBarcode.Rows.Add();
                        dgvBarcode.Rows[i].Cells["LQLKey"].Value = dt.Rows[i]["QLKey"].ToString().Trim();
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
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }

            public void QLLoadCustomerCFL()
            {
                int CFLX = Utilities.clsApplication.CFLXLocation + this.Location.X + pnlCustCode.Location.X + 6;
                int CFLY = 0;
                if (this.WindowState == FormWindowState.Maximized)
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlCustCode.Height + pnlLineTop.Height + txtCustomerCode.Height + 24;
                }
                else
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlCustCode.Height + pnlLineTop.Height + txtCustomerCode.Height + 4;
                }
                string CFLQuery = "SELECT \"Code\" 'CustomerCode',\"Name\" 'CustomerName',\"Grp\",\"Adress\",\"City\",\"StateName\",\"Pin\",\"Mobile\",\"Email\",\"DOB\",\"Age\",\"QLKey\" FROM QLCUST order by \"Code\"";
                int CFLWidth = txtCustomerCode.Width;
                int CFLHeight = tpnlTop.Height - pnlCustCode.Height;
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
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlSupplier.Height + pnlLineTop.Height + txtSupplier.Height + 24;
                }
                else
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlSupplier.Height + pnlLineTop.Height + txtSupplier.Height + 4;
                }
                string CFLQuery = "SELECT \"Code\" 'SupplierCode',\"Name\" 'SupplierName',\"Grp\",\"Adress\",\"City\",\"StateName\",\"Pin\",\"Mobile\",\"Email\",\"DOB\",\"Age\",\"QLKey\"  FROM QLSUPL order by \"Code\" ";
                int CFLWidth = txtSupplier.Width;
                int CFLHeight = tpnlTop.Height - pnlCustCode.Height;
                cfl.QLLoadCFL(CFLX, CFLY, CFLQuery, 2, CFLWidth, CFLHeight);
                if (Utilities.clsApplication.cflSelectedRow != null)
                {
                    DataRow cflSelection = Utilities.clsApplication.cflSelectedRow;
                    txtSupplier.Text = cflSelection["SupplierCode"].ToString();
                }
            }

        #endregion

        #region "Events"
            private void btnSave_Click(object sender, EventArgs e)
            {
                if (QLSave(Convert.ToInt32(txtQLKey.Text.Trim() == "" ? "0" : txtQLKey.Text.Trim())) == true)
                {
                    AddMode();
                }
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void FrmReceiveAdvance_Load(object sender, EventArgs e)
            {
                AddMode();
            }

            private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                QLLoadSelectedReciveAdvance();
            }
            private void txtCustomerCode_Click(object sender, EventArgs e)
            {
                QLLoadCustomerCFL();
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
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
        #endregion

            

    }
}
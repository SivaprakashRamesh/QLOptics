using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QL_Opticals.Presentation.Transactions
{
    public partial class FrmGenInvoice : DevExpress.XtraEditors.XtraForm,IGenInvoice
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
            public FrmGenInvoice()
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
                QLLoadSelectedGenInvoice();
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
                QLLoadSelectedGenInvoice();
            }
            public void MoveLastRecord() 
            {
                dgvList.Rows[dgvList.RowCount - 1].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", dgvList.RowCount - 1];
                QLLoadSelectedGenInvoice();
            }
            public void MoveFirstRecord() 
            {
                dgvList.Rows[0].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", 0];
                QLLoadSelectedGenInvoice();
            }
            public void FindMode() { }
            public void AddMode() 
            {
                QLLoadData();
                QLClearData();
                QLClearErrorLabels();
                txtCustomerCode.Focus();
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
                dgvList.MultiSelect = false;
            }
            public bool QLValidation()
            {
                bool valflag = true;

                try
                {
                    if (txtCustomerOrder.Text.Trim() == "")
                    {

                        lblerrCustorder.ForeColor = Color.Red;
                        lblerrCustorder.Text = "Enter Order No";
                        valflag = false;
                    }
                    else
                        lblerrCustorder.Text = "";

                    if (txtCustomerCode.Text.Trim() == "")
                    {

                        lblerrCustcode.ForeColor = Color.Red;
                        lblerrCustcode.Text = "Enter Code";
                        valflag = false;
                    }
                    else
                        lblerrCustcode.Text = "";

                    if (txtInvNo.Text.Trim() == "")
                    {

                        lblerrinvno.ForeColor = Color.Red;
                        lblerrinvno.Text = "Enter Invoice No";
                        valflag = false;
                    }
                    else
                        lblerrinvno.Text = "";

                    if (dateInvDate.Text.Trim() == "")
                    {

                        lblerrInvdate.ForeColor = Color.Red;
                        lblerrInvdate.Text = "Enter Invoice date";
                        valflag = false;
                    }
                    else
                        lblerrInvdate.Text = "";


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
            public DataTable QLHeadData()
            {
                DataTable HeadData = new DataTable();
                //HeadData.Columns.Add("QLKey", typeof(int));
                HeadData.Columns.Add("CustCode", typeof(string));
                HeadData.Columns.Add("CustOrder", typeof(string));
                HeadData.Columns.Add("InvNo", typeof(string));
                HeadData.Columns.Add("InvDate", typeof(DateTime));
                HeadData.Columns.Add("DiscountRemarks", typeof(string));
                HeadData.Columns.Add("DeliveryRemarks", typeof(string));
                HeadData.Columns.Add("BillingRemarks", typeof(string));
                HeadData.Columns.Add("TotBefDiscount", typeof(double));
                HeadData.Columns.Add("Discount", typeof(double));
                HeadData.Columns.Add("OtherCharges", typeof(double));
                HeadData.Columns.Add("TaxAmt", typeof(double));
                HeadData.Columns.Add("Roundoff", typeof(double));
                HeadData.Columns.Add("InvoiceAmt", typeof(double));
                HeadData.Columns.Add("PreviousAdvance", typeof(double));
                HeadData.Columns.Add("BalanceAmount", typeof(double));

                DataRow HeadDataRow;
                HeadDataRow = HeadData.NewRow();
                //HeadDataRow["QLKey"] = 1;
                HeadDataRow["CustCode"] = txtCustomerCode.Text.Trim();
                HeadDataRow["CustOrder"] = txtCustomerOrder.Text.Trim();
                HeadDataRow["InvNo"] = txtInvNo.Text.Trim();
                HeadDataRow["InvDate"] = dateInvDate.Text.Trim();
                HeadDataRow["DiscountRemarks"] = rtxtDiscountRemarks.Text.Trim();
                HeadDataRow["DeliveryRemarks"] = rtxtDeliveryRemarks.Text.Trim();
                HeadDataRow["BillingRemarks"] = rtxtBillingRemarks.Text.Trim();
                HeadDataRow["TotBefDiscount"] = txtTotBefDiscount.Text.Trim();
                HeadDataRow["Discount"] = txtDiscount.Text.Trim();
                HeadDataRow["OtherCharges"] = txtOtherCharges.Text.Trim();
                HeadDataRow["TaxAmt"] = txtTaxAmt.Text.Trim();
                HeadDataRow["Roundoff"] = txtRoundoff.Text.Trim();
                HeadDataRow["InvoiceAmt"] = txtInvAmt.Text.Trim();
                HeadDataRow["PreviousAdvance"] = txtPreAdvance.Text.Trim();
                HeadDataRow["BalanceAmount"] = txtInvAmt.Text.Trim();
                HeadData.Rows.Add(HeadDataRow);

                return HeadData;
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
                    DataTable dthead = QLHeadData();
                    DataTable dtline = QLLineData();
                    string spResult = Utilities.clsApplication.QLOpticSPExec("CreOrUptGenInvoice", dthead, dtline, QLKey);
                    return spResult;
                   

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
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Invoice Added Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    strqry = "select \"CustCode\",\"InvNo\",\"InvDate\",\"InvoiceAmt\",\"QLKey\" from QLOINV";
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
                        //QLLoadSelectedGenInvoice();
                        dgvList.Refresh();
                    }
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
            public void QLLoadSelectedGenInvoice()
            {
                try
                {
                    QLClearErrorLabels();
                    string currentQLKey = dgvList.Rows[dgvList.CurrentRow.Index].Cells["QLKey"].Value.ToString().Trim();
                    strqry = " select T0.CustCode,T0. CustOrder,T0.InvNo,T0.InvDate,";
                    strqry += " T0.DiscountRemarks,T0.DeliveryRemarks,T0.BillingRemarks,";
                    strqry += "T0.TotBefDiscount,T0.Discounts,T0.OtherCharges,";
                    strqry += " T0.TaxAmt,T0.Roundoff,T0.InvoiceAmt,T0.PreviousAdvance,T0.BalanceAmount,T1.QLKey,T1.LineNum,";
                    strqry += " T1.Barcode,T1.Product,T1.Quantity,T1.UOM,T1.Rate,T1.Discount,T1.TaxPercent";
                    strqry += " from QLOINV T0 ";
                    strqry += " inner join QLINV1 T1 on T1.QLKey = T0.QLKey";
                    strqry += " where T0.QLKey = " + currentQLKey;

                    dt = Utilities.clsApplication.FunFillDT(strqry);

                    txtQLKey.Text = dt.Rows[0]["QLKey"].ToString().Trim();
                    txtCustomerCode.Text = dt.Rows[0]["CustCode"].ToString().Trim();
                    txtCustomerOrder.Text = dt.Rows[0]["CustOrder"].ToString().Trim();
                    txtInvNo.Text = dt.Rows[0]["InvNo"].ToString().Trim();
                    dateInvDate.Text = dt.Rows[0]["InvDate"].ToString().Trim();
                    rtxtDiscountRemarks.Text = dt.Rows[0]["DiscountRemarks"].ToString().Trim();
                    rtxtDeliveryRemarks.Text = dt.Rows[0]["DeliveryRemarks"].ToString().Trim();
                    rtxtBillingRemarks.Text = dt.Rows[0]["BillingRemarks"].ToString().Trim();
                    
                    txtTotBefDiscount.Text = dt.Rows[0]["TotBefDiscount"].ToString().Trim();
                    txtDiscount.Text = dt.Rows[0]["Discount"].ToString().Trim();
                    txtOtherCharges.Text = dt.Rows[0]["OtherCharges"].ToString().Trim();
                    txtTaxAmt.Text = dt.Rows[0]["TaxAmt"].ToString().Trim();
                    txtRoundoff.Text = dt.Rows[0]["Roundoff"].ToString().Trim();
                    txtInvAmt.Text = dt.Rows[0]["InvoiceAmt"].ToString().Trim();
                    txtPreAdvance.Text = dt.Rows[0]["PreviousAdvance"].ToString().Trim();
                    txtBalAmt.Text = dt.Rows[0]["BalanceAmount"].ToString().Trim();

                    //dgvBarcode.Columns["LQLKey"].Visible = true;
                    dgvBarcode.DataSource = null;
                    dgvBarcode.Rows.Clear();
                    for(int i=0;i<=dt.Rows.Count -1;i++)
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
                catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
            public void QLClearErrorLabels()
            {
                lblerrCustcode.Text = "";
                lblerrCustorder.Text = "";
                lblerrinvno.Text = "";
                lblerrInvdate.Text = "";
                lblerrLineDetails.Text = "";
            }
            public void QLClearData()
            {
                dgvBarcode.Rows.Clear();
                txtCustomerCode.Text = "";
                txtCustomerOrder.Text = "";
                txtInvNo.Text = "";
                rtxtDiscountRemarks.Text = "";
                rtxtDeliveryRemarks.Text = "";
                rtxtBillingRemarks.Text = "";
                txtTotBefDiscount.Text = "";
                txtDiscount.Text = "";
                txtOtherCharges.Text = "";
                txtTaxAmt.Text = "";
                txtRoundoff.Text = "";
                txtInvAmt.Text = "";
                txtPreAdvance.Text = "";
                txtBalAmt.Text = "";
                txtQLKey.Text = "";
            }
            public void QLLoadCustomerCFL()
            {
                int CFLX = Utilities.clsApplication.CFLXLocation + this.Location.X + pnlCustCode.Location.X + 6;
                int CFLY = 0;
                if (this.WindowState == FormWindowState.Maximized)
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlCustCode.Height + pnlLineTop.Height + 27;
                }
                else
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlCustCode.Height + pnlLineTop.Height +7;
                }
                string CFLQuery = "SELECT \"Code\" 'CustomerCode',\"Name\" 'CustomerName',\"Grp\",\"Adress\",\"City\",\"StateName\",\"Pin\",\"Mobile\",\"Email\",\"DOB\",\"Age\",\"QLKey\" FROM QLCUST order by \"Code\"";
                int CFLWidth = txtCustomerCode.Width;
                int CFLHeight = tpnlTop.Height + (dgvBarcode.Height/2);
                cfl.QLLoadCFL(CFLX, CFLY, CFLQuery, 2, CFLWidth, CFLHeight);
                if (Utilities.clsApplication.cflSelectedRow != null)
                {
                    DataRow cflSelection = Utilities.clsApplication.cflSelectedRow;
                    txtCustomerCode.Text = cflSelection["CustomerCode"].ToString();
                    
                }
            }
        #endregion

        #region "Events"
            private void btnSave_Click(object sender, EventArgs e)
            {
                if(QLSave(Convert.ToInt32(txtQLKey.Text.Trim() == "" ? "0" : txtQLKey.Text.Trim()))== true)
                {
                    AddMode();
                }
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void FrmGenInvoice_Load(object sender, EventArgs e)
            {
                AddMode();
            }

            private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            QLLoadSelectedGenInvoice();
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
        #endregion

    }
}
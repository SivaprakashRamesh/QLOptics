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
    public partial class FrmSalesReturn : DevExpress.XtraEditors.XtraForm,ISalesReturn
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
            public FrmSalesReturn()
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
                QLLoadSelectedSalesReturn();
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
                QLLoadSelectedSalesReturn();
            }
            public void MoveLastRecord()
            {
                dgvList.Rows[dgvList.RowCount - 1].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", dgvList.RowCount - 1];
                QLLoadSelectedSalesReturn();
            }
            public void MoveFirstRecord()
            {
                dgvList.Rows[0].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", 0];
                QLLoadSelectedSalesReturn();
            }
            public void FindMode() { }
            public void AddMode()
            {
                try
                {
                    QLClearErrorLabels();
                    QLLoadData();
                    QLClearData();
                    txtInvNo.Focus();
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
                dgvList.MultiSelect = false;
                txtCustomerName.Properties.ReadOnly = true;
            }
            public bool QLValidation()
            {
                bool valflag = true;

                try
                {

                    if (txtInvNo.Text.Trim() == "")
                    {

                        lblerrInvNo.ForeColor = Color.Red;
                        lblerrInvNo.Text = "Enter Invoice No";
                        valflag = false;
                    }
                    else
                        lblerrInvNo.Text = "";

                    if (dateInvDate.Text.Trim() == "")
                    {

                        lblerrInvDate.ForeColor = Color.Red;
                        lblerrInvDate.Text = "Enter Invoice Date";
                        valflag = false;
                    }
                    else
                        lblerrInvDate.Text = "";

                    if (txtSalesRetunNo.Text.Trim() == "")
                    {

                        lblerrSalesRtnNo.ForeColor = Color.Red;
                        lblerrSalesRtnNo.Text = "Enter Return No";
                        valflag = false;
                    }
                    else
                        lblerrSalesRtnNo.Text = "";

                    if (dateSalesReturnDate.Text.Trim() == "")
                    {

                        lblerrSalesRtnDate.ForeColor = Color.Red;
                        lblerrSalesRtnDate.Text = "Enter Retun Date";
                        valflag = false;
                    }
                    else
                        lblerrSalesRtnDate.Text = "";

                    if (txtCustomerName.Text.Trim() == "")
                    {

                        lblerrCustomerName.ForeColor = Color.Red;
                        lblerrCustomerName.Text = "Enter Customer Name";
                        valflag = false;
                    }
                    else
                        lblerrCustomerName.Text = "";

                    if (txtOtherCharges.Text.Trim() == "")
                    {

                        lblerrOtherCharges.ForeColor = Color.Red;
                        lblerrOtherCharges.Text = "Enter Other Charges";
                        valflag = false;
                    }
                    else
                        lblerrOtherCharges.Text = "";

                    if (txtRoundingOff.Text.Trim() == "")
                    {

                        lblerrRoundOff.ForeColor = Color.Red;
                        lblerrRoundOff.Text = "Enter Round Off";
                        valflag = false;
                    }
                    else
                        lblerrRoundOff.Text = "";

                    if (txtSalesReturnValue.Text.Trim() == "")
                    {

                        lblerrSalesRtnVal.ForeColor = Color.Red;
                        lblerrSalesRtnVal.Text = "Enter Return Value";
                        valflag = false;
                    }
                    else
                        lblerrSalesRtnVal.Text = "";

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
            public DataTable QLHeadData()
            {
                DataTable HeadData = new DataTable();
                //HeadData.Columns.Add("QLKey", typeof(int));
                HeadData.Columns.Add("InvNo", typeof(string));
                HeadData.Columns.Add("InvDate", typeof(DateTime));
                HeadData.Columns.Add("SalesRtnNo", typeof(int));
                HeadData.Columns.Add("SalesRtnDate", typeof(DateTime));
                HeadData.Columns.Add("CustName", typeof(string));
                HeadData.Columns.Add("Remarks", typeof(string));
                HeadData.Columns.Add("OtherCharges", typeof(double));
                HeadData.Columns.Add("RoundOff", typeof(double));
                HeadData.Columns.Add("SalesRtnVal", typeof(double));
                HeadData.Columns.Add("CustCode", typeof(string));

                DataRow HeadDataRow;
                HeadDataRow = HeadData.NewRow();
                //HeadDataRow["QLKey"] = 1;
                HeadDataRow["InvNo"] = txtInvNo.Text.Trim();
                HeadDataRow["InvDate"] = dateInvDate.Text.Trim();
                HeadDataRow["SalesRtnNo"] = txtSalesRetunNo.Text.Trim();
                HeadDataRow["SalesRtnDate"] = dateSalesReturnDate.Text.Trim();
                HeadDataRow["CustName"] = txtCustomerName.Text.Trim();
                HeadDataRow["Remarks"] = rtxtRemarks.Text.Trim();
                HeadDataRow["OtherCharges"] = txtOtherCharges.Text.Trim();
                HeadDataRow["RoundOff"] = txtRoundingOff.Text.Trim();
                HeadDataRow["SalesRtnVal"] = txtSalesReturnValue.Text.Trim();
                HeadDataRow["CustCode"] = (txtCustCode.Text.Trim() == "" ? "0" : txtCustCode.Text.Trim());
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

                    DataTable dthead = QLHeadData();
                    DataTable dtline = QLLineData();
                    string spResult = Utilities.clsApplication.QLOpticSPExec("CreOrUptSaleRtn", dthead, dtline, QLKey);
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
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Sales Return Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    strqry = "select \"SalesRtnDate\" 'Sales Return Date',\"SalesRtnNo\" 'Sales Return No',\"CustName\" 'Customer Name', \"SalesRtnVal\" 'Sales Return Value',\"QLKey\" from QLORTN";
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
            public void QLLoadSelectedSalesReturn()
            {
                try
                {
                    QLClearErrorLabels();
                    string currentQLKey = dgvList.Rows[dgvList.CurrentRow.Index].Cells["QLKey"].Value.ToString().Trim();
                    strqry = " select T0.InvNo,T0.InvDate,T0.SalesRtnNo,T0.SalesRtnDate,T0.CustName,T0.CustCode,T0.Remarks,T0.OtherCharges,T0.RoundOff,T0.SalesRtnVal,";
                    strqry += " T1.QLKey,T1.LineNum,T1.Barcode,T1.Product,T1.Quantity,T1.UOM,T1.Rate,T1.Discount,T1.TaxPercent ";
                    strqry += " from QLORTN T0 ";
                    strqry += " INNER JOIN QLRTN1 T1 ON T0.QLKey = T1.QLKey";
                    strqry += " where T0.QLKey = " + currentQLKey;

                    dt = Utilities.clsApplication.FunFillDT(strqry);
                    
                    txtQLKey.Text = dt.Rows[0]["QLKey"].ToString().Trim();
                    txtInvNo.Text = dt.Rows[0]["InvNo"].ToString().Trim();
                    dateInvDate.Text = dt.Rows[0]["InvDate"].ToString().Trim();
                    txtSalesRetunNo.Text = dt.Rows[0]["SalesRtnNo"].ToString().Trim();
                    dateSalesReturnDate.Text = dt.Rows[0]["SalesRtnDate"].ToString().Trim();
                    txtCustomerName.Text = dt.Rows[0]["CustName"].ToString().Trim();
                    txtCustCode.Text = dt.Rows[0]["CustCode"].ToString().Trim();
                    rtxtRemarks.Text = dt.Rows[0]["Remarks"].ToString().Trim();
                    txtOtherCharges.Text = dt.Rows[0]["OtherCharges"].ToString().Trim();
                    txtRoundingOff.Text = dt.Rows[0]["RoundOff"].ToString().Trim();
                    txtSalesReturnValue.Text = dt.Rows[0]["SalesRtnVal"].ToString().Trim();
                    
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
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
            public void QLFetch(int QLKey)
            {

            }
            public void QLClearErrorLabels()
            {
                lblerrInvNo.Text = "";
                lblerrInvDate.Text = "";
                lblerrSalesRtnNo.Text = "";
                lblerrSalesRtnDate.Text = "";
                lblerrCustomerName.Text = "";
                lblerrOtherCharges.Text = "";
                lblerrRoundOff.Text = "";
                lblerrSalesRtnVal.Text = "";
            }
            public void QLClearData()
            {
                dgvBarcode.Rows.Clear();
                txtInvNo.Text = "";
                dateInvDate.Text = "";
                txtSalesRetunNo.Text = "";
                dateSalesReturnDate.Text = "";
                txtCustomerName.Text = "";
                txtCustCode.Text = "";
                rtxtRemarks.Text = "";
                txtOtherCharges.Text = "";
                txtRoundingOff.Text = "";
                txtSalesReturnValue.Text = "";
                txtQLKey.Text = "";
            }
            public void QLLoadCustomerCFL()
            {
                int CFLX = Utilities.clsApplication.CFLXLocation + this.Location.X +tpnlTopRight.Location.X + pnlCustomerName.Location.X +3;
                int CFLY = 0;
                if (this.WindowState == FormWindowState.Maximized)
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlCustomerName.Height + pnlLineTop.Height + txtCustomerName.Height + 20;
                }
                else
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlCustomerName.Height + pnlLineTop.Height + txtCustomerName.Height ;
                }
                string CFLQuery = "SELECT \"Code\" 'CustomerCode',\"Name\" 'CustomerName',\"Grp\",\"Adress\",\"City\",\"StateName\",\"Pin\",\"Mobile\",\"Email\",\"DOB\",\"Age\",\"QLKey\" FROM QLCUST order by \"Code\"";
                int CFLWidth = txtCustomerName.Width;
                int CFLHeight = tpnlTop.Height + 10 - pnlCustomerName.Height;
                cfl.QLLoadCFL(CFLX, CFLY, CFLQuery, 2, CFLWidth, CFLHeight);
                if (Utilities.clsApplication.cflSelectedRow != null)
                {
                    DataRow cflSelection = Utilities.clsApplication.cflSelectedRow;
                    txtCustomerName.Text = cflSelection["CustomerName"].ToString();
                    txtCustCode.Text = cflSelection["CustomerCode"].ToString();
                }
            }
        #endregion

        #region "Events"
            private void FrmSalesReturn_Load(object sender, EventArgs e)
            {
                AddMode();
            }
            private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                QLLoadSelectedSalesReturn();
            }
            private void btnSave_Click(object sender, EventArgs e)
            {
                if(QLSave(Convert.ToInt32(txtQLKey.Text.Trim() == "" ? "0" : txtQLKey.Text.Trim())) == true)
                {
                    AddMode();
                }
            }
            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }
            private void txtCustomerName_Click(object sender, EventArgs e)
            {
                QLLoadCustomerCFL();
            }
            private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
            {
                QLLoadCustomerCFL();
            }
        #endregion

    }
}
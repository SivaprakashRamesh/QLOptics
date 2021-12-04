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
    public partial class FrmReplacement : DevExpress.XtraEditors.XtraForm,IReplacement
    {

        #region "Declaration"
        string strqry = "";
        DataTable dt = new DataTable();
        //int i = 0;
        //string oldsearch = "";
        //int oldsrow = 0;
        #endregion

        #region "Constructor"
            public FrmReplacement()
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
                QLLoadSelectedReplacement();
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
                QLLoadSelectedReplacement();
            }
            public void MoveLastRecord() 
            {
                dgvList.Rows[dgvList.RowCount - 1].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", dgvList.RowCount - 1];
                QLLoadSelectedReplacement();
            }
            public void MoveFirstRecord()
            {
                dgvList.Rows[0].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", 0];
                QLLoadSelectedReplacement();
            }
            public void FindMode() { }
            public void AddMode() 
            {
                try
                {
                    QLLoadData();
                    QLClearData();
                    QLClearErrorLabels();
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
                xtraTabInvoice.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            }
            public bool QLValidation()
            {
                bool valflag = true;

                try
                {

                    if (txtInvNo.Text.Trim() == "")
                    {

                        lblerrInvno.ForeColor = Color.Red;
                        lblerrInvno.Text = "Enter Invoice No";
                        valflag = false;
                    }
                    else
                        lblerrInvno.Text = "";

                    if (dateInvDate.Text.Trim() == "")
                    {

                        lblerrInvDate.ForeColor = Color.Red;
                        lblerrInvDate.Text = "Enter Invoice Date";
                        valflag = false;
                    }
                    else
                        lblerrInvDate.Text = "";

                    if (txtOtherCharge.Text.Trim() == "")
                    {

                        lblerrOtherCharge.ForeColor = Color.Red;
                        lblerrOtherCharge.Text = "Enter Sales Return No";
                        valflag = false;
                    }
                    else
                        lblerrOtherCharge.Text = "";

                    if (txtSaleRtnVal.Text.Trim() == "")
                    {

                        lblerrSaleRtn.ForeColor = Color.Red;
                        lblerrSaleRtn.Text = "Enter Sales Retun Date";
                        valflag = false;
                    }
                    else
                        lblerrSaleRtn.Text = "";

                    if (txtNewInvAmt.Text.Trim() == "")
                    {

                        lblerrNewInvAmt.ForeColor = Color.Red;
                        lblerrNewInvAmt.Text = "Enter Customer Name";
                        valflag = false;
                    }
                    else
                        lblerrNewInvAmt.Text = "";

                   

                    if (txtNetReciv.Text.Trim() == "")
                    {

                        lblerrNetReceivable.ForeColor = Color.Red;
                        lblerrNetReceivable.Text = "Select Rounding Off";
                        valflag = false;
                    }
                    else
                        lblerrNetReceivable.Text = "";

                    if (txtRecvAmt.Text.Trim() == "")
                    {

                        lblerrRecAmt.ForeColor = Color.Red;
                        lblerrRecAmt.Text = "Select Sales Return Value";
                        valflag = false;
                    }
                    else
                        lblerrRecAmt.Text = "";
                   
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
                HeadData.Columns.Add("InvNo", typeof(string));
                HeadData.Columns.Add("InvDate", typeof(DateTime));
                HeadData.Columns.Add("OtherCharges", typeof(double));
                HeadData.Columns.Add("SaleReturnVal", typeof(double));
                HeadData.Columns.Add("InvAmt", typeof(double));
                HeadData.Columns.Add("NetReceivable", typeof(double));
                HeadData.Columns.Add("ReceivableAmt", typeof(double));
                

                DataRow HeadDataRow;
                HeadDataRow = HeadData.NewRow();
                //HeadDataRow["QLKey"] = 1;
                HeadDataRow["InvNo"] = txtInvNo.Text.Trim();
                HeadDataRow["InvDate"] = dateInvDate.Text.Trim();
                HeadDataRow["OtherCharges"] = txtOtherCharge.Text.Trim();
                HeadDataRow["SaleReturnVal"] = txtSaleRtnVal.Text.Trim();
                HeadDataRow["InvAmt"] = txtNewInvAmt.Text.Trim();
                HeadDataRow["NetReceivable"] = txtNetReciv.Text.Trim();
                HeadDataRow["ReceivableAmt"] = txtRecvAmt.Text.Trim();
                
                HeadData.Rows.Add(HeadDataRow);

                return HeadData;
            }
            public DataTable QLLineData()
            {
                DataTable LineData = new DataTable();
                LineData = ToDataTable(dgvBarcode);
                return LineData;
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
            public string QLExecuteProcedure(int QLKey = 0)
            {
                try
                {

                    DataTable dthead = QLHeadData();
                    DataTable dtline = QLLineData();
                    string spResult = Utilities.clsApplication.QLOpticSPExec("CreOrUptReplacement", dthead, dtline, QLKey);
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
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Replacement Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    strqry = "select \"InvDate\",\"SaleReturnVal\",\"InvAmt\",\"ReceivableAmt\",\"QLKey\" from QLOREP";
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
            public void QLLoadSelectedReplacement()
            {
                try
                {
                    QLClearErrorLabels();
                    string currentQLKey = dgvList.Rows[dgvList.CurrentRow.Index].Cells["QLKey"].Value.ToString().Trim();
                    strqry = " select T0.InvNo,T0.InvDate,T0.OtherCharges,T0.SaleReturnVal,T0.InvAmt,T0.NetReceivable,T0.ReceivableAmt,";
                    strqry += " T1.QLKey,T1.LineNum,T1.Barcode,T1.Product,T1.Quantity,T1.UOM,T1.Rate,T1.Discount,T1.TaxPercent ";
                    strqry += " from QLOREP T0 ";
                    strqry += " INNER JOIN QLREP1 T1 ON T0.QLKey = T1.QLKey";
                    strqry += " where T0.QLKey = " + currentQLKey;

                    dt = Utilities.clsApplication.FunFillDT(strqry);

                    txtQLKey.Text = dt.Rows[0]["QLKey"].ToString().Trim();
                    txtInvNo.Text = dt.Rows[0]["InvNo"].ToString().Trim();
                    dateInvDate.Text = dt.Rows[0]["InvDate"].ToString().Trim();
                    txtOtherCharge.Text = dt.Rows[0]["OtherCharges"].ToString().Trim();
                    txtSaleRtnVal.Text = dt.Rows[0]["SaleReturnVal"].ToString().Trim();
                    txtNewInvAmt.Text = dt.Rows[0]["InvAmt"].ToString().Trim();
                    txtNetReciv.Text = dt.Rows[0]["NetReceivable"].ToString().Trim();
                    txtRecvAmt.Text = dt.Rows[0]["ReceivableAmt"].ToString().Trim();
                    

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
                lblerrInvDate.Text = "";
                lblerrInvno.Text = "";
                lblerrLineDetails.Text = "";
                lblerrNetReceivable.Text = "";
                lblerrNewInvAmt.Text = "";
                lblerrOtherCharge.Text = "";
                lblerrRecAmt.Text = "";
                lblerrSaleRtn.Text = "";
            }
            public void QLClearData()
            {
                dgvBarcode.Rows.Clear();
                txtInvNo.Text = "";
                dateInvDate.Text = "";
                txtOtherCharge.Text = "";
                txtSaleRtnVal.Text = "";
                txtNewInvAmt.Text = "";
                txtNetReciv.Text = "";
                txtRecvAmt.Text = "";
                txtQLKey.Text = "";
            }
        #endregion

        #region "Events"
            private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                if (QLSave(Convert.ToInt32(txtQLKey.Text.Trim() == "" ? "0" : txtQLKey.Text.Trim())) == true)
                {
                    AddMode();
                }
            }

            private void FrmReplacement_Load(object sender, EventArgs e)
            {
                AddMode();
            }

            private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                QLLoadSelectedReplacement();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        #endregion

    }
}
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
    public partial class FrmSendStockOut : DevExpress.XtraEditors.XtraForm,ISendStockOut
    {

        #region "Declaration"
            string strqry = "";
            DataTable dt = new DataTable();
            //int i = 0;
            //string oldsearch = "";
            //int oldsrow = 0;
        #endregion

        #region "Constructor"
            public FrmSendStockOut()
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
                    txtTransferTo.Focus();
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
            }
            public bool QLValidation()
            {
                bool valflag = true;

                try
                {
                   
                    if (txtTransferTo.Text.Trim() == "")
                    {

                        lblerrTransferTo.ForeColor = Color.Red;
                        lblerrTransferTo.Text = "Enter Transfer To";
                        valflag = false;
                    }
                    else
                        lblerrTransferTo.Text = "";

                    if (txtDoumentNo.Text.Trim() == "")
                    {

                        lblerrDocNo.ForeColor = Color.Red;
                        lblerrDocNo.Text = "Enter Document No";
                        valflag = false;
                    }
                    else
                        lblerrDocNo.Text = "";
                    
                    if (dateDate.Text.Trim() == "")
                    {

                        lblerrDate.ForeColor = Color.Red;
                        lblerrDate.Text = "Enter Date";
                        valflag = false;
                    }
                    else
                        lblerrDate.Text = "";

                    if (txtTotQty.Text.Trim() == "")
                    {

                        lblerrTotQty.ForeColor = Color.Red;
                        lblerrTotQty.Text = "Enter Total Quantity";
                        valflag = false;
                    }
                    else
                        lblerrTotQty.Text = "";

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
                HeadData.Columns.Add("TransTo", typeof(string));
                HeadData.Columns.Add("DocNum", typeof(string));
                HeadData.Columns.Add("DocDate", typeof(DateTime));
                HeadData.Columns.Add("Narration", typeof(string));
                HeadData.Columns.Add("TotQuantity", typeof(string));

                DataRow HeadDataRow;
                HeadDataRow = HeadData.NewRow();
                //HeadDataRow["QLKey"] = 1;
                HeadDataRow["TransTo"] = txtTransferTo.Text.Trim();
                HeadDataRow["DocNum"] = txtDoumentNo.Text.Trim();
                HeadDataRow["DocDate"] = dateDate.Text.Trim();
                HeadDataRow["Narration"] = rtxtNarration.Text.Trim();
                HeadDataRow["TotQuantity"] = txtTotQty.Text.Trim();
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
                    string spResult = Utilities.clsApplication.QLOpticSPExec("CreOrUptStockOut", dthead, dtline, QLKey);
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
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Stock Out Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    strqry = "select \"DocNum\" 'Transfer Date',\"TransTo\" 'Transfer To',\"TotQuantity\" 'Total Quantity',\"QLKey\" from QLOSTKOUT";
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
                    strqry = " SELECT T0.TransTo,T0.DocNum,T0.DocDate,T0.Narration,T0.TotQuantity,";
                    strqry += " T1.QLKey,T1.LineNum,T1.Barcode,T1.Product,T1.Quantity,T1.UOM,T1.Rate,T1.Discount,T1.TaxPercent ";
                    strqry += " FROM QLOSTKOUT T0 ";
                    strqry += " INNER JOIN QLSTKOUT1 T1 ON T0.QLKey = T1.QLKey";
                    strqry += " where T0.QLKey = " + currentQLKey;

                    dt = Utilities.clsApplication.FunFillDT(strqry);

                    txtQLKey.Text = dt.Rows[0]["QLKey"].ToString().Trim();
                    txtTransferTo.Text = dt.Rows[0]["TransTo"].ToString().Trim();
                    txtDoumentNo.Text = dt.Rows[0]["DocNum"].ToString().Trim();
                    dateDate.Text = dt.Rows[0]["DocDate"].ToString().Trim();
                    rtxtNarration.Text = dt.Rows[0]["Narration"].ToString().Trim();
                    txtSearch.Text = dt.Rows[0]["TotQuantity"].ToString().Trim();
                    
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
                lblerrTransferTo.Text = "";
                lblerrDocNo.Text = "";
                lblerrDate.Text = "";
                lblerrTotQty.Text = "";
            }
            public void QLClearData()
            {
                dgvBarcode.Rows.Clear();
                txtTransferTo.Text = "";
                txtDoumentNo.Text = "";
                dateDate.Text = "";
                rtxtNarration.Text = "";
                txtSearch.Text = "";
                txtQLKey.Text = "";
            }
        #endregion

        #region "Events"
            private void FrmSendStockOut_Load(object sender, EventArgs e)
            {
                AddMode();
            }

            private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                QLLoadSelectedSalesReturn();
            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                if(QLSave(Convert.ToInt32(txtQLKey.Text.Trim() == "" ? "0" : txtQLKey.Text.Trim())) ==true)
                {
                    AddMode();
                }
            }
        
            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        #endregion

    }
}
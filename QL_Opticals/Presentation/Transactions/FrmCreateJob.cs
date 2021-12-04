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
    public partial class FrmCreateJob : DevExpress.XtraEditors.XtraForm,ICreateJob
    {

        #region "Declaration"
            string strqry = "";
            DataTable dt = new DataTable();
            QLControls.CFLControl cfl = new QLControls.CFLControl();
            //int i = 0;
           // string oldsearch = "";
            //int oldsrow = 0;
        #endregion

        #region "Constructor"
            public FrmCreateJob()
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
                QLLoadSelectedCounterSales();
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
                QLLoadSelectedCounterSales();
            }
            public void MoveLastRecord()
            {
                dgvList.Rows[dgvList.RowCount - 1].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", dgvList.RowCount - 1];
                QLLoadSelectedCounterSales();
            }
            public void MoveFirstRecord()
            {
                dgvList.Rows[0].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", 0];
                QLLoadSelectedCounterSales();
            }
            public void FindMode() { }
            public void AddMode()
            {
                try
                {
                    QLClearData();
                    QLLoadData();
                    QLClearErrorLabels();
                    txtSupplier.Focus();
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
                txtSupplier.Properties.ReadOnly = true;
                txtCustomerCode.Properties.ReadOnly = true;
                dgvList.MultiSelect = false;
            }
            public bool QLValidation()
            {
                bool valflag = true;

                try
                {
                    
                    if (txtSupplier.Text.Trim() == "")
                    {

                        lblerrSupplier.ForeColor = Color.Red;
                        lblerrSupplier.Text = "Enter Supplier";
                        valflag = false;
                    }
                    else
                        lblerrSupplier.Text = "";

                    if (txtCustomerCode.Text.Trim() == "")
                    {

                        lblerrCustomer.ForeColor = Color.Red;
                        lblerrCustomer.Text = "Enter Customer ";
                        valflag = false;
                    }
                    else
                        lblerrCustomer.Text = "";

                    if (txtOrderNo.Text.Trim() == "")
                    {

                        lblerrOrderNo.ForeColor = Color.Red;
                        lblerrOrderNo.Text = "Enter Order No";
                        valflag = false;
                    }
                    else
                        lblerrOrderNo.Text = "";

                    if (dateDeliveryDate.Text.Trim() == "")
                    {

                        lblerrOrderDueDate.ForeColor = Color.Red;
                        lblerrOrderDueDate.Text = "Enter Delivery Date";
                        valflag = false;
                    }
                    else
                        lblerrOrderDueDate.Text = "";
                    
                    if (cmbLensType.Text.Trim() == "")
                    {

                        lblerrLensType.ForeColor = Color.Red;
                        lblerrLensType.Text = "Enter Lens Type";
                        valflag = false;
                    }
                    else
                        lblerrLensType.Text = "";

                    if (cmbOrderType.Text.Trim() == "")
                    {

                        lblerrOrderType.ForeColor = Color.Red;
                        lblerrOrderType.Text = "Enter Order Type";
                        valflag = false;
                    }
                    else
                        lblerrOrderType.Text = "";

                    if (txtJONO.Text.Trim() == "")
                    {

                        lblerrJoNo.ForeColor = Color.Red;
                        lblerrJoNo.Text = "Enter JO NO";
                        valflag = false;
                    }
                    else
                        lblerrJoNo.Text = "";

                    if (dateJODate.Text.Trim() == "")
                    {

                        lblerrJoDate.ForeColor = Color.Red;
                        lblerrJoDate.Text = "Enter JO Date";
                        valflag = false;
                    }
                    else
                        lblerrJoDate.Text = "";

                    if (dateDeliveryDate.Text.Trim() == "")
                    {

                        lblerrDeliveryDate.ForeColor = Color.Red;
                        lblerrDeliveryDate.Text = "Enter Delivery Date";
                        valflag = false;
                    }
                    else
                        lblerrDeliveryDate.Text = "";

                    if (rtxtNarration.Text.Trim() == "")
                    {

                        lblerrNarration.ForeColor = Color.Red;
                        lblerrNarration.Text = "Enter Narration";
                        valflag = false;
                    }
                    else
                        lblerrNarration.Text = "";

                    if (txtFitCharges.Text.Trim() == "")
                    {

                        lblerrFitCharges.ForeColor = Color.Red;
                        lblerrFitCharges.Text = "Enter Fitting Charges";
                        valflag = false;
                    }
                    else
                        lblerrFitCharges.Text = "";

                    if (rtxtFitNarration.Text.Trim() == "")
                    {

                        lblerrFitNarration.ForeColor = Color.Red;
                        lblerrFitNarration.Text = "Enter Fitting Narration";
                        valflag = false;
                    }
                    else
                        lblerrFitNarration.Text = "";

                    if (txtTotAmt.Text.Trim() == "")
                    {

                        lblerrTotalAmt.ForeColor = Color.Red;
                        lblerrTotalAmt.Text = "Enter Total Amount";
                        valflag = false;
                    }
                    else
                        lblerrTotalAmt.Text = "";

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
                HeadData.Columns.Add("SupplierCode", typeof(string));
                HeadData.Columns.Add("CustomerCode", typeof(string));
                HeadData.Columns.Add("OrderNo", typeof(string));
                HeadData.Columns.Add("OrderDueDate", typeof(DateTime));
                HeadData.Columns.Add("OrderType", typeof(string));
                HeadData.Columns.Add("LensType", typeof(string));
                HeadData.Columns.Add("JONo", typeof(string));
                HeadData.Columns.Add("JODate", typeof(DateTime));
                HeadData.Columns.Add("DeliveryDate", typeof(DateTime));
                HeadData.Columns.Add("Narration", typeof(string));
                HeadData.Columns.Add("FittingCharges", typeof(double));
                HeadData.Columns.Add("FittingNarration", typeof(string));
                HeadData.Columns.Add("TotAmt", typeof(double));

                DataRow HeadDataRow;
                HeadDataRow = HeadData.NewRow();
                //HeadDataRow["QLKey"] = 1;
                HeadDataRow["SupplierCode"] = txtSupplier.Text.Trim();
                HeadDataRow["CustomerCode"] = txtCustomerCode.Text.Trim();
                HeadDataRow["OrderNo"] = txtOrderNo.Text.Trim();
                HeadDataRow["OrderDueDate"] = dateOrderDueDate.Text.Trim();
                HeadDataRow["OrderType"] = cmbOrderType.Text.Trim();
                HeadDataRow["LensType"] = cmbLensType.Text.Trim();
                HeadDataRow["JONo"] = txtJONO.Text.Trim();
                HeadDataRow["JODate"] = dateJODate.Text.Trim();
                HeadDataRow["DeliveryDate"] = dateDeliveryDate.Text.Trim();
                HeadDataRow["Narration"] = rtxtNarration.Text.Trim();
                HeadDataRow["FittingCharges"] = txtFitCharges.Text.Trim();
                HeadDataRow["FittingNarration"] = rtxtNarration.Text.Trim();
                HeadDataRow["TotAmt"] = txtTotAmt.Text.Trim();
                
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
                    string spResult = Utilities.clsApplication.QLOpticSPExec("CreOrUptCreateJob", dthead, dtline, QLKey);
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
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Counter Sales Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    strqry = "select \"JODate\" 'JOB Date',\"DeliveryDate\", (select \"Name\" from QLCUST Where QLCUST.\"Code\" = QLOJOB.\"CustomerCode\") 'CustomerName', \"QLKey\" from QLOJOB";
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
            public void QLLoadSelectedCounterSales()
            {
                try
                {
                    QLClearErrorLabels();
                    string currentQLKey = dgvList.Rows[dgvList.CurrentRow.Index].Cells["QLKey"].Value.ToString().Trim();
                    strqry = " SELECT T0.SupplierCode,T0.CustomerCode,T0.OrderNo,T0.OrderDueDate,T0.OrderType,T0.LensType,";
                    strqry += " T0.JONo,T0.JODate,T0.DeliveryDate,T0.Narration,T0.FittingCharges,T0.FittingNarration,T0.TotAmt,";
                    strqry += " T1.QLKey,T1.LineNum,T1.Barcode,T1.Product,T1.Quantity,T1.UOM,T1.Rate,T1.Discount,T1.TaxPercent";
                    strqry += " FROM QLOJOB T0 ";
                    strqry += " INNER JOIN QLJOB1 T1 on T0.QLKey = T1.QLKey";
                    strqry += " WHERE T0.QLKey = " + currentQLKey;

                    dt = Utilities.clsApplication.FunFillDT(strqry);
                    
                    txtQLKey.Text = dt.Rows[0]["QLKey"].ToString().Trim();
                    txtSupplier.Text = dt.Rows[0]["SupplierCode"].ToString().Trim();
                    txtCustomerCode.Text = dt.Rows[0]["CustomerCode"].ToString().Trim();
                    txtOrderNo.Text = dt.Rows[0]["OrderNo"].ToString().Trim();
                    dateOrderDueDate.Text = dt.Rows[0]["OrderDueDate"].ToString().Trim();
                    txtJONO.Text = dt.Rows[0]["JONo"].ToString().Trim();
                    dateJODate.Text = dt.Rows[0]["JODate"].ToString().Trim();
                    dateDeliveryDate.Text = dt.Rows[0]["DeliveryDate"].ToString().Trim();
                    rtxtNarration.Text = dt.Rows[0]["Narration"].ToString().Trim();
                    cmbLensType.Text = dt.Rows[0]["LensType"].ToString().Trim();
                    cmbOrderType.Text = dt.Rows[0]["OrderType"].ToString().Trim();
                    txtFitCharges.Text = dt.Rows[0]["FittingCharges"].ToString().Trim();
                    rtxtFitNarration.Text = dt.Rows[0]["FittingNarration"].ToString().Trim();
                    txtTotAmt.Text = dt.Rows[0]["TotAmt"].ToString().Trim();
                    
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
            public void QLFetch(int QLKey)
            {

            }
            public void QLClearErrorLabels()
            {
                lblerrSupplier.Text = "";
                lblerrCustomer.Text = "";
                lblerrOrderNo.Text = "";
                lblerrOrderDueDate.Text = "";
                lblerrJoNo.Text = "";
                lblerrJoDate.Text = "";
                lblerrDeliveryDate.Text = "";
                lblerrNarration.Text = "";
                lblerrLensType.Text = "";
                lblerrOrderType.Text = "";
                lblerrFitCharges.Text = "";
                lblerrFitNarration.Text = "";
                lblerrTotalAmt.Text = "";
                lblerrLineDetails.Text = "";
            }
            public void QLClearData()
            {
                dgvBarcode.Rows.Clear();

                txtQLKey.Text = "";
                txtSupplier.Text = "";
                txtCustomerCode.Text = "";
                txtOrderNo.Text = "";
                dateOrderDueDate.Text = "";
                txtJONO.Text = "";
                dateJODate.Text = "";
                dateDeliveryDate.Text = "";
                rtxtNarration.Text = "";
                cmbLensType.Text = "";
                cmbOrderType.Text = "";
                txtFitCharges.Text = "";
                rtxtFitNarration.Text = "";
                txtTotAmt.Text = "";
                txtSearch.Text = "";
            }
            public void QLLoadSupplierCFL()
            {
                //int CFLX = Utilities.clsApplication.CFLXLocation + this.Location.X + tpnlTopRight.Location.X + pnlSupplier.Location.X + 2;
                int CFLX = Utilities.clsApplication.CFLXLocation + this.Location.X + pnlTopTop.Location.X+ pnlSupplier.Location.X + 2;
                int CFLY = 0;
                if (this.WindowState == FormWindowState.Maximized)
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlSupplier.Height + pnlLineTop.Height  + 52;
                }
                else
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlSupplier.Height + pnlLineTop.Height + 32;
                }
                string CFLQuery = "SELECT \"Code\" 'SupplierCode',\"Name\" 'SupplierName',\"Grp\",\"Adress\",\"City\",\"StateName\",\"Pin\",\"Mobile\",\"Email\",\"DOB\",\"Age\",\"QLKey\"  FROM QLSUPL order by \"Code\" ";
                int CFLWidth = txtSupplier.Width;
                int CFLHeight = pnlTop.Height - (pnlLineTop.Height + pnlSupplier.Height);
                cfl.QLLoadCFL(CFLX, CFLY, CFLQuery, 2, CFLWidth, CFLHeight);
                if (Utilities.clsApplication.cflSelectedRow != null)
                {
                    DataRow cflSelection = Utilities.clsApplication.cflSelectedRow;
                    txtSupplier.Text = cflSelection["SupplierCode"].ToString();
                }
            }
            public void QLLoadCustomerCFL()
            {
                int CFLX = Utilities.clsApplication.CFLXLocation + this.Location.X + pnlCustCode.Location.X + 8;
                int CFLY = 0;
                if (this.WindowState == FormWindowState.Maximized)
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlCustCode.Height + pnlLineTop.Height + 89;
                }
                else
                {
                    CFLY = Utilities.clsApplication.CFLYLocation + this.Location.Y + pnlCustCode.Height + pnlLineTop.Height + 69;
                }
                string CFLQuery = "SELECT \"Code\" 'CustomerCode',\"Name\" 'CustomerName',\"Grp\",\"Adress\",\"City\",\"StateName\",\"Pin\",\"Mobile\",\"Email\",\"DOB\",\"Age\",\"QLKey\" FROM QLCUST order by \"Code\"";
                int CFLWidth = txtCustomerCode.Width;
                int CFLHeight = pnlTop.Height - (pnlSupplier.Height + pnlCustCode.Height +pnlLineTop.Height);
                cfl.QLLoadCFL(CFLX, CFLY, CFLQuery, 2, CFLWidth, CFLHeight);
                if (Utilities.clsApplication.cflSelectedRow != null)
                {
                    DataRow cflSelection = Utilities.clsApplication.cflSelectedRow;
                    txtCustomerCode.Text = cflSelection["CustomerCode"].ToString();

                }
            }
        #endregion

        #region "Events"
            private void FrmCreateJob_Load(object sender, EventArgs e)
            {
                AddMode();
            }
            private void btnSave_Click(object sender, EventArgs e)
            {
                if(QLSave(Convert.ToInt32(txtQLKey.Text.Trim() == "" ? "0" : txtQLKey.Text.Trim()))==true)
                {
                    AddMode();
                }
            }
            private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                QLLoadSelectedCounterSales();
            }
            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
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

            private void txtCustomerCode_Click(object sender, EventArgs e)
            {
                QLLoadCustomerCFL();
            }

            private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
            {

            }
        #endregion

    }
}
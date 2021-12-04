using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Threading.Tasks;

namespace QL_Opticals.Presentation.QLControls
{
    public partial class CFLControl : DevExpress.XtraEditors.XtraForm
    {
        #region "Declaration"
            DataTable dtCFL,dtTemp;
            DataView dvCFL;
            int NoOfColVisibility;
            string oldsearch = "";
            int oldsrow = 0;
        #endregion

        #region "Constructor"
            public CFLControl()
            {
                InitializeComponent();
                InitFormStyle();
            }
        #endregion

        #region "User Function"
            
            public void InitFormStyle()
            {
                Utilities.clsApplication.InitForm(this);
                dgvCFL.GridColor = Utilities.clsApplication.objUtil.BackColor;
                dgvCFL.DefaultCellStyle.SelectionBackColor = Color.FromArgb((Utilities.clsApplication.objUtil.BackColor.R < 128 ? Utilities.clsApplication.objUtil.BackColor.R + 128 : Utilities.clsApplication.objUtil.BackColor.R), (Utilities.clsApplication.objUtil.BackColor.G < 128 ? Utilities.clsApplication.objUtil.BackColor.G + 128 : Utilities.clsApplication.objUtil.BackColor.G), (Utilities.clsApplication.objUtil.BackColor.B < 128 ? Utilities.clsApplication.objUtil.BackColor.B + 128 : Utilities.clsApplication.objUtil.BackColor.B));
                dgvCFL.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvCFL.ForeColor = Color.Black;
                dgvCFL.MultiSelect = false;
                this.ActiveControl = txtSearch;

                Utilities.clsApplication.cflSelectedRow = null;

            }
            public void  QLLoadCFL(int LeftLocation,int TopLocation,string strQuery ,int FirstNoOfColVisibility = 2, int thisWidth =300,int thisHeight =300)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.DesktopLocation = new Point(LeftLocation + 10, TopLocation + 25);
                this.Width = thisWidth;
                this.Height = thisHeight;
                this.WindowState = FormWindowState.Normal;

                dgvCFL.AllowUserToAddRows = false;
                dgvCFL.AllowUserToDeleteRows = false;
                dgvCFL.ReadOnly = true;
                //dgvCFL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCFL.ScrollBars = ScrollBars.Both;
                dgvCFL.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgvCFL.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold);
                dgvCFL.RowHeadersVisible = false;
                txtSearch.Focus();
                NoOfColVisibility = FirstNoOfColVisibility;

                if(dtCFL != null)
                {
                    dtCFL = null;
                }
                dtCFL = new DataTable();
                dtCFL = Utilities.clsApplication.FunFillDT(strQuery);
                dvCFL = dtCFL.DefaultView;
                dgvCFL.DataSource = null;
                dgvCFL.DataSource = dtCFL;
                dtTemp = dtCFL.Copy();
                txtSearch.Text = "";

                if (dgvCFL.Columns.Count > NoOfColVisibility)
                {
                    int ColumnDifference = dgvCFL.Columns.Count - NoOfColVisibility;
                    int ColumnPosition = NoOfColVisibility - 1;
                    while (ColumnDifference != 0)
                    {
                        ColumnPosition += 1;
                        dgvCFL.Columns[ColumnPosition].Visible = false;
                        ColumnDifference -= 1;
                    }
                }
                this.ShowDialog();
            }
            public void QLSearch()
            {
                try
                {
                    if (txtSearch.Text.Trim() != "")
                    {
                        if (txtSearch.Text != oldsearch)
                            oldsrow = 0;
                        if (oldsrow == dgvCFL.RowCount)
                            oldsearch = "";
                        for (int i = oldsrow; i <= dgvCFL.RowCount -1; i++)
                        {
                            if (dgvCFL.Rows[i].Cells[0].Value.ToString().ToLower().Contains(txtSearch.Text.ToLower()))
                            {
                                dgvCFL.Rows[i].Selected = true;
                                dgvCFL.CurrentCell = dgvCFL[0, i];
                                oldsearch = txtSearch.Text;
                                oldsrow = i + 1;
                                break;
                            }
                            else if (dgvCFL.Rows[i].Cells[1].Value.ToString().ToLower().Contains(txtSearch.Text.ToLower()))
                            {
                                dgvCFL.Rows[i].Selected = true;
                                dgvCFL.CurrentCell = dgvCFL[0, i];
                                oldsearch = txtSearch.Text;
                                oldsrow = i + 1;
                                break;
                            }
                            else
                            {
                                oldsearch = "";
                                dgvCFL.CurrentCell = null;
                            }
                        }
                    }
                    else
                        dgvCFL.CurrentCell = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        #endregion
           
        #region "Events"
            private void CFLControl_Load(object sender, EventArgs e)
            {
                InitFormStyle();
            }

            private void dgvCFL_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                Utilities.clsApplication.cflSelectedRow = ((DataRowView)this.dgvCFL.Rows[dgvCFL.CurrentCell.RowIndex].DataBoundItem).Row;
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }

            private void CFLControl_KeyDown(object sender, KeyEventArgs e)
            {
                try
                {
                    if (e.Control && e.KeyCode == Keys.Up)
                    {
                        btnResize.PerformClick();
                    }
                    if (e.KeyCode == Keys.Escape)
                    {
                        //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.Close();
                    }
                    if (e.KeyCode == Keys.Down)
                    {
                        if (txtSearch.Focused == true)
                        {
                            dgvCFL.Focus();
                            if (dgvCFL.CurrentCell == null || dgvCFL.CurrentCell.RowIndex == dgvCFL.RowCount - 1)
                            {
                                dgvCFL.CurrentCell = this.dgvCFL[0, 0];
                            }
                        }
                        if (dgvCFL.Focused == false)
                        {
                            dgvCFL.Focus();
                            if (dgvCFL.CurrentCell == null)
                            {
                                dgvCFL.CurrentCell = this.dgvCFL[0, 0];
                            }
                        }
                        if (dgvCFL.CurrentCell.RowIndex == dgvCFL.RowCount - 1)
                        {
                            txtSearch.Focus();
                        }
                    }
                    if (e.KeyCode == Keys.Up)
                    {
                        if (txtSearch.Focused == true)
                        {
                            dgvCFL.Focus();
                            if (dgvCFL.CurrentCell == null || dgvCFL.CurrentCell.RowIndex == 0)
                            {
                                dgvCFL.CurrentCell = this.dgvCFL[0, dgvCFL.RowCount - 1];
                            }
                        }
                        if (dgvCFL.Focused == false)
                        {
                            dgvCFL.Focus();
                            if (dgvCFL.CurrentCell == null)
                            {
                                dgvCFL.CurrentCell = this.dgvCFL[0, dgvCFL.RowCount - 1];
                            }
                        }
                        if (dgvCFL.CurrentCell.RowIndex == 0)
                        {
                            txtSearch.Focus();
                        }
                    }

                    if (e.KeyCode == Keys.Enter)
                    {
                        Utilities.clsApplication.cflSelectedRow = ((DataRowView)this.dgvCFL.Rows[this.dgvCFL.CurrentCell.RowIndex].DataBoundItem).Row;
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.Close();
                    }
                    
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }

            }

            private void txtSearch_TextChanged(object sender, EventArgs e)
            {
                QLSearch();
            }

            private void txtSearch_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtSearch.Text != "")
                    {
                        QLSearch();
                        QLSearch();
                        dgvCFL.Focus();
                    }

                }
            }

            private void dgvCFL_KeyDown(object sender, KeyEventArgs e)
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    Utilities.clsApplication.cflSelectedRow = ((DataRowView)dgvCFL.Rows[dgvCFL.CurrentCell.RowIndex].DataBoundItem).Row;
                //    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                //    this.Close();
                //}
            }

            private void btnResize_Click(object sender, EventArgs e)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                    for (int i = 0; i < dgvCFL.ColumnCount; i++)
                    {
                        dgvCFL.Columns[i].Visible = true;
                    }
                }
                else if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    if (dgvCFL.Columns.Count > NoOfColVisibility)
                    {
                        int ColumnDifference = dgvCFL.Columns.Count - NoOfColVisibility;
                        int ColumnPosition = NoOfColVisibility - 1;
                        while (ColumnDifference != 0)
                        {
                            ColumnPosition += 1;
                            dgvCFL.Columns[ColumnPosition].Visible = false;
                            ColumnDifference -= 1;
                        }
                    }
                }
                txtSearch.Focus();
            }
            private void CFLControl_Deactivate(object sender, EventArgs e)
            {
                //this.Close();
            }

            private void CFLControl_FormClosing(object sender, FormClosingEventArgs e)
            {
            }
        #endregion
            

    }
}
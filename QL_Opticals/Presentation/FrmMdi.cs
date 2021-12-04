using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraBars.Ribbon;
using QL_Opticals.Presentation.Master;
using QL_Opticals.Presentation.Transactions;
using QL_Opticals.Presentation.Administration;

namespace QL_Opticals.Presentation
{
    public partial class FrmMdi : DevExpress.XtraEditors.XtraForm
    {
        #region "Declaration"
        private FrmCrePrescription frmCrePre = new FrmCrePrescription();
            private FrmUtil frmUtil = new FrmUtil();
            private FrmLogin frmlogin = new FrmLogin();
            private FrmDashboard frmdashboard = new FrmDashboard();
            private FrmBookOrder frmBookOrder = new FrmBookOrder();
            public bool NavBarMenuVisible = false;
        #endregion
        
        #region "Properties"

        #endregion

        #region "Constructor"
            public FrmMdi()
            {
                InitializeComponent();
                InitFormStyle();

                this.IsMdiContainer = true;

                frmCrePre.TopLevel = false;
                frmCrePre.Parent = this;

                frmUtil.TopLevel = false;
                frmUtil.Parent = this;

                frmUtil.TopLevel = false;
                frmUtil.Parent = this;
            }

        #endregion

        #region "User Functions"

            public void EnableFormTool(bool toolEnable)
            {
                btnPreview.Enabled = toolEnable;
                btnPrint.Enabled = toolEnable;
                btnFindMode.Enabled = toolEnable;
                btnAddMode.Enabled = toolEnable;
                btnFirst.Enabled = toolEnable;
                btnPrevious.Enabled = toolEnable;
                btnNext.Enabled = toolEnable;
                btnLast.Enabled = toolEnable;
                tsmiData.Enabled = toolEnable;
                btnRefresh.Enabled = toolEnable;
            }

            //-----------------------------------NavBar-----------------------------

            public void navbarSelection()
            {
                if (Utilities.clsApplication.objUtil.SetStyle == true)
                {
                    InitFormStyle();
                    Utilities.clsApplication.objUtil.SetStyle = false;
                }

                if (lblFrmName.Text.Contains(frmCrePre.Text))
                {

                }
                else if (lblFrmName.Text.Contains(frmdashboard.Text))
                {

                }
                else if (lblFrmName.Text.Contains(frmUtil.Text))
                {

                }
                else if (lblFrmName.Text.Contains(frmBookOrder.Text))
                {

                }
            }

            public void hideNavBarMenu()
            {
                nbMenu.Visible = false;
                NavBarMenuVisible = false;
                Refresh();
            }

            public void showNavBarMenu()
            {
                nbMenu.Visible = true;
                NavBarMenuVisible = true;
                Refresh();
            }


        //-----------------------------------Adminstration-----------------------------
            
            public void showLogin()
            {
                if (Utilities.clsApplication.IsRelogin == false)
                {
                    this.Enabled = false;
                }
                frmlogin.ShowDialog();
                if(frmlogin.DialogResult== System.Windows.Forms.DialogResult.OK )
                {
                    this.Enabled = true;
                    dashboardToolStripMenuItem.Checked = true;
                }
                

            }
            public void showDashdoard()
            {
                if (dashboardToolStripMenuItem.Checked == true && this.Enabled == true)
                {
                    if (tmrDateTime.Enabled == false)
                    {
                        tmrDateTime.Start();
                    }

                    frmdashboard.Dispose();
                    frmdashboard = new FrmDashboard();
                    frmdashboard.MdiParent = this;
                    frmdashboard.Dock = DockStyle.Top;
                    frmdashboard.MdiParent = this;
                    frmdashboard.Location = new Point(50, 50);
                    frmdashboard.Visible = true;
                    frmdashboard.SendToBack();
                    frmdashboard.Show();
                    lblFrmName.Text = "Form Name : Dashboard";
                    //Utilities.clsApplication.CFLXLocation = pnlMenu.Width;
                }
            }

            public void showUtilForm()
            {

                FrmUtil frmobj = new FrmUtil();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Utilities";
            }
            public void showGenSettingsForm()
            {
                FrmGenSettings frmobj = new FrmGenSettings();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : General Settings";
            }


            //-----------------------------------Masters-----------------------------

            public void showAddDoctor()
            {
                Master.FrmDoctors frmobj = new Master.FrmDoctors();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Add An Doctor";
            }
           
            public void showAddHospital()
            {
                Master.FrmHospital frmobj = new Master.FrmHospital();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Add An Hospital";
            }
            public void showCrePreForm()
            {
                FrmCrePrescription frmobj = new FrmCrePrescription();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Create Prescription";
            }
            public void showCreateUsers()
            {
                Master.FrmUsers frmobj = new Master.FrmUsers();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Create Users";
            }
            public void showCreateGroup()
            {
                Master.FrmGroupCustomerUser frmobj = new Master.FrmGroupCustomerUser();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Create Group (Customers/Users)";
            }
            public void showCreateCustomer()
            {
                Master.FrmCustomers frmobj = new Master.FrmCustomers();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Create Customer";
            }
            public void showCreateSupplier()
            {
                Master.FrmSupplier frmobj = new Master.FrmSupplier();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Create Supplier";
            }
            public void showCustomerList()
            {
                Master.FrmCustomerList frmobj = new Master.FrmCustomerList();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Customer List";
            }
            public void showCreateSaleRep()
            {
                Master.FrmSalesRep frmobj = new Master.FrmSalesRep();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Create Sales Rep";
            }
            public void showPrescriptionPrint()
            {
               
            }
            public void showStatusReport()
            {
                Master.FrmStatusReport frmobj = new Master.FrmStatusReport();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Status Report";
            }
            public void showCancelOrder()
            {
                Master.FrmCancelOrders frmobj = new Master.FrmCancelOrders();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Cancel Order";
            }
            
            
        //-----------------------------------Transactions-----------------------------
    

            public void showBookOrder()
            {
                FrmBookOrder frmobj = new FrmBookOrder();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Book An Order";
            }
            public void showCounterSales()
            {
                Transactions.FrmCounterSales frmobj = new Transactions.FrmCounterSales();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Counter Sales";
            }
            public void showCreateJob()
            {
                Transactions.FrmCreateJob frmobj = new Transactions.FrmCreateJob();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Create Job";
            }
            public void showDeliveryDateChange()
            {
                Transactions.FrmDeliveryDateChange frmobj = new Transactions.FrmDeliveryDateChange();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Delivery Date Change";
            }
            public void showGenInvoice()
            {
                Transactions.FrmGenInvoice frmobj = new Transactions.FrmGenInvoice();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Generate Invoice";
            }
            public void showReceiveAdvance()
            {
                Transactions.FrmReceiveAdvance frmobj = new Transactions.FrmReceiveAdvance();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Receive Advance";
            }
            public void showReceiveStock()
            {
                Transactions.FrmReceiveStock frmobj = new Transactions.FrmReceiveStock();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Receive Stock";
            }
            public void showReplacement()
            {
                Transactions.FrmReplacement frmobj = new Transactions.FrmReplacement();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Replacement";
            }
            public void showSalesReturn()
            {
                Transactions.FrmSalesReturn frmobj = new Transactions.FrmSalesReturn();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Sales Return";
            }
            public void showSendStockOut()
            {
                Transactions.FrmSendStockOut frmobj = new Transactions.FrmSendStockOut();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Send Stock Out";
            }
            public void showTrackOrder()
            {
                Transactions.FrmTrackOrders frmobj  = new Transactions.FrmTrackOrders();
                frmobj.MdiParent = this;
                frmobj.Location = new Point(50, 50);
                frmobj.Visible = true;
                frmobj.Show();
                lblFrmName.Text = "Form Name : Track Order";
            }

            //-----------------------------------Init Form Style-----------------------------

            public void InitFormStyle()
            {
                Utilities.clsApplication.InitForm(this);
                Utilities.clsApplication.RemoveStyle(sbtnModules);
            }

        #endregion

        #region "Events"

            /*_____________________________________________Form Events_________________________________________*/
            private void FrmDashboard_Load(object sender, EventArgs e)
            {
                Utilities.clsApplication.FunConnectDB();
                Utilities.clsApplication.IsRelogin = false;
                showLogin();
                InitFormStyle();
                dashboardToolStripMenuItem.Checked = true;
                showDashdoard();
                Utilities.clsApplication.CFLXLocation = pnlMenu.Width;
                Utilities.clsApplication.CFLYLocation = menuStripTop.Height + pnlToolBox.Height;
            }

            /*_____________________________________________Tool Bar Events_________________________________________*/

            
            //---------------------------------------Tool Bar Click Events----------------------------------
            private void sbtnModules_Click(object sender, EventArgs e)
            {
                if (pnlMenu.Visible == false)
                {
                    pnlMenu.Visible = true;
                    sbtnHamBurger.Visible = false;
                    Utilities.clsApplication.CFLXLocation = 0;
                }
                else
                {
                    pnlMenu.Visible = false;
                    sbtnHamBurger.Visible = true;
                    Utilities.clsApplication.CFLXLocation = 0;
                }
            }

            private void sbtnHamBurger_Click(object sender, EventArgs e)
            {
                pnlMenu.Visible = true;
                sbtnHamBurger.Visible = false;
                Utilities.clsApplication.CFLXLocation = pnlMenu.Width;
            }

            private void btnPreview_Click(object sender, EventArgs e)
            {

            }
            private void btnPrint_Click(object sender, EventArgs e)
            {
                
            }
            private void btnFindMode_Click(object sender, EventArgs e)
            {
                if (this.ActiveMdiChild is Administration.IUtil)
                {
                    ((IUsers)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is ICancelOrders)
                {
                    ((ICancelOrders)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is ICrePrescription)
                {
                    ((ICrePrescription)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is ICustomerList)
                {
                    ((ICustomerList)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is ICustomers)
                {
                    ((ICustomers)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is IDoctors)
                {
                    ((IDoctors)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is IGroupCustomerUser)
                {
                    ((IGroupCustomerUser)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is IHospital)
                {
                    ((IHospital)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is ISalesRep)
                {
                    ((ISalesRep)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is IStatusReport)
                {
                    ((IStatusReport)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is IUsers)
                {
                    ((IUsers)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is Transactions.IBookOrder)
                {
                    ((IBookOrder)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is Transactions.ICounterSales)
                {
                    ((ICounterSales)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is Transactions.ICreateJob)
                {
                    ((ICreateJob)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is Transactions.IDeliveryDateChange)
                {
                    ((IDeliveryDateChange)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is Transactions.IGenInvoice)
                {
                    ((IGenInvoice)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is Transactions.IReceiveAdvance)
                {
                    ((IReceiveAdvance)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is Transactions.IReceiveStock)
                {
                    ((IReceiveStock)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is Transactions.IReplacement)
                {
                    ((IReplacement)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is Transactions.ISalesReturn)
                {
                    ((ISalesReturn)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is Transactions.ISendStockOut)
                {
                    ((ISendStockOut)this.ActiveMdiChild).FindMode();
                }
                else if (this.ActiveMdiChild is Transactions.ITrackOrders)
                {
                    ((ITrackOrders)this.ActiveMdiChild).FindMode();
                }
            }
            private void btnAddMode_Click(object sender, EventArgs e)
            {
                if (this.ActiveMdiChild is Administration.IUtil)
                {
                    ((IUtil)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is ICancelOrders)
                {
                    ((ICancelOrders)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is ICrePrescription)
                {
                    ((ICrePrescription)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is ICustomerList)
                {
                    ((ICustomerList)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is ICustomers)
                {
                    ((ICustomers)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is IDoctors)
                {
                    ((IDoctors)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is IGroupCustomerUser)
                {
                    ((IGroupCustomerUser)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is IHospital)
                {
                    ((IHospital)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is ISalesRep)
                {
                    ((ISalesRep)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is IStatusReport)
                {
                    ((IStatusReport)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is IUsers)
                {
                    ((IUsers)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is Transactions.IBookOrder)
                {
                    ((IBookOrder)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is Transactions.ICounterSales)
                {
                    ((ICounterSales)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is Transactions.ICreateJob)
                {
                    ((ICreateJob)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is Transactions.IDeliveryDateChange)
                {
                    ((IDeliveryDateChange)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is Transactions.IGenInvoice)
                {
                    ((IGenInvoice)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is Transactions.IReceiveAdvance)
                {
                    ((IReceiveAdvance)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is Transactions.IReceiveStock)
                {
                    ((IReceiveStock)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is Transactions.IReplacement)
                {
                    ((IReplacement)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is Transactions.ISalesReturn)
                {
                    ((ISalesReturn)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is Transactions.ISendStockOut)
                {
                    ((ISendStockOut)this.ActiveMdiChild).AddMode();
                }
                else if (this.ActiveMdiChild is Transactions.ITrackOrders)
                {
                    ((ITrackOrders)this.ActiveMdiChild).AddMode();
                }
            }
            private void btnFirst_Click(object sender, EventArgs e)
            {
                if (this.ActiveMdiChild is Administration.IUtil)
                {
                    ((IUtil)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is ICancelOrders)
                {
                    ((ICancelOrders)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is ICrePrescription)
                {
                    ((ICrePrescription)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is ICustomerList)
                {
                    ((ICustomerList)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is ICustomers)
                {
                    ((ICustomers)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is IDoctors)
                {
                    ((IDoctors)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is IGroupCustomerUser)
                {
                    ((IGroupCustomerUser)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is IHospital)
                {
                    ((IHospital)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is ISalesRep)
                {
                    ((ISalesRep)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is IStatusReport)
                {
                    ((IStatusReport)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is IUsers)
                {
                    ((IUsers)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IBookOrder)
                {
                    ((IBookOrder)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ICounterSales)
                {
                    ((ICounterSales)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ICreateJob)
                {
                    ((ICreateJob)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IDeliveryDateChange)
                {
                    ((IDeliveryDateChange)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IGenInvoice)
                {
                    ((IGenInvoice)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IReceiveAdvance)
                {
                    ((IReceiveAdvance)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IReceiveStock)
                {
                    ((IReceiveStock)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IReplacement)
                {
                    ((IReplacement)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ISalesReturn)
                {
                    ((ISalesReturn)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ISendStockOut)
                {
                    ((ISendStockOut)this.ActiveMdiChild).MoveFirstRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ITrackOrders)
                {
                    ((ITrackOrders)this.ActiveMdiChild).MoveFirstRecord();
                }
            }
            private void btnPrevious_Click(object sender, EventArgs e)
            {
                
                if (this.ActiveMdiChild is Administration.IUtil)
                {
                    ((IUtil)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is ICancelOrders)
                {
                    ((ICancelOrders)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is ICrePrescription)
                {
                    ((ICrePrescription)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is ICustomerList )
                {
                    ((ICustomerList)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is ICustomers)
                {
                    ((ICustomers)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is IDoctors)
                {
                    ((IDoctors)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is IGroupCustomerUser)
                {
                    ((IGroupCustomerUser)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is IHospital)
                {
                    ((IHospital)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is ISalesRep)
                {
                    ((ISalesRep)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is IStatusReport)
                {
                    ((IStatusReport)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is IUsers)
                {
                    ((IUsers)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IBookOrder)
                {
                    ((IBookOrder)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ICounterSales)
                {
                    ((ICounterSales)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ICreateJob)
                {
                    ((ICreateJob)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IDeliveryDateChange)
                {
                    ((IDeliveryDateChange)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IGenInvoice)
                {
                    ((IGenInvoice)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IReceiveAdvance)
                {
                    ((IReceiveAdvance)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IReceiveStock )
                {
                    ((IReceiveStock)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IReplacement)
                {
                    ((IReplacement)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ISalesReturn)
                {
                    ((ISalesReturn)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ISendStockOut)
                {
                    ((ISendStockOut)this.ActiveMdiChild).MovePreviousRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ITrackOrders)
                {
                    ((ITrackOrders)this.ActiveMdiChild).MovePreviousRecord();
                }
            }
            private void btnNext_Click(object sender, EventArgs e)
            {
                if (this.ActiveMdiChild is Administration.IUtil)
                {
                    ((IUtil)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is ICancelOrders)
                {
                    ((ICancelOrders)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is ICrePrescription)
                {
                    ((ICrePrescription)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is ICustomerList)
                {
                    ((ICustomerList)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is ICustomers)
                {
                    ((ICustomers)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is IDoctors)
                {
                    ((IDoctors)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is IGroupCustomerUser)
                {
                    ((IGroupCustomerUser)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is IHospital)
                {
                    ((IHospital)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is ISalesRep)
                {
                    ((ISalesRep)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is IStatusReport)
                {
                    ((IStatusReport)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is IUsers)
                {
                    ((IUsers)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IBookOrder)
                {
                    ((IBookOrder)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ICounterSales)
                {
                    ((ICounterSales)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ICreateJob)
                {
                    ((ICreateJob)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IDeliveryDateChange)
                {
                    ((IDeliveryDateChange)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IGenInvoice)
                {
                    ((IGenInvoice)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IReceiveAdvance)
                {
                    ((IReceiveAdvance)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IReceiveStock)
                {
                    ((IReceiveStock)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IReplacement)
                {
                    ((IReplacement)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ISalesReturn)
                {
                    ((ISalesReturn)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ISendStockOut)
                {
                    ((ISendStockOut)this.ActiveMdiChild).MoveNextRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ITrackOrders)
                {
                    ((ITrackOrders)this.ActiveMdiChild).MoveNextRecord();
                }
            }
            private void btnLast_Click(object sender, EventArgs e)
            {
                if (this.ActiveMdiChild is Administration.IUtil)
                {
                    ((IUtil)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is ICancelOrders)
                {
                    ((ICancelOrders)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is ICrePrescription)
                {
                    ((ICrePrescription)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is ICustomerList)
                {
                    ((ICustomerList)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is ICustomers)
                {
                    ((ICustomers)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is IDoctors)
                {
                    ((IDoctors)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is IGroupCustomerUser)
                {
                    ((IGroupCustomerUser)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is IHospital)
                {
                    ((IHospital)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is ISalesRep)
                {
                    ((ISalesRep)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is IStatusReport)
                {
                    ((IStatusReport)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is IUsers)
                {
                    ((IUsers)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IBookOrder)
                {
                    ((IBookOrder)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ICounterSales)
                {
                    ((ICounterSales)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ICreateJob)
                {
                    ((ICreateJob)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IDeliveryDateChange)
                {
                    ((IDeliveryDateChange)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IGenInvoice)
                {
                    ((IGenInvoice)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IReceiveAdvance)
                {
                    ((IReceiveAdvance)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IReceiveStock)
                {
                    ((IReceiveStock)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is Transactions.IReplacement)
                {
                    ((IReplacement)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ISalesReturn)
                {
                    ((ISalesReturn)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ISendStockOut)
                {
                    ((ISendStockOut)this.ActiveMdiChild).MoveLastRecord();
                }
                else if (this.ActiveMdiChild is Transactions.ITrackOrders)
                {
                    ((ITrackOrders)this.ActiveMdiChild).MoveLastRecord();
                }
            }
            private void btnRefresh_Click(object sender, EventArgs e)
            {

            }
            private void btnDashboard_Click(object sender, EventArgs e)
            {
                showDashdoard();
            }

            //---------------------------------------Tool Bar Key Press Events----------------------------------*/

            
            /*_____________________________________________Modules__________________________________________*/
            
            //---------------------------------------------File Menu----------------------------------------
            private void exitQLOPTICSToolStripMenuItem_Click(object sender, EventArgs e)
            {
                System.Windows.Forms.Application.Exit();
            }
        
            //---------------------------------------------View Menu----------------------------------------
            private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (statusBarToolStripMenuItem.Checked == true)
                {
                    statusBarToolStripMenuItem.Checked = false;
                    pnlStatus.Visible = false;
                }
                else
                {
                    statusBarToolStripMenuItem.Checked = true;
                    pnlStatus.Visible = true;
                }
            }
            private void mainModulesToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (mainModulesToolStripMenuItem.Checked == true)
                {
                    mainModulesToolStripMenuItem.Checked = false;
                    pnlMenu.Visible = false;
                    sbtnHamBurger.Visible = true;
                }
                else
                {
                    mainModulesToolStripMenuItem.Checked = true;
                    pnlMenu.Visible = true;
                    sbtnHamBurger.Visible = false;
                }
            }
            private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if(dashboardToolStripMenuItem.Checked == true)
                {
                    dashboardToolStripMenuItem.Checked = false;
                    frmdashboard.Close();
                }
                else
                {
                    dashboardToolStripMenuItem.Checked = true;
                    showDashdoard();
                }
            }

            //---------------------------------------------Window Menu----------------------------------------
            private void casCadeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
            }
            
            private void resetWindowToolStripMenuItem_Click(object sender, EventArgs e)
            {
                statusBarToolStripMenuItem.Checked = true;
                mainModulesToolStripMenuItem.Checked = true;
                dashboardToolStripMenuItem.Checked = true;
                pnlStatus.Visible = true;
                pnlMenu.Visible = true;
                sbtnHamBurger.Visible = false;
                showDashdoard();
            }

            //---------------------------------------------Module Menu----------------------------------------
            
            private void tmrDateTime_Tick(object sender, EventArgs e)
            {
                try
                {
                    lblDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
                    if (this.ActiveMdiChild != null)
                    {
                        lblFrmName.Text = "Form Name : " + this.ActiveMdiChild.Text.ToString().Trim();
                        lblArerts.Text = Utilities.clsApplication.objUtil.SetAlert;
                        if (this.ActiveMdiChild.Text.ToString().Trim() == "FrmDashboard")
                        {
                            if (tsmiData.Enabled == true)
                            {
                                EnableFormTool(false);
                            }
                        }
                        else
                        {
                            if (tsmiData.Enabled == false)
                            {
                                EnableFormTool(true);
                            }
                        }
                    }
                    else
                    {
                        showDashdoard();
                    }
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
            
            private void lblFrmName_TextChanged(object sender, EventArgs e)
            {
                navbarSelection();
            }
         
        //---------------------------------------------Administration----------------------------------------

            private void nbiDashboard_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showDashdoard();
            }
            private void utilitiesToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showUtilForm();
            }

            private void nbiUtilities_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showUtilForm();
            }

            private void generalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showGenSettingsForm();
            }

            private void nbiGenSettings_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showGenSettingsForm();
            }

        //---------------------------------------------Masters------------------------------------

            private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showAddDoctor();
            }
            private void nbiAddDoctor_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showAddDoctor();
            }

            private void HospitalToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showAddHospital();
            }
            private void nbiAddHospital_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showAddHospital();
            }

            private void crePrescriptionToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showCrePreForm();
            }
            private void nbiCreatePre_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showCrePreForm();
            }

            private void CreUserToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showCreateUsers();
            }

            private void nbiCreUser_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showCreateUsers();
            }

            private void CreGroupToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showCreateGroup();
            }

            private void nbiCreGroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showCreateGroup();
            }

            private void CreCustomerToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showCreateCustomer();
            }

            private void nbiCreCustomer_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showCreateCustomer();
            }
            private void nbiCreSupplier_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showCreateSupplier();
            }
            private void createSupplierToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showCreateSupplier();
            }
            private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showCustomerList();
            }

            private void nbiCustomerList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showCustomerList();
            }

            private void createSalesRepToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showCreateSaleRep();
            }

            private void nbiCreateSalesRep_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showCreateSaleRep();
            }

            private void prescriptionPrintToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showPrescriptionPrint();
            }

            private void nbiPrePrint_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showPrescriptionPrint();
            }

            private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showStatusReport();
            }

            private void nbiSalesReport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showStatusReport();
            }

            private void cancelOrdersToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showCancelOrder();
            }

            private void nbiCancelOrder_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showCancelOrder();
            }

            private void aboutQLOPTICSToolStripMenuItem_Click(object sender, EventArgs e)
            {
                FrmAbout frmobj = new FrmAbout();
                frmobj.Location = new Point(pnlMenu.Width + 70, 100);
                lblFrmName.Text = "Form Name : About QL OPTICS";
                frmobj.ShowDialog();

            }

         //--------------------------------------------Transactions-------------------------------------------

            private void BookOrderToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showBookOrder();
            }

            private void nbiBookAnOrder_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showBookOrder();
            }

            private void receiveAdvanceToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showReceiveAdvance();
            }

            private void nbiReceiveAdvance_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showReceiveAdvance();
            }

            private void createJobsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showCreateJob();
            }

            private void nbiCreJobs_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showCreateJob();
            }

            private void generateInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showGenInvoice();
            }

            private void nbiGenInv_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showGenInvoice();
            }

            private void counterSalesToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showCounterSales();
            }

            private void nbiCounterSales_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showCounterSales();
            }

            private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showSalesReturn();
            }

            private void nbiSalesReturn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showSalesReturn();
            }

            private void replacementToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showReplacement();
            }

            private void nbiReplacement_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showReplacement();
            }

            private void deliveryDateChangeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showDeliveryDateChange();
            }
            private void nbiDeliveryDateChange_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showDeliveryDateChange();
            }

            private void trackOrdersToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showTrackOrder();
            }
            private void nbiTrackOrders_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showTrackOrder();
            }

            private void sendStockOutToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showSendStockOut();
            }
            private void nbiSendStockOut_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showSendStockOut();
            }

            private void receiveStockToolStripMenuItem_Click(object sender, EventArgs e)
            {
                showReceiveStock();
            }
            private void nbiReceiveStock_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
            {
                showReceiveStock();
            }
            private void reLoginToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Utilities.clsApplication.IsRelogin = true;
                showLogin();
                InitFormStyle();
                showDashdoard();
            }

            
          //--------------------------------------------Data-------------------------------------------
            private void addToolStripMenuItem_Click(object sender, EventArgs e)
            {
                btnAddMode.PerformClick();
            }

            private void findToolStripMenuItem_Click(object sender, EventArgs e)
            {
                btnFindMode.PerformClick();
            }

            private void firstRecordToolStripMenuItem_Click(object sender, EventArgs e)
            {
                btnFirst.PerformClick();
            }

            private void previousRecordToolStripMenuItem_Click(object sender, EventArgs e)
            {
                btnPrevious.PerformClick();
            }

            private void nextRecordToolStripMenuItem_Click(object sender, EventArgs e)
            {
                btnNext.PerformClick();
            }

            private void lastRecordToolStripMenuItem_Click(object sender, EventArgs e)
            {
                btnLast.PerformClick();
            }

            private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
            {
                btnRefresh.PerformClick();
            }

        #endregion

    }
}
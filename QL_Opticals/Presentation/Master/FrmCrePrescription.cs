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
using DevExpress.Skins;
using DevExpress.XtraBars;

namespace QL_Opticals.Presentation
{
    public partial class FrmCrePrescription : DevExpress.XtraEditors.XtraForm, Master.ICrePrescription
    {

        #region "Declaration"
            string strqry = "";
            DataTable dt = new DataTable();
           // int i = 0;
            //string oldsearch = "";
            //int oldsrow = 0;
        #endregion

        #region "Constructor"
            public FrmCrePrescription()
            {
                InitializeComponent();
                InitFormStyle();
            }
        #endregion

        #region "Interface Functions"
            public void MovePreviousRecord() 
            {
                if (dgvList.RowCount > 0)
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
                    QLLoadSelectedPrecreption();
                    dgvList.Focus();
                }
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
                QLLoadSelectedPrecreption();
            }
            public void MoveLastRecord() 
            {
                dgvList.Rows[dgvList.RowCount - 1].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", dgvList.RowCount - 1];
                QLLoadSelectedPrecreption();
            }
            public void MoveFirstRecord() 
            {
                dgvList.Rows[0].Selected = true;
                dgvList.CurrentCell = dgvList["QLKey", 0];
                QLLoadSelectedPrecreption();
            }
            public void FindMode() { }
            public void AddMode() 
            {
                QLLoadData();
                QLClearData();
                QLClearError();
                txtCustCode.Focus();
            }
            public void PrintLayout() { }
            public void PreviewLayout() { }
            public void RefreshRecord() { }
        #endregion

        #region "User Functions"
            public void InitFormStyle()
            {
                Utilities.clsApplication.InitForm(this);
                cmbPeriod.SelectedIndex = 0;
                Utilities.clsApplication.RemoveStyle(btnSearch);
                dgvList.MultiSelect = false;
            }
            public string QLExecuteProcedure()
            {
                try
                {
                    string custCode, custName, custGroup; //custMobile, custAddress, custState, custCity, custPinCode, custEmail, custAge, custDOB;
                    string preNo,salesrep,doctor,hospital,nxtVisit,txtNextVisitType,nxtVisitDate;
                    string RSpPower,RCyPower,RAxis,RAddition,RPrism,RVisual,RPupil;
                    string LSpPower,LCyPower,LAxis, LAddition, LPrism, LVisual, LPupil;
                    string R1SpPower, R1CyPower, R1Axis, R1Addition, R1Prism, R1Visual, R1Pupil;
                    string L1SpPower, L1CyPower, L1Axis, L1Addition, L1Prism, L1Visual, L1Pupil;
                    string RSteepK,RFlatK,RFlatKAxis,RCDiam,RPubDia;
                    string LSteepK, LFlatK, LFlatKAxis, LCDiam, LPubDia;
                    string SPRemarks, CLPRemarks;

                    custCode = txtCustCode.Text.Trim();
                    custName = txtCustName.Text.Trim();
                    custGroup = txtCustGroup.Text.Trim();
                    /*custMobile = txtMobileNo.Text.Trim();
                    custAddress = rtxtAddress.Text.Trim();
                    custState = txtState.Text.Trim();
                    custCity = txtCity.Text.Trim();
                    custPinCode = txtPinCode.Text.Trim();
                    custEmail = txtEmailId.Text.Trim();
                    custAge = txtAge.Text.Trim();
                    custDOB = dateDOB.Text.Trim();*/
                    preNo = txtPrescriptionNo.Text.Trim();
                    salesrep = txtSalesRep.Text.Trim();
                    doctor = txtDoctor.Text.Trim();
                    hospital = txtHospital.Text.Trim();
                    nxtVisit = txtVisitNo.Text.Trim();
                    txtNextVisitType = cmbPeriod.Text;
                    nxtVisitDate = dateNextVisit.Text.Trim();
                    

                    RSpPower = txtRSpPower.Text.Trim();
                    RCyPower = txtRCyPower.Text.Trim();
                    RAxis = txtRAxis.Text.Trim();
                    RAddition = txtRAddition.Text.Trim();
                    RPrism = txtRPrism.Text.Trim();
                    RVisual = txtRVisual.Text.Trim();
                    RPupil = txtRPupil.Text.Trim();

                    LSpPower = txtLSpPower.Text.Trim();
                    LCyPower = txtLCyPower.Text.Trim();
                    LAxis = txtLAxis.Text.Trim();
                    LAddition = txtLAddition.Text.Trim();
                    LPrism = txtLPrism.Text.Trim();
                    LVisual = txtLVisual.Text.Trim();
                    LPupil = txtLPupil.Text.Trim();
                    SPRemarks = rtxtRemarks.Text.Trim();

                    R1SpPower = txtR1SpPower.Text.Trim();
                    R1CyPower = txtR1CyPower.Text.Trim();
                    R1Axis = txtR1Axis.Text.Trim();
                    R1Addition = txtR1Addition.Text.Trim();
                    R1Prism = txtR1Prism.Text.Trim();
                    R1Visual = txtR1Visual.Text.Trim();
                    R1Pupil = txtR1Pupil.Text.Trim();

                    L1SpPower = txtL1SpPower.Text.Trim();
                    L1CyPower = txtL1CyPower.Text.Trim();
                    L1Axis = txtL1Axis.Text.Trim();
                    L1Addition = txtL1Addition.Text.Trim();
                    L1Prism = txtL1Prism.Text.Trim();
                    L1Visual = txtL1Visual.Text.Trim();
                    L1Pupil = txtL1Pupil.Text.Trim();
                    CLPRemarks = rtxtRemarks1.Text.Trim();

                    RSteepK = txtRSteepK.Text.Trim();
                    RFlatK = txtRFlatK.Text.Trim();
                    RFlatKAxis = txtRFlatKAxis.Text.Trim();
                    RCDiam = txtRCDim.Text.Trim();
                    RPubDia = txtRPubDia.Text.Trim();

                    LSteepK = txtLSteepK.Text.Trim();
                    LFlatK = txtLFlatK.Text.Trim();
                    LFlatKAxis = txtLFlatKAxis.Text.Trim();
                    LCDiam = txtLCDim.Text.Trim();
                    LPubDia = txtLPubDia.Text.Trim();

                    strqry = "exec CreOrUptPrescription '" + custCode.ToUpper() + "','" + custName + "','" + custGroup + "','" + preNo + "','" + salesrep + "','" + doctor + "','" + hospital + "','" + nxtVisit + "','" + txtNextVisitType + "','" + nxtVisitDate + "'";
                    strqry += ", '" + RSpPower + "','" + RCyPower + "','" + RAxis + "','" + RAddition + "','" + RPrism + "','" + RVisual + "','" + RPupil + "','" + LSpPower + "','" + LCyPower + "','" + LAxis + "','" + LAddition + "','" + LPrism + "','" + LVisual + "','" + LPupil + "','" + SPRemarks+"'";
                    strqry += ", '" + R1SpPower + "','" + R1CyPower + "','" + R1Axis + "','" + R1Addition + "','" + R1Prism + "','" + R1Visual + "','" + R1Pupil + "','" + L1SpPower + "','" + L1CyPower + "','" + L1Axis + "','" + LAddition + "','" + L1Prism + "','" + L1Visual + "','" + L1Pupil + "','" + CLPRemarks + "'";
                    strqry += ", '" + RSteepK + "','" + RFlatK + "','" + RFlatKAxis + "','" + RCDiam + "','" + RPubDia + "','" + LSteepK + "','" + LFlatK + "','" + LFlatKAxis + "','" + LCDiam + "','" + LPubDia + "'";

                    return Utilities.clsApplication.FunGetSingleValue(strqry);
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString().Trim();
                }
                finally
                {
                    GC.Collect();
                }

            }
            public bool QLValidation()
            {
                bool valflag = true;

                try
                {
                    if (txtCustCode.Text.Trim() == "")
                    {

                        lblerrCustCode.ForeColor = Color.Red;
                        lblerrCustCode.Text = "Customer Code ?";
                        valflag = false;
                    }
                    else
                        lblerrCustCode.Text = "";

                    if (txtCustName.Text.Trim() == "")
                    {

                        lblerrCustName.ForeColor = Color.Red;
                        lblerrCustName.Text = "Customer Name ?";
                        valflag = false;
                    }
                    else
                        lblerrCustName.Text = "";

                    if (txtCustGroup.Text.Trim() == "")
                    {

                        lblerrCustGroup.ForeColor = Color.Red;
                        lblerrCustGroup.Text = "Customer Group ?";
                        valflag = false;
                    }
                    else
                        lblerrCustGroup.Text = "";

                    
                    /*if (txtMobileNo.Text.Trim() == "")
                    {

                        lblerrMobileNo.ForeColor = Color.Red;
                        lblerrMobileNo.Text = "Mobile No?";
                        valflag = false;
                    }
                    else
                        lblerrMobileNo.Text = "";
                    */

                    /*
                    if (rtxtAddress.Text.Trim() == "")
                    {
                         
                        lblerrAddress.ForeColor = Color.Red;
                        lblerrAddress.Text = "Enter Address";
                        valflag = false;
                    }
                    else
                        lblerrAddress.Text = "";

                    if (txtCity.Text.Trim() == "")
                    {

                        lblerrCity.ForeColor = Color.Red;
                        lblerrCity.Text = "Enter City";
                        valflag = false;
                    }
                    else
                        lblerrCity.Text = "";

                    if (txtState.Text.Trim() == "")
                    {

                        lblerrState.ForeColor = Color.Red;
                        lblerrState.Text = "Enter State";
                        valflag = false;
                    }
                    else
                        lblerrState.Text = "";

                    if (txtPinCode.Text.Trim() == "")
                    {

                        lblerrPinCode.ForeColor = Color.Red;
                        lblerrPinCode.Text = "Enter Pincode";
                        valflag = false;
                    }
                    else
                        lblerrPinCode.Text = "";

                    if (txtEmailId.Text.Trim() == "")
                    {

                        lblerrEmail.ForeColor = Color.Red;
                        lblerrEmail.Text = "Enter Email";
                        valflag = false;
                    }
                    else
                        lblerrEmail.Text = "";

                    if (txtAge.Text.Trim() == "")
                    {

                        lblerrAge.ForeColor = Color.Red;
                        lblerrAge.Text = "Enter Age";
                        valflag = false;
                    }
                    else
                        lblerrAge.Text = "";

                    if (dateDOB.Text.Trim() == "")
                    {

                        lblerrDoB.ForeColor = Color.Red;
                        lblerrDoB.Text = "Enter DoB";
                        valflag = false;
                    }
                    else
                        lblerrDoB.Text = "";
                    */

                    if (txtPrescriptionNo.Text.Trim() == "")
                    {

                        lblerrPrescriptionNo.ForeColor = Color.Red;
                        lblerrPrescriptionNo.Text = "Prescription No?";
                        valflag = false;
                    }
                    else
                        lblerrPrescriptionNo.Text = "";

                    if (txtSalesRep.Text.Trim() == "")
                    {

                        lblerrSalesRep.ForeColor = Color.Red;
                        lblerrSalesRep.Text = "Sales Rep ?";
                        valflag = false;
                    }
                    else
                        lblerrSalesRep.Text = "";

                    if (txtDoctor.Text.Trim() == "")
                    {

                        lblerrDoctor.ForeColor = Color.Red;
                        lblerrDoctor.Text = "Doctor ?";
                        valflag = false;
                    }
                    else
                        lblerrDoctor.Text = "";

                    if (txtHospital.Text.Trim() == "")
                    {
                         
                        lblerrHospital.ForeColor = Color.Red;
                        lblerrHospital.Text = "Hospital ?";
                        valflag = false;
                    }
                    else
                        lblerrHospital.Text = "";

                    if (txtVisitNo.Text.Trim() == "" || cmbPeriod.Text.Trim() == "")
                    {

                        lblerrNxtVisit.ForeColor = Color.Red;
                        lblerrNxtVisit.Text = "Next Visit ?";
                        valflag = false;
                    }
                    else
                        lblerrNxtVisit.Text = "";

                    if (dateNextVisit.Text.Trim() == "")
                    {

                        lblerrNxtVisitDate.ForeColor = Color.Red;
                        lblerrNxtVisitDate.Text = "Next Visit Date ?";
                        valflag = false;
                    }
                    else
                        lblerrNxtVisitDate.Text = "";



                    if (txtRSpPower.Text.Trim() == "")
                    {

                        lblerrRSpPower.ForeColor = Color.Red;
                        lblerrRSpPower.Text = "R-Spherical";
                        valflag = false;
                    }
                    else
                        lblerrRSpPower.Text = "";

                    if (txtRCyPower.Text.Trim() == "")
                    {

                        lblerrRCyPower.ForeColor = Color.Red;
                        lblerrRCyPower.Text = "R-Cylindrical";
                        valflag = false;
                    }
                    else
                        lblerrRCyPower.Text = "";

                    if (txtRAxis.Text.Trim() == "")
                    {

                        lblerrRAxis.ForeColor = Color.Red;
                        lblerrRAxis.Text = "R-Axis ?";
                        valflag = false;
                    }
                    else
                        lblerrRAxis.Text = "";

                    if (txtRAddition.Text.Trim() == "")
                    {

                        lblerrRAddition.ForeColor = Color.Red;
                        lblerrRAddition.Text = "R-Addition ?";
                        valflag = false;
                    }
                    else
                        lblerrRAddition.Text = "";

                    if (txtRPrism.Text.Trim() == "")
                    {

                        lblerrRPrism.ForeColor = Color.Red;
                        lblerrRPrism.Text = "R-Prism ?";
                        valflag = false;
                    }
                    else
                        lblerrRPrism.Text = "";

                    if (txtRVisual.Text.Trim() == "")
                    {

                        lblerrRVisual.ForeColor = Color.Red;
                        lblerrRVisual.Text = "R-Visual ?";
                        valflag = false;
                    }
                    else
                        lblerrRVisual.Text = "";

                    if (txtRPupil.Text.Trim() == "")
                    {

                        lblerrRPupil.ForeColor = Color.Red;
                        lblerrRPupil.Text = "R-Pupil ?";
                        valflag = false;
                    }
                    else
                        lblerrRPupil.Text = "";

                    if (txtLSpPower.Text.Trim() == "")
                    {

                        lblerrLSpPower.ForeColor = Color.Red;
                        lblerrLSpPower.Text = "L-Spherical";
                        valflag = false;
                    }
                    else
                        lblerrLSpPower.Text = "";

                    if (txtLCyPower.Text.Trim() == "")
                    {

                        lblerrLCyPower.ForeColor = Color.Red;
                        lblerrLCyPower.Text = "L-Cylindrical";
                        valflag = false;
                    }
                    else
                        lblerrLCyPower.Text = "";

                    if (txtLAxis.Text.Trim() == "")
                    {

                        lblerrLAxis.ForeColor = Color.Red;
                        lblerrLAxis.Text = "L-Axis ?";
                        valflag = false;
                    }
                    else
                        lblerrLAxis.Text = "";

                    if (txtLAddition.Text.Trim() == "")
                    {
                        
                        lblerrLAddition.ForeColor = Color.Red;
                        lblerrLAddition.Text = "L-Addition ?";
                        valflag = false;
                    }
                    else
                        lblerrLAddition.Text = "";

                    if (txtLPrism.Text.Trim() == "")
                    {

                        lblerrLPrism.ForeColor = Color.Red;
                        lblerrLPrism.Text = "L-Prism ?";
                        valflag = false;
                    }
                    else
                        lblerrLPrism.Text = "";

                    if (txtLVisual.Text.Trim() == "")
                    {

                        lblerrLVisual.ForeColor = Color.Red;
                        lblerrLVisual.Text = "L-Visual ?";
                        valflag = false;
                    }
                    else
                        lblerrLVisual.Text = "";

                    if (txtLPupil.Text.Trim() == "")
                    {

                        lblerrLPupil.ForeColor = Color.Red;
                        lblerrLPupil.Text = "L-Pupil ?";
                        valflag = false;
                    }
                    else
                        lblerrLPupil.Text = "";


                    if (txtR1SpPower.Text.Trim() == "")
                    {

                        lblerrR1SpPower.ForeColor = Color.Red;
                        lblerrR1SpPower.Text = "R-Spherical";
                        valflag = false;
                    }
                    else
                        lblerrR1SpPower.Text = "";

                    if (txtR1CyPower.Text.Trim() == "")
                    {

                        lblerrR1CyPower.ForeColor = Color.Red;
                        lblerrR1CyPower.Text = "R-Cylindrical";
                        valflag = false;
                    }
                    else
                        lblerrR1CyPower.Text = "";

                    if (txtR1Axis.Text.Trim() == "")
                    {

                        lblerrR1Axis.ForeColor = Color.Red;
                        lblerrR1Axis.Text = "R-Axis ?";
                        valflag = false;
                    }
                    else
                        lblerrR1Axis.Text = "";

                    if (txtR1Addition.Text.Trim() == "")
                    {

                        lblerrR1Addition.ForeColor = Color.Red;
                        lblerrR1Addition.Text = "R-Addition ?";
                        valflag = false;
                    }
                    else
                        lblerrR1Addition.Text = "";

                    if (txtR1Prism.Text.Trim() == "")
                    {

                        lblerrR1Prism.ForeColor = Color.Red;
                        lblerrR1Prism.Text = "R-Prism ?";
                        valflag = false;
                    }
                    else
                        lblerrR1Prism.Text = "";

                    if (txtR1Visual.Text.Trim() == "")
                    {

                        lblerrR1Visual.ForeColor = Color.Red;
                        lblerrR1Visual.Text = "R-Visual ?";
                        valflag = false;
                    }
                    else
                        lblerrR1Visual.Text = "";

                    if (txtR1Pupil.Text.Trim() == "")
                    {

                        lblerrR1Pupil.ForeColor = Color.Red;
                        lblerrR1Pupil.Text = "R-Pupil ?";
                        valflag = false;
                    }
                    else
                        lblerrR1Pupil.Text = "";

                    if (txtLSpPower.Text.Trim() == "")
                    {

                        lblerrL1SpPower.ForeColor = Color.Red;
                        lblerrL1SpPower.Text = "L-Spherical";
                        valflag = false;
                    }
                    else
                        lblerrL1SpPower.Text = "";

                    if (txtL1CyPower.Text.Trim() == "")
                    {

                        lblerrL1CyPower.ForeColor = Color.Red;
                        lblerrL1CyPower.Text = "L-Cylindrical";
                        valflag = false;
                    }
                    else
                        lblerrL1CyPower.Text = "";

                    if (txtL1Axis.Text.Trim() == "")
                    {

                        lblerrL1Axis.ForeColor = Color.Red;
                        lblerrL1Axis.Text = "L-Axis ?";
                        valflag = false;
                    }
                    else
                        lblerrL1Axis.Text = "";

                    if (txtL1Addition.Text.Trim() == "")
                    {

                        lblerrL1Addition.ForeColor = Color.Red;
                        lblerrL1Addition.Text = "L-Addition ?";
                        valflag = false;
                    }
                    else
                        lblerrL1Addition.Text = "";

                    if (txtL1Prism.Text.Trim() == "")
                    {

                        lblerrL1Prism.ForeColor = Color.Red;
                        lblerrL1Prism.Text = "L-Prism ?";
                        valflag = false;
                    }
                    else
                        lblerrL1Prism.Text = "";

                    if (txtL1Visual.Text.Trim() == "")
                    {

                        lblerrL1Visual.ForeColor = Color.Red;
                        lblerrL1Visual.Text = "L-Visual ?";
                        valflag = false;
                    }
                    else
                        lblerrL1Visual.Text = "";

                    if (txtL1Pupil.Text.Trim() == "")
                    {

                        lblerrL1Pupil.ForeColor = Color.Red;
                        lblerrL1Pupil.Text = "L-Pupil ?";
                        valflag = false;
                    }
                    else
                        lblerrL1Pupil.Text = "";



                    if (txtRSteepK.Text.Trim() == "")
                    {

                        lblerrRSteepK.ForeColor = Color.Red;
                        lblerrRSteepK.Text = "R-SteepK ?";
                        valflag = false;
                    }
                    else
                        lblerrRSteepK.Text = "";

                    if (txtRFlatK.Text.Trim() == "")
                    {

                        lblerrRFlatK.ForeColor = Color.Red;
                        lblerrRFlatK.Text = "R-FlatK ?";
                        valflag = false;
                    }
                    else
                        lblerrRFlatK.Text = "";

                    if (txtRFlatKAxis.Text.Trim() == "")
                    {

                        lblerrRFlatKAxis.ForeColor = Color.Red;
                        lblerrRFlatKAxis.Text = "R-Flat Axis ?";
                        valflag = false;
                    }
                    else
                        lblerrRFlatKAxis.Text = "";

                    if (txtRCDim.Text.Trim() == "")
                    {

                        lblerrRCDim.ForeColor = Color.Red;
                        lblerrRCDim.Text = "R-C Diam ?";
                        valflag = false;
                    }
                    else
                        lblerrRCDim.Text = "";

                    if (txtRPubDia.Text.Trim() == "")
                    {

                        lblerrRPubDia.ForeColor = Color.Red;
                        lblerrRPubDia.Text = "R-Pub Dia ?";
                        valflag = false;
                    }
                    else
                        lblerrRPubDia.Text = "";


                    if (txtLSteepK.Text.Trim() == "")
                    {

                        lblerrLSteepK.ForeColor = Color.Red;
                        lblerrLSteepK.Text = "L-SteepK ?";
                        valflag = false;
                    }
                    else
                        lblerrLSteepK.Text = "";

                    if (txtLFlatK.Text.Trim() == "")
                    {

                        lblerrLFlatK.ForeColor = Color.Red;
                        lblerrLFlatK.Text = "L-Flat K ?";
                        valflag = false;
                    }
                    else
                        lblerrLFlatK.Text = "";

                    if (txtLFlatKAxis.Text.Trim() == "")
                    {

                        lblerrLFlatKAxis.ForeColor = Color.Red;
                        lblerrLFlatKAxis.Text = "L-Flat Axis ?";
                        valflag = false;
                    }
                    else
                        lblerrLFlatKAxis.Text = "";

                    if (txtLCDim.Text.Trim() == "")
                    {

                        lblerrLCDim.ForeColor = Color.Red;
                        lblerrLCDim.Text = "L-C Diam ?";
                        valflag = false;
                    }
                    else
                        lblerrLCDim.Text = "";

                    if (txtLPubDia.Text.Trim() == "")
                    {

                        lblerrLPubDia.ForeColor = Color.Red;
                        lblerrLPubDia.Text = "L-Pub Dia ?";
                        valflag = false;
                    }
                    else
                        lblerrLPubDia.Text = "";

                   

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    valflag = false;
                }

                return valflag;
            }
            public bool QLSave()
            {
                try
                {
                    string ProcedureResult = "";
                    if (QLValidation() == true)
                    {
                        ProcedureResult = QLExecuteProcedure();
                        if (ProcedureResult == "SUCCESS")
                        {
                            Utilities.clsApplication.objUtil.SetAlert = "Info : Saved Successfully";
                            XtraMessageBox.Show(Utilities.clsApplication.FunSetLookFeel(this), "Prescription Saved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            public void QLLoadSelectedPrecreption()
            {
                dateNextVisit.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["NextVisitDate"].Value.ToString().Trim();
                txtPrescriptionNo.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["PrescriptionNo"].Value.ToString().Trim();
                txtSalesRep.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SalesRep"].Value.ToString().Trim();
                txtDoctor.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Doctor"].Value.ToString().Trim();
                txtHospital.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Hospital"].Value.ToString().Trim();

                txtCustCode.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Code"].Value.ToString().Trim();
                txtCustName.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Name"].Value.ToString().Trim();
                txtCustGroup.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["Grp"].Value.ToString().Trim();
                txtVisitNo.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["NxtVisit"].Value.ToString().Trim();

                cmbPeriod.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["NxtVisitType"].Value.ToString().Trim();
                txtRSpPower.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPRSphericalPower"].Value.ToString().Trim();
                txtRCyPower.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPRCylindricalPower"].Value.ToString().Trim();
                txtRAxis.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPRAxis"].Value.ToString().Trim();
                txtRAddition.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPRAddition"].Value.ToString().Trim();
                txtRPrism.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPRPrism"].Value.ToString().Trim();
                txtRVisual.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPRVisual"].Value.ToString().Trim();
                txtRPupil.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPRPupli"].Value.ToString().Trim();
                txtLSpPower.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPLSphericalPower"].Value.ToString().Trim();
                txtLCyPower.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPLCylindricalPower"].Value.ToString().Trim();
                txtLAxis.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPLAxis"].Value.ToString().Trim();
                txtLAddition.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPLAddition"].Value.ToString().Trim();
                txtLPrism.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPLPrism"].Value.ToString().Trim();
                txtLVisual.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPLVisual"].Value.ToString().Trim();
                txtLPupil.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPLPupli"].Value.ToString().Trim();
                rtxtRemarks.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["SPRemarks"].Value.ToString().Trim();
                txtR1SpPower.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLRSphericalPower"].Value.ToString().Trim();
                txtR1CyPower.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLRCylindricalPower"].Value.ToString().Trim();
                txtR1Axis.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLRAxis"].Value.ToString().Trim();
                txtR1Addition.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLRAddition"].Value.ToString().Trim();
                txtR1Prism.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLRPrism"].Value.ToString().Trim();
                txtR1Visual.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLRVisual"].Value.ToString().Trim();
                txtR1Pupil.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLRPupli"].Value.ToString().Trim();
                txtL1SpPower.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLLSphericalPower"].Value.ToString().Trim();
                txtL1CyPower.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLLCylindricalPower"].Value.ToString().Trim();
                txtL1Axis.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLLAxis"].Value.ToString().Trim();
                txtL1Addition.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLLAddition"].Value.ToString().Trim();
                txtL1Prism.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLLPrism"].Value.ToString().Trim();
                txtL1Visual.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLLVisual"].Value.ToString().Trim();
                txtL1Pupil.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLLPupli"].Value.ToString().Trim();
                rtxtRemarks1.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["CLRemarks"].Value.ToString().Trim();
                txtRSteepK.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["RSteepK"].Value.ToString().Trim();
                txtRFlatK.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["RFlatK"].Value.ToString().Trim();
                txtRFlatKAxis.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["RFlatKAxis"].Value.ToString().Trim();
                txtRCDim.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["RCDiam"].Value.ToString().Trim();
                txtRPubDia.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["RPubDia"].Value.ToString().Trim();
                txtLSteepK.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["LSteepK"].Value.ToString().Trim();
                txtLFlatK.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["LFlatK"].Value.ToString().Trim();
                txtLFlatKAxis.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["LFlatKAxis"].Value.ToString().Trim();
                txtLCDim.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["LCDiam"].Value.ToString().Trim();
                txtLPubDia.Text = dgvList.Rows[dgvList.CurrentRow.Index].Cells["LPubDia"].Value.ToString().Trim();

                txtCustCode.Enabled = false;
            }
            public void QLLoadData()
            {
                try
                {

                    dgvList.AllowUserToAddRows = false;
                    dgvList.AllowUserToDeleteRows = false;
                    dgvList.ReadOnly = true;
                    dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    strqry = "SELECT  ";
                    strqry += " [NxtVisitDate] 'NextVisitDate'";
                    strqry += " ,[PreNo] 'PrescriptionNo'";
                    strqry += " ,[SalesRep]";
                    strqry += " ,[Doctor]";
                    strqry += " ,[Hospital]";
                    strqry += " ,[QLKey]";

                    strqry += " ,[Code]";
                    strqry += " ,[Name]";
                    strqry += " ,[Grp]";
                    strqry += " ,[NxtVisit]";
                    strqry += " ,[NxtVisitType]";
                    strqry += " ,[SPRSphericalPower]";
                    strqry += " ,[SPRCylindricalPower]";
                    strqry += " ,[SPRAxis]";
                    strqry += " ,[SPRAddition]";
                    strqry += " ,[SPRPrism]";
                    strqry += " ,[SPRVisual]";
                    strqry += " ,[SPRPupli]";
                    strqry += " ,[SPLSphericalPower]";
                    strqry += " ,[SPLCylindricalPower]";
                    strqry += " ,[SPLAxis]";
                    strqry += " ,[SPLAddition]";
                    strqry += " ,[SPLPrism]";
                    strqry += " ,[SPLVisual]";
                    strqry += " ,[SPLPupli]";
                    strqry += " ,[SPRemarks]";
                    strqry += " ,[CLRSphericalPower]";
                    strqry += " ,[CLRCylindricalPower]";
                    strqry += " ,[CLRAxis]";
                    strqry += " ,[CLRAddition]";
                    strqry += " ,[CLRPrism]";
                    strqry += " ,[CLRVisual]";
                    strqry += " ,[CLRPupli]";
                    strqry += " ,[CLLSphericalPower]";
                    strqry += " ,[CLLCylindricalPower]";
                    strqry += " ,[CLLAxis]";
                    strqry += " ,[CLLAddition]";
                    strqry += " ,[CLLPrism]";
                    strqry += " ,[CLLVisual]";
                    strqry += " ,[CLLPupli]";
                    strqry += " ,[CLRemarks]";
                    strqry += " ,[RSteepK]";
                    strqry += " ,[RFlatK]";
                    strqry += " ,[RFlatKAxis]";
                    strqry += " ,[RCDiam]";
                    strqry += " ,[RPubDia]";
                    strqry += " ,[LSteepK]";
                    strqry += " ,[LFlatK]";
                    strqry += " ,[LFlatKAxis]";
                    strqry += " ,[LCDiam]";
                    strqry += " ,[LPubDia]";
                    strqry += " FROM [QLCPRE]";

                    if (dt != null)
                    {
                        dt = null;
                    }
                    dt = Utilities.clsApplication.FunFillDT(strqry);
                    if (dt.Rows.Count > 0)
                    {
                        dgvList.DataSource = dt;

                        dgvList.Columns["Code"].Visible = false;
                        dgvList.Columns["Name"].Visible = false;
                        dgvList.Columns["Grp"].Visible = false;
                        dgvList.Columns["NxtVisit"].Visible = false;
                        dgvList.Columns["NxtVisitType"].Visible = false;
                        dgvList.Columns["SPRSphericalPower"].Visible = false;
                        dgvList.Columns["SPRCylindricalPower"].Visible = false;
                        dgvList.Columns["SPRAxis"].Visible = false;
                        dgvList.Columns["SPRAddition"].Visible = false;
                        dgvList.Columns["SPRPrism"].Visible = false;
                        dgvList.Columns["SPRVisual"].Visible = false;
                        dgvList.Columns["SPRPupli"].Visible = false;
                        dgvList.Columns["SPLSphericalPower"].Visible = false;
                        dgvList.Columns["SPLCylindricalPower"].Visible = false;
                        dgvList.Columns["SPLAxis"].Visible = false;
                        dgvList.Columns["SPLAddition"].Visible = false;
                        dgvList.Columns["SPLPrism"].Visible = false;
                        dgvList.Columns["SPLVisual"].Visible = false;
                        dgvList.Columns["SPLPupli"].Visible = false;
                        dgvList.Columns["SPRemarks"].Visible = false;
                        dgvList.Columns["CLRSphericalPower"].Visible = false;
                        dgvList.Columns["CLRCylindricalPower"].Visible = false;
                        dgvList.Columns["CLRAxis"].Visible = false;
                        dgvList.Columns["CLRAddition"].Visible = false;
                        dgvList.Columns["CLRPrism"].Visible = false;
                        dgvList.Columns["CLRVisual"].Visible = false;
                        dgvList.Columns["CLRPupli"].Visible = false;
                        dgvList.Columns["CLLSphericalPower"].Visible = false;
                        dgvList.Columns["CLLCylindricalPower"].Visible = false;
                        dgvList.Columns["CLLAxis"].Visible = false;
                        dgvList.Columns["CLLAddition"].Visible = false;
                        dgvList.Columns["CLLPrism"].Visible = false;
                        dgvList.Columns["CLLVisual"].Visible = false;
                        dgvList.Columns["CLLPupli"].Visible = false;
                        dgvList.Columns["CLRemarks"].Visible = false;
                        dgvList.Columns["RSteepK"].Visible = false;
                        dgvList.Columns["RFlatK"].Visible = false;
                        dgvList.Columns["RFlatKAxis"].Visible = false;
                        dgvList.Columns["RCDiam"].Visible = false;
                        dgvList.Columns["RPubDia"].Visible = false;
                        dgvList.Columns["LSteepK"].Visible = false;
                        dgvList.Columns["LFlatK"].Visible = false;
                        dgvList.Columns["LFlatKAxis"].Visible = false;
                        dgvList.Columns["LCDiam"].Visible = false;
                        dgvList.Columns["LPubDia"].Visible = false;

                        dgvList.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
            public void QLClearData()
            {
                txtCustCode.Text = "";
                txtCustName.Text = "";
                txtCustGroup.Text = "";
                txtMobileNo.Text = "";
                txtPrescriptionNo.Text = "";
                txtSalesRep.Text = "";
                txtDoctor.Text = "";
                txtHospital.Text = "";
                txtVisitNo.Text = "";
                cmbPeriod.Text = "";
                dateNextVisit.Text = "";

                txtRSpPower.Text = "";
                txtRCyPower.Text = "";
                txtRAxis.Text= "";
                txtRAddition.Text = "";
                txtRPrism.Text= "";
                txtRVisual.Text= "";
                txtRPupil.Text= "";

                txtLSpPower.Text= "";
                txtLCyPower.Text= "";
                txtLAxis.Text= "";
                txtLAddition.Text= "";
                txtLPrism.Text= "";
                txtLVisual.Text= "";
                txtLPupil.Text= "";
                rtxtRemarks.Text= "";

                txtR1SpPower.Text= "";
                txtR1CyPower.Text= "";
                txtR1Axis.Text= "";
                txtR1Addition.Text= "";
                txtR1Prism.Text= "";
                txtR1Visual.Text= "";
                txtR1Pupil.Text= "";

                txtL1SpPower.Text= "";
                txtL1CyPower.Text= "";
                txtL1Axis.Text= "";
                txtL1Addition.Text= "";
                txtL1Prism.Text= "";
                txtL1Visual.Text= "";
                txtL1Pupil.Text= "";
                rtxtRemarks1.Text= "";

                txtRSteepK.Text= "";
                txtRFlatK.Text= "";
                txtRFlatKAxis.Text= "";
                txtRCDim.Text= "";
                txtRPubDia.Text= "";

                txtLSteepK.Text= "";
                txtLFlatK.Text= "";
                txtLFlatKAxis.Text= "";
                txtLCDim.Text= "";
                txtLPubDia.Text= "";

                txtCustCode.Enabled = true;
            }
            public void QLClearError()
            {

                lblerrCustCode.Text = "";
                lblerrCustName.Text = "";
                lblerrCustGroup.Text = "";
                lblerrMobileNo.Text = "";
                lblerrPrescriptionNo.Text = "";
                lblerrSalesRep.Text = "";
                lblerrDoctor.Text = "";
                lblerrHospital.Text = "";
                lblerrNxtVisit.Text = "";
                lblerrNxtVisitDate.Text = "";

                lblerrRSpPower.Text = "";
                lblerrRCyPower.Text = "";
                lblerrRAxis.Text = "";
                lblerrRAddition.Text = "";
                lblerrRPrism.Text = "";
                lblerrRVisual.Text = "";
                lblerrRPupil.Text = "";

                lblerrLSpPower.Text = "";
                lblerrLCyPower.Text = "";
                lblerrLAxis.Text = "";
                lblerrLAddition.Text = "";
                lblerrLPrism.Text = "";
                lblerrLVisual.Text = "";
                lblerrLPupil.Text = "";

                lblerrR1SpPower.Text = "";
                lblerrR1CyPower.Text = "";
                lblerrR1Axis.Text = "";
                lblerrR1Addition.Text = "";
                lblerrR1Prism.Text = "";
                lblerrR1Visual.Text = "";
                lblerrR1Pupil.Text = "";

                lblerrL1SpPower.Text = "";
                lblerrL1CyPower.Text = "";
                lblerrL1Axis.Text = "";
                lblerrL1Addition.Text = "";
                lblerrL1Prism.Text = "";
                lblerrL1Visual.Text = "";
                lblerrL1Pupil.Text = "";

                txtRSteepK.Text = "";
                txtRFlatK.Text = "";
                txtRFlatKAxis.Text = "";
                txtRCDim.Text = "";
                txtRPubDia.Text = "";

                lblerrLSteepK.Text = "";
                lblerrLFlatK.Text = "";
                lblerrLFlatKAxis.Text = "";
                lblerrLCDim.Text = "";
                lblerrLPubDia.Text = "";
            }
        #endregion
            
        #region "Events"
            private void btnSave_Click(object sender, EventArgs e)
            {
                if (QLSave() == true)
                {
                    AddMode();
                }
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnSearch_Click(object sender, EventArgs e)
            {
                QLLoadData();
            }

            private void FrmCrePrescription_Load(object sender, EventArgs e)
            {
                AddMode();
            }

            private void FrmCrePrescription_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.A)
                {
                    AddMode();
                }
            }

            private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                QLLoadSelectedPrecreption();
                QLClearError();
            }

        #endregion

    }
}
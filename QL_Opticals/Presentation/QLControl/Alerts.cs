using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevExpress.Skins;

namespace QL_Opticals.Presentation.QLControls
{
    #region "Declaration"
    public enum AlertType
    {
        success,
        info,
        warning,
        errors
    }
    public enum AlertDuration
    {
        short_time = 200,
        medium_time = 250,
        long_time = 300
    }
    #endregion
    public partial class Alerts : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public void showAlerts(string msg1, AlertType type, AlertDuration duration, string msg2 = "", int top = 10, int left = -100)
        {
            try
            {
                lblmsglin1.Text = msg1;
                lblmsgline2.Text = msg2;
                pnlProgress.Width = (int)duration;
                this.Location = new Point(50, 400);
                
                switch (type)
                {
                    case AlertType.success:
                        {
                            this.BackColor = Color.SeaGreen;
                            pnlProgress.BackColor = Color.MediumSeaGreen;
                            picboxAlertIcon.BackgroundImage = Image.FromFile(Utilities.clsApplication.ImagePath + @"\success.png");
                            break;
                        }

                    case AlertType.info:
                        {
                            this.BackColor = Color.Gray;
                            pnlProgress.BackColor = Color.DimGray;
                            picboxAlertIcon.BackgroundImage = System.Drawing.Image.FromFile(Utilities.clsApplication.ImagePath + @"\info.png");
                            break;
                        }

                    case AlertType.warning:
                        {
                            this.BackColor = Color.FromArgb(255, 128, 0);
                            pnlProgress.BackColor = Color.OrangeRed;
                            picboxAlertIcon.BackgroundImage = System.Drawing.Image.FromFile(Utilities.clsApplication.ImagePath + @"\warning.png");
                            break;
                        }

                    case AlertType.errors:
                        {
                            this.BackColor = Color.Crimson;
                            pnlProgress.BackColor = Color.DarkRed;
                            picboxAlertIcon.BackgroundImage = System.Drawing.Image.FromFile(Utilities.clsApplication.ImagePath + @"\error.png");
                            break;
                        }
                }
                try
                {
                    
                    this.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void InitFormStyle()
        {
            Utilities.clsApplication.InitForm(this);
        }
        public Alerts()
        {
            InitializeComponent();
            InitFormStyle();
        }

        private void Alerts_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            AlertTimer.Start();
        }

        private void AlertTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                pnlProgress.Width -= 1;
                if (pnlProgress.Width == 0)
                {
                    //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    pnlProgress.Width = 300;
                    AlertTimer.Stop();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            pnlProgress.Width = 400;
            AlertTimer.Stop();
            this.Close();
        }

    }
}

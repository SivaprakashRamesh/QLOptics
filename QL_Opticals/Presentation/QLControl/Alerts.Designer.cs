namespace QL_Opticals.Presentation.QLControls
{
    partial class Alerts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alerts));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.Button();
            this.lblmsgline2 = new System.Windows.Forms.Label();
            this.lblmsglin1 = new System.Windows.Forms.Label();
            this.picboxAlertIcon = new System.Windows.Forms.PictureBox();
            this.pnlProgress = new DevExpress.XtraEditors.PanelControl();
            this.AlertTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxAlertIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaGreen;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblmsgline2);
            this.panel1.Controls.Add(this.lblmsglin1);
            this.panel1.Controls.Add(this.picboxAlertIcon);
            this.panel1.Controls.Add(this.pnlProgress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 70);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnclose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 19);
            this.panel2.TabIndex = 13;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose.BackgroundImage")));
            this.btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Location = new System.Drawing.Point(252, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(18, 19);
            this.btnclose.TabIndex = 9;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // lblmsgline2
            // 
            this.lblmsgline2.AutoSize = true;
            this.lblmsgline2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsgline2.ForeColor = System.Drawing.Color.White;
            this.lblmsgline2.Location = new System.Drawing.Point(53, 44);
            this.lblmsgline2.Name = "lblmsgline2";
            this.lblmsgline2.Size = new System.Drawing.Size(42, 14);
            this.lblmsgline2.TabIndex = 12;
            this.lblmsgline2.Text = "label2";
            // 
            // lblmsglin1
            // 
            this.lblmsglin1.AutoSize = true;
            this.lblmsglin1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsglin1.ForeColor = System.Drawing.Color.White;
            this.lblmsglin1.Location = new System.Drawing.Point(53, 26);
            this.lblmsglin1.Name = "lblmsglin1";
            this.lblmsglin1.Size = new System.Drawing.Size(42, 14);
            this.lblmsglin1.TabIndex = 11;
            this.lblmsglin1.Text = "label1";
            // 
            // picboxAlertIcon
            // 
            this.picboxAlertIcon.BackColor = System.Drawing.Color.Transparent;
            this.picboxAlertIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picboxAlertIcon.BackgroundImage")));
            this.picboxAlertIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picboxAlertIcon.Location = new System.Drawing.Point(7, 18);
            this.picboxAlertIcon.Name = "picboxAlertIcon";
            this.picboxAlertIcon.Size = new System.Drawing.Size(40, 40);
            this.picboxAlertIcon.TabIndex = 10;
            this.picboxAlertIcon.TabStop = false;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.pnlProgress.Appearance.BackColor2 = System.Drawing.Color.MediumSeaGreen;
            this.pnlProgress.Appearance.Options.UseBackColor = true;
            this.pnlProgress.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlProgress.Location = new System.Drawing.Point(0, 65);
            this.pnlProgress.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlProgress.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(400, 5);
            this.pnlProgress.TabIndex = 0;
            // 
            // AlertTimer
            // 
            this.AlertTimer.Interval = 23;
            this.AlertTimer.Tick += new System.EventHandler(this.AlertTimer_Tick);
            // 
            // Alerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 70);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Alerts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Alerts";
            this.Load += new System.EventHandler(this.Alerts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxAlertIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.PanelControl pnlProgress;
        private System.Windows.Forms.Label lblmsgline2;
        private System.Windows.Forms.Label lblmsglin1;
        internal System.Windows.Forms.PictureBox picboxAlertIcon;
        internal System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Timer AlertTimer;
        private System.Windows.Forms.Panel panel2;
    }
}
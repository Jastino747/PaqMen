namespace Paq_Men
{
    partial class FormPac
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
            this.timerPacMove = new System.Windows.Forms.Timer(this.components);
            this.timerPacScan = new System.Windows.Forms.Timer(this.components);
            this.timerPacBreak = new System.Windows.Forms.Timer(this.components);
            this.timerPelletScan = new System.Windows.Forms.Timer(this.components);
            this.timerBlinky = new System.Windows.Forms.Timer(this.components);
            this.timerClyde = new System.Windows.Forms.Timer(this.components);
            this.timerInky = new System.Windows.Forms.Timer(this.components);
            this.timerPinky = new System.Windows.Forms.Timer(this.components);
            this.timerPower = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerPacMove
            // 
            this.timerPacMove.Enabled = true;
            this.timerPacMove.Interval = 10;
            this.timerPacMove.Tick += new System.EventHandler(this.timerPacMove_Tick);
            // 
            // timerPacScan
            // 
            this.timerPacScan.Enabled = true;
            this.timerPacScan.Interval = 10;
            this.timerPacScan.Tick += new System.EventHandler(this.timerPacScan_Tick);
            // 
            // timerPacBreak
            // 
            this.timerPacBreak.Interval = 10;
            this.timerPacBreak.Tick += new System.EventHandler(this.timerPacBreak_Tick);
            // 
            // timerPelletScan
            // 
            this.timerPelletScan.Enabled = true;
            this.timerPelletScan.Interval = 10;
            this.timerPelletScan.Tick += new System.EventHandler(this.timerPelletScan_Tick);
            // 
            // timerBlinky
            // 
            this.timerBlinky.Enabled = true;
            this.timerBlinky.Interval = 15;
            this.timerBlinky.Tick += new System.EventHandler(this.timerBlinky_Tick);
            // 
            // timerClyde
            // 
            this.timerClyde.Enabled = true;
            this.timerClyde.Interval = 15;
            this.timerClyde.Tick += new System.EventHandler(this.timerClyde_Tick);
            // 
            // timerInky
            // 
            this.timerInky.Enabled = true;
            this.timerInky.Interval = 15;
            this.timerInky.Tick += new System.EventHandler(this.timerInky_Tick);
            // 
            // timerPinky
            // 
            this.timerPinky.Enabled = true;
            this.timerPinky.Interval = 15;
            this.timerPinky.Tick += new System.EventHandler(this.timerPinky_Tick);
            // 
            // timerPower
            // 
            this.timerPower.Interval = 1000;
            this.timerPower.Tick += new System.EventHandler(this.timerPower_Tick);
            // 
            // FormPac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPac";
            this.Text = "Paq Man";
            this.Load += new System.EventHandler(this.FormPac_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerPacMove;
        private System.Windows.Forms.Timer timerPacScan;
        private System.Windows.Forms.Timer timerPacBreak;
        private System.Windows.Forms.Timer timerPelletScan;
        private System.Windows.Forms.Timer timerBlinky;
        private System.Windows.Forms.Timer timerClyde;
        private System.Windows.Forms.Timer timerInky;
        private System.Windows.Forms.Timer timerPinky;
        private System.Windows.Forms.Timer timerPower;
    }
}


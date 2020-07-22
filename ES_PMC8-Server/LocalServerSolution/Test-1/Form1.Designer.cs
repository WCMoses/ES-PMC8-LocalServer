namespace ASCOM.ES_PMC8
{
    partial class Form1
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
            this.buttonChoose = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelDriverId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRa = new System.Windows.Forms.TextBox();
            this.txtDec = new System.Windows.Forms.TextBox();
            this.cmdUnPark = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParked = new System.Windows.Forms.TextBox();
            this.cmdRight = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.cmdOpenanotherCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonChoose
            // 
            this.buttonChoose.Location = new System.Drawing.Point(543, 70);
            this.buttonChoose.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.buttonChoose.Name = "buttonChoose";
            this.buttonChoose.Size = new System.Drawing.Size(149, 67);
            this.buttonChoose.TabIndex = 0;
            this.buttonChoose.Text = "Choose";
            this.buttonChoose.UseVisualStyleBackColor = true;
            this.buttonChoose.Click += new System.EventHandler(this.buttonChoose_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(543, 147);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(149, 68);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelDriverId
            // 
            this.labelDriverId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDriverId.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ASCOM.ES_PMC8.Properties.Settings.Default, "DriverId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelDriverId.Location = new System.Drawing.Point(20, 61);
            this.labelDriverId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelDriverId.Name = "labelDriverId";
            this.labelDriverId.Size = new System.Drawing.Size(484, 31);
            this.labelDriverId.TabIndex = 2;
            this.labelDriverId.Text = global::ASCOM.ES_PMC8.Properties.Settings.Default.DriverId;
            this.labelDriverId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 160);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dec";
            // 
            // txtRa
            // 
            this.txtRa.Location = new System.Drawing.Point(99, 118);
            this.txtRa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRa.Name = "txtRa";
            this.txtRa.Size = new System.Drawing.Size(143, 44);
            this.txtRa.TabIndex = 5;
            // 
            // txtDec
            // 
            this.txtDec.Location = new System.Drawing.Point(99, 160);
            this.txtDec.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDec.Name = "txtDec";
            this.txtDec.Size = new System.Drawing.Size(143, 44);
            this.txtDec.TabIndex = 6;
            // 
            // cmdUnPark
            // 
            this.cmdUnPark.Location = new System.Drawing.Point(543, 238);
            this.cmdUnPark.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdUnPark.Name = "cmdUnPark";
            this.cmdUnPark.Size = new System.Drawing.Size(140, 69);
            this.cmdUnPark.TabIndex = 7;
            this.cmdUnPark.Text = "UnPark";
            this.cmdUnPark.UseVisualStyleBackColor = true;
            this.cmdUnPark.Click += new System.EventHandler(this.CmdUnPark_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 222);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 37);
            this.label3.TabIndex = 8;
            this.label3.Text = "Parked";
            // 
            // txtParked
            // 
            this.txtParked.Location = new System.Drawing.Point(108, 217);
            this.txtParked.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtParked.Name = "txtParked";
            this.txtParked.Size = new System.Drawing.Size(123, 44);
            this.txtParked.TabIndex = 9;
            // 
            // cmdRight
            // 
            this.cmdRight.Location = new System.Drawing.Point(312, 118);
            this.cmdRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdRight.Name = "cmdRight";
            this.cmdRight.Size = new System.Drawing.Size(143, 44);
            this.cmdRight.TabIndex = 10;
            this.cmdRight.Text = "Right";
            this.cmdRight.UseVisualStyleBackColor = true;
            this.cmdRight.Click += new System.EventHandler(this.CmdRight_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(300, 187);
            this.cmdStop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(155, 52);
            this.cmdStop.TabIndex = 11;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.CmdStop_Click);
            // 
            // cmdOpenanotherCopy
            // 
            this.cmdOpenanotherCopy.Location = new System.Drawing.Point(467, 485);
            this.cmdOpenanotherCopy.Name = "cmdOpenanotherCopy";
            this.cmdOpenanotherCopy.Size = new System.Drawing.Size(362, 55);
            this.cmdOpenanotherCopy.TabIndex = 12;
            this.cmdOpenanotherCopy.Text = "Open Another Copy";
            this.cmdOpenanotherCopy.UseVisualStyleBackColor = true;
            this.cmdOpenanotherCopy.Click += new System.EventHandler(this.cmdOpenanotherCopy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 591);
            this.Controls.Add(this.cmdOpenanotherCopy);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.cmdRight);
            this.Controls.Add(this.txtParked);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdUnPark);
            this.Controls.Add(this.txtDec);
            this.Controls.Add(this.txtRa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDriverId);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonChoose);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form1";
            this.Text = "Test-1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChoose;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelDriverId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRa;
        private System.Windows.Forms.TextBox txtDec;
        private System.Windows.Forms.Button cmdUnPark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtParked;
        private System.Windows.Forms.Button cmdRight;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Button cmdOpenanotherCopy;
    }
}


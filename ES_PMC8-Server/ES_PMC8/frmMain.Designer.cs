using System;

namespace ASCOM.ES_PMC8
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGuid = new System.Windows.Forms.Label();
            this.lblClients = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblConnected = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(531, 79);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is an ASCOM driver, not a program for you to use.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Clients";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "GUID";
            // 
            // lblGuid
            // 
            this.lblGuid.AutoSize = true;
            this.lblGuid.Location = new System.Drawing.Point(219, 187);
            this.lblGuid.Name = "lblGuid";
            this.lblGuid.Size = new System.Drawing.Size(69, 32);
            this.lblGuid.TabIndex = 4;
            this.lblGuid.Text = "------";
            // 
            // lblClients
            // 
            this.lblClients.AutoSize = true;
            this.lblClients.Location = new System.Drawing.Point(219, 122);
            this.lblClients.Name = "lblClients";
            this.lblClients.Size = new System.Drawing.Size(51, 32);
            this.lblClients.TabIndex = 5;
            this.lblClients.Text = "----";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Connected";
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.Location = new System.Drawing.Point(219, 243);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(60, 32);
            this.lblConnected.TabIndex = 7;
            this.lblConnected.Text = "-----";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 317);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblClients);
            this.Controls.Add(this.lblGuid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "frmMain";
            this.Text = "ES_PMC8 Driver Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblGuid;
        private System.Windows.Forms.Label lblClients;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblConnected;
    }
}


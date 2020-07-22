using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace ASCOM.ES_PMC8
{
    public partial class frmMain : Form
    {
        System.Timers.Timer timer = new System.Timers.Timer(1500);

        delegate void SetTextCallback(string text);

        public frmMain()
        {
            InitializeComponent();
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lblClients.Invoke(new Action(() => lblClients.Text = SharedResources.s_z.ToString()));
            lblGuid.Invoke(new Action(() =>lblGuid.Text = SharedResources.GetGud().ToString()));
            lblConnected.Invoke(new Action(() => lblConnected.Text= SharedResources.Connected.ToString()));
        }
    }
}
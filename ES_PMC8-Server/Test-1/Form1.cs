using System;
using System.Windows.Forms;

namespace ASCOM.ES_PMC8
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer = new System.Timers.Timer(1000);
        private ASCOM.DriverAccess.Telescope driver;

        public Form1()
        {
            InitializeComponent();
            SetUIState();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsConnected)
                driver.Connected = false;

            Properties.Settings.Default.Save();
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DriverId = ASCOM.DriverAccess.Telescope.Choose(Properties.Settings.Default.DriverId);
           //Properties.Settings.Default.DriverId = ASCOM.DriverAccess.Telescope.Choose("ASCOM.ES.Telescope");

            SetUIState();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                driver.Connected = false;
            }
            else
            {
                driver = new ASCOM.DriverAccess.Telescope("ASCOM.PMC8.Telescope");
                try
                {
                    driver.Connected = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }

            }
            SetUIState();
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var ra = driver.RightAscension;
            var dec = driver.Declination;
            bool parked = driver.AtPark;
            Console.WriteLine("RA = " + ra.ToString());
            txtRa.Invoke(new Action(() => txtRa.Text = ra.ToString()));
            txtDec.Invoke(new Action(() => txtDec.Text = dec.ToString()));
            txtParked.Invoke(new Action(() => txtParked.Text = parked.ToString()));
        }

        private void SetUIState()
        {
           // buttonConnect.Enabled = !string.IsNullOrEmpty(Properties.Settings.Default.DriverId);
            //buttonChoose.Enabled = !IsConnected;
           // buttonConnect.Text = IsConnected ? "Disconnect" : "Connect";
        }

        private bool IsConnected
        {
            get
            {
                return ((this.driver != null) && (driver.Connected == true));
            }
        }

        private void CmdUnPark_Click(object sender, EventArgs e)
        {
            driver.Unpark();
        }

        private void CmdRight_Click(object sender, EventArgs e)
        {
            driver.MoveAxis(DeviceInterface.TelescopeAxes.axisPrimary, 2);
        }

        private void CmdStop_Click(object sender, EventArgs e)
        {
            driver.MoveAxis(DeviceInterface.TelescopeAxes.axisPrimary, 0);
        }

        private void cmdOpenanotherCopy_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}

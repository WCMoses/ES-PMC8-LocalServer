using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASCOM;
using ASCOM.Astrometry;
using ASCOM.Astrometry.AstroUtils;
using ASCOM.DeviceInterface;
using ASCOM.Utilities;
using ASCOM.Astrometry.Transform;
using ASCOM.Utilities.Interfaces;
using ASCOM.ES_PMC8;

namespace Pmc8Server
{

    public partial class Commander : Form
    {

        internal static string driverID = "ASCOM.PMC8.Telescope";
        internal static string driverDescription = "PMC8 Telescope Server";
        internal static string comPortProfileName = "COM Port"; // Constants used for Profile persistence
        internal static string comSpeedProfileName = "COM Speed";
        internal static string traceStateProfileName = "Trace Level";
        internal static string IPAddressProfileName = "IP Address";
        internal static string IPPortProfileName = "IP Port";
        internal static string WirelessEnabledProfileName = "Wireless Enabled";
        internal static string WirelessProtocolProfileName = "Wireless Protocol";
        internal static string MountProfileName = "Mount Type";
        internal static string RateProfileName = "Mount Rate";
        internal static string MountRACountsProfileName = "Total RA Counts";
        internal static string MountDECCountsProfileName = "Total DEC Counts";
        internal static string ApertureDiameterProfileName = "Telescope Aperture Diameter";
        internal static string ApertureAreaProfileName = "Telescope Aperture Area";
        internal static string FocalLengthProfileName = "Telescope Focal Length";
        internal static string SiteLocationProfileName = "Site Location";
        internal static string SiteElevationProfileName = "Site Elevation meters";
        internal static string SiteLatitudeProfileName = "Site Latitude";
        internal static string SiteLongitudeProfileName = "Site Longitude";
        internal static string RateOffsetProfileName = "Rate Offset arc-sec/sec";
        internal static string SiteAmbientTemperatureProfileName = "Site Ambient Temperature";
        internal static string ParkRAPositionProfileName = "RA Park Position";
        internal static string ParkDECPositionProfileName = "DEC Park Position";
        internal static string ApplyRefractionCorrectionProfileName = "RefractionApplied";
        internal static string RA_SiderealRateFractionProfileName = "RA Sidereal Rate Fraction";
        internal static string DEC_SiderealRateFractionProfileName = "DEC Sidereal Rate Fraction";
        internal static string MininumPulseTimeProfileName = "Minimum Pulse Time";
        internal static string WiFiModuleIDProfileName = "WIFI Module ID";

        internal static string comPortDefault = "COM3";
        internal static string comSpeedDefault = "115200";
        internal static string traceStateDefault = "False";
        internal static string IPAddressDefault = "192.168.47.1";
        internal static string IPPortDefault = "54372";
        internal static string WirelessEnabledDefault = "True";
        internal static string WirelessProtocolDefault = "TCP";
        internal static string MountDefault = "Losmandy G-11";
        internal static string RateDefault = "Sidereal";
        internal static string MountRACountsDefault = "4608000"; // G-11
        internal static string MountDECCountsDefault = "4608000"; // G-11
        internal static string ApertureDiameterDefault = Convert.ToString(0.102);
        internal static string ApertureAreaDefault = Convert.ToString(0.00817);
        internal static string FocalLengthDefault = Convert.ToString(0.714);
        internal static string SiteLocationDefault = "Explore Scientific HQ";
        internal static string SiteElevationDefault = Convert.ToString(403.0);
        internal static string SiteLatitudeDefault = Convert.ToString(36.18063);
        internal static string SiteLongitudeDefault = Convert.ToString(-94.18838);
        internal static string RateOffsetDefalut = Convert.ToString(0.000);
        internal static string SiteAmbientTemperatureDefault = Convert.ToString(59.0);
        internal static string ParkRAPositionDefault = "0";
        internal static string ParkDECPositionDefault = "0";
        internal static string ApplyRefractionCorrectionDefault = "False";
        internal static string RA_SiderealRateFractionDefault = Convert.ToString(0.4);
        internal static string DEC_SiderealRateFractionDefault = Convert.ToString(0.4);
        internal static string MinimumPulseTimeDefault = "100";
        internal static string WiFiModuleIDDefault = "Microchip RN-131";

        internal static string comPort; // Variables to hold the currrent device configuration
        internal static string comSpeed;
        internal static bool traceState;
        internal static string IPAddress;
        internal static string IPPort;
        internal static bool WirelessEnabled;
        internal static string WirelessProtocol;
        internal static string Mount;
        internal static string Rate;
        internal static long MountRACounts;
        internal static long MountDECCounts;
        internal static double ApertureDiameterValue;
        internal static double ApertureAreaValue;
        internal static double FocalLengthValue;
        internal static string SiteLocation;
        internal static double SiteElevationValue;
        internal static double SiteLongitudeValue;
        internal static double SiteLatitudeValue;
        internal static double RateOffsetValue;
        internal static double SiteAmbientTemperatureValue;
        internal static Int32 ParkRAPosition;
        internal static Int32 ParkDECPosition;
        internal static bool ApplyRefractionCorrection;
        internal static float RA_SiderealRateFraction;
        internal static float DEC_SiderealRateFraction;
        internal static Int16 MinimumPulseTime;
        internal static string WiFiModuleID;
        public ASCOM.ES_PMC8.Telescope Telescope { get; set; }
        public ASCOM.DriverAccess.Telescope driver = null;

        public Commander()
        {
            InitializeComponent();
            //MessageBox.Show("Attach Now to commander", "Notice");
            try
            {
                //ReadProfile();
                //txtProfile.Text = GetProfileString();
               // LoadFormSetupValues();
            }
            catch (Exception)
            {

                txtProfile.Text = "unable to read profile.";
            }
        }

        private void ConnetToTelescope()
        {
            var telescope = new ASCOM.DriverAccess.Telescope("ASCOM.ES_PMC8.Telescope");

            Telescope.Connected = true;

        }
        private void DisplayDriverProps() // OK button event handler
        {
            // Persist new values of user settings to the ASCOM profile
            comPort = ComboBox1.Text; // Update the state variables with results from the dialogue
            comSpeed = ComboBox2.Text;
            traceState = chkTrace.Checked;
            IPAddress = TextBox1.Text;
            IPPort = TextBox2.Text;
            WirelessEnabled = RadioButton3.Checked;
            WiFiModuleID = cboWiFiModule.Text;
            if (RadioButton3.Checked)
                WirelessProtocol = "TCP";

            Mount = ComboBox3.Text;
            if (Mount == "Losmandy G-11")
            {
                MountRACounts = 4608000;
                MountDECCounts = 4608000;
            }
            else if (Mount == "Losmandy Titan")
            {
                MountRACounts = 3456000;
                MountDECCounts = 3456000;
            }
            else if (Mount == "Explore Scientific EXOS II")
            {
                MountRACounts = 4147200;
                MountDECCounts = 4147200;
            }
            else if (Mount == "Explore Scientific iEXOS-100")
            {
                MountRACounts = 4147200;
                MountDECCounts = 4147200;
            }
            else if (Mount == "Explore Scientific iEXOS-300")
            {
                MountRACounts = 4147200;
                MountDECCounts = 3456000;
            }

            Rate = ComboBox4.Text;
            if (Rate == "Sidereal")
            {
            }
            else if (Rate == "Lunar")
            {
            }
            else if (Rate == "Solar")
            {
            }
            else if (Rate == "King")
            {
            }

            SiteLocation = tbSiteLocation.Text;
            SiteLatitudeValue = Convert.ToDouble(tbSiteLatitude.Text);
            SiteLongitudeValue = Convert.ToDouble(tbSiteLongitude.Text);
            SiteElevationValue = Convert.ToDouble(tbSiteElevation.Text);
            ApertureDiameterValue = Convert.ToDouble(tbApertureDiameter.Text);
            ApertureAreaValue = Convert.ToDouble(tbApertureArea.Text);
            FocalLengthValue = Convert.ToDouble(tbFocalLength.Text);
            RateOffsetValue = Convert.ToDouble(tbRateOffset.Text);
            SiteAmbientTemperatureValue = Convert.ToDouble(tbAmbientTemp.Text);
            ApplyRefractionCorrection = cbRefraction.Checked;       //  ??proper conversion ??
            RA_SiderealRateFraction = Convert.ToInt16(nud_RA.Value);
            DEC_SiderealRateFraction = Convert.ToInt16(nud_DEC.Value);
            MinimumPulseTime = Convert.ToInt16(nud_PulseTime.Value);

        }

        public void WriteDefaultValues()
        {
            using (ASCOM.Utilities.Profile driverProfile = new ASCOM.Utilities.Profile())
            {
                driverProfile.DeviceType = "Telescope";
                driverProfile.WriteValue(driverID, traceStateProfileName, traceStateDefault);
                driverProfile.WriteValue(driverID, comPortProfileName, comPortDefault);
                driverProfile.WriteValue(driverID, comSpeedProfileName, comSpeedDefault);
                driverProfile.WriteValue(driverID, IPAddressProfileName, IPAddressDefault);
                driverProfile.WriteValue(driverID, IPPortProfileName, IPPortDefault);
                driverProfile.WriteValue(driverID, WirelessEnabledProfileName, WirelessEnabledDefault);
                driverProfile.WriteValue(driverID, WirelessProtocolProfileName, WirelessProtocolDefault);
                driverProfile.WriteValue(driverID, MountProfileName, "G-11");
                driverProfile.WriteValue(driverID, RateProfileName, RateDefault);
                driverProfile.WriteValue(driverID, MountRACountsProfileName, MountRACountsDefault);
                driverProfile.WriteValue(driverID, MountDECCountsProfileName, MountDECCountsDefault);
                driverProfile.WriteValue(driverID, ApertureDiameterProfileName, ApertureDiameterDefault);
                driverProfile.WriteValue(driverID, ApertureAreaProfileName, ApertureAreaDefault);
                driverProfile.WriteValue(driverID, FocalLengthProfileName, FocalLengthDefault);
                driverProfile.WriteValue(driverID, SiteLocationProfileName, SiteLocationDefault);
                driverProfile.WriteValue(driverID, SiteElevationProfileName, SiteElevationDefault);
                driverProfile.WriteValue(driverID, SiteLatitudeProfileName, SiteLatitudeDefault);
                driverProfile.WriteValue(driverID, SiteLongitudeProfileName, SiteLongitudeDefault);
                driverProfile.WriteValue(driverID, RateOffsetProfileName, RateOffsetDefalut);
                driverProfile.WriteValue(driverID, SiteAmbientTemperatureProfileName, SiteAmbientTemperatureDefault);
                driverProfile.WriteValue(driverID, ApplyRefractionCorrectionProfileName, ApplyRefractionCorrectionDefault);
                driverProfile.WriteValue(driverID, RA_SiderealRateFractionProfileName, RA_SiderealRateFractionDefault);
                driverProfile.WriteValue(driverID, DEC_SiderealRateFractionProfileName, DEC_SiderealRateFractionDefault);
                driverProfile.WriteValue(driverID, MininumPulseTimeProfileName, MinimumPulseTimeDefault);
                driverProfile.WriteValue(driverID, ParkRAPositionProfileName, ParkRAPositionDefault);
                driverProfile.WriteValue(driverID, ParkDECPositionProfileName, ParkDECPositionDefault);
                driverProfile.WriteValue(driverID, WiFiModuleIDProfileName, WiFiModuleIDDefault);
            }
            Console.WriteLine("Profile default values written to ASCOM profile");
        }

        internal void WriteProfile()

        {
            using (ASCOM.Utilities.Profile driverProfile = new ASCOM.Utilities.Profile())
            {
                driverProfile.DeviceType = "Telescope";
                driverProfile.WriteValue(driverID, traceStateProfileName, traceState.ToString());
                driverProfile.WriteValue(driverID, comPortProfileName, comPort.ToString());
                driverProfile.WriteValue(driverID, comSpeedProfileName, comSpeed.ToString());
                driverProfile.WriteValue(driverID, IPAddressProfileName, IPAddress.ToString());
                driverProfile.WriteValue(driverID, IPPortProfileName, IPPort.ToString());
                driverProfile.WriteValue(driverID, WirelessEnabledProfileName, WirelessEnabled.ToString());
                driverProfile.WriteValue(driverID, WirelessProtocolProfileName, WirelessProtocol.ToString());
                driverProfile.WriteValue(driverID, MountProfileName, Mount.ToString());
                driverProfile.WriteValue(driverID, RateProfileName, Rate.ToString());
                driverProfile.WriteValue(driverID, MountRACountsProfileName, MountRACounts.ToString());
                driverProfile.WriteValue(driverID, MountDECCountsProfileName, MountDECCounts.ToString());
                driverProfile.WriteValue(driverID, ApertureDiameterProfileName, ApertureDiameterValue.ToString());
                driverProfile.WriteValue(driverID, ApertureAreaProfileName, ApertureAreaValue.ToString());
                driverProfile.WriteValue(driverID, FocalLengthProfileName, FocalLengthValue.ToString());
                driverProfile.WriteValue(driverID, SiteLocationProfileName, SiteLocation.ToString());
                driverProfile.WriteValue(driverID, SiteElevationProfileName, SiteElevationValue.ToString());
                driverProfile.WriteValue(driverID, SiteLatitudeProfileName, SiteLatitudeValue.ToString());
                driverProfile.WriteValue(driverID, SiteLongitudeProfileName, SiteLongitudeValue.ToString());
                driverProfile.WriteValue(driverID, RateOffsetProfileName, RateOffsetValue.ToString());
                driverProfile.WriteValue(driverID, SiteAmbientTemperatureProfileName, SiteAmbientTemperatureValue.ToString());
                driverProfile.WriteValue(driverID, ApplyRefractionCorrectionProfileName, ApplyRefractionCorrection.ToString());
                driverProfile.WriteValue(driverID, RA_SiderealRateFractionProfileName, RA_SiderealRateFraction.ToString());
                driverProfile.WriteValue(driverID, DEC_SiderealRateFractionProfileName, DEC_SiderealRateFraction.ToString());
                driverProfile.WriteValue(driverID, MininumPulseTimeProfileName, MinimumPulseTime.ToString());
                driverProfile.WriteValue(driverID, ParkRAPositionProfileName, ParkRAPosition.ToString());
                driverProfile.WriteValue(driverID, ParkDECPositionProfileName, ParkDECPosition.ToString());
                driverProfile.WriteValue(driverID, WiFiModuleIDProfileName, WiFiModuleID.ToString());
            }
        }

        internal void ReadProfile()
        {
            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = "Telescope";
                traceState = Convert.ToBoolean(driverProfile.GetValue(driverID, traceStateProfileName, string.Empty, traceStateDefault));
                comPort = driverProfile.GetValue(driverID, comPortProfileName, string.Empty, comPortDefault);
                comSpeed = driverProfile.GetValue(driverID, comSpeedProfileName, string.Empty, comSpeedDefault);
                IPAddress = driverProfile.GetValue(driverID, IPAddressProfileName, string.Empty, IPAddressDefault);
                IPPort = driverProfile.GetValue(driverID, IPPortProfileName, string.Empty, IPPortDefault);
                WirelessEnabled = Convert.ToBoolean(driverProfile.GetValue(driverID, WirelessEnabledProfileName, string.Empty, WirelessEnabledDefault));
                WirelessProtocol = driverProfile.GetValue(driverID, WirelessProtocolProfileName, string.Empty, WirelessProtocolDefault);
                Mount = driverProfile.GetValue(driverID, MountProfileName, string.Empty, MountDefault);
                Rate = driverProfile.GetValue(driverID, RateProfileName, string.Empty, RateDefault);
                MountRACounts = Convert.ToInt32(driverProfile.GetValue(driverID, MountRACountsProfileName, string.Empty, MountRACountsDefault));
                MountDECCounts = Convert.ToInt32(driverProfile.GetValue(driverID, MountDECCountsProfileName, string.Empty, MountDECCountsDefault));
                ApertureDiameterValue = Convert.ToDouble(driverProfile.GetValue(driverID, ApertureDiameterProfileName, string.Empty, ApertureDiameterDefault));
                ApertureAreaValue = Convert.ToDouble(driverProfile.GetValue(driverID, ApertureAreaProfileName, string.Empty, ApertureAreaDefault));
                FocalLengthValue = Convert.ToDouble(driverProfile.GetValue(driverID, FocalLengthProfileName, string.Empty, FocalLengthDefault));
                SiteLocation = driverProfile.GetValue(driverID, SiteLocationProfileName, string.Empty, SiteLocationDefault);
                SiteElevationValue = Convert.ToDouble(driverProfile.GetValue(driverID, SiteElevationProfileName, string.Empty, SiteElevationDefault));
                SiteLatitudeValue = Convert.ToDouble(driverProfile.GetValue(driverID, SiteLatitudeProfileName, string.Empty, SiteLatitudeDefault));
                SiteLongitudeValue = Convert.ToDouble(driverProfile.GetValue(driverID, SiteLongitudeProfileName, string.Empty, SiteLongitudeDefault));
                RateOffsetValue = Convert.ToDouble(driverProfile.GetValue(driverID, RateOffsetProfileName, string.Empty, RateOffsetDefalut));
                SiteAmbientTemperatureValue = Convert.ToDouble(driverProfile.GetValue(driverID, SiteAmbientTemperatureProfileName, string.Empty, SiteAmbientTemperatureDefault));
                ApplyRefractionCorrection = Convert.ToBoolean(driverProfile.GetValue(driverID, ApplyRefractionCorrectionProfileName, string.Empty, ApplyRefractionCorrectionDefault));
                RA_SiderealRateFraction = Convert.ToSingle(driverProfile.GetValue(driverID, RA_SiderealRateFractionProfileName, string.Empty, RA_SiderealRateFractionDefault));
                DEC_SiderealRateFraction = Convert.ToSingle(driverProfile.GetValue(driverID, DEC_SiderealRateFractionProfileName, string.Empty, DEC_SiderealRateFractionDefault));
                MinimumPulseTime = Convert.ToInt16(driverProfile.GetValue(driverID, MininumPulseTimeProfileName, string.Empty, MinimumPulseTimeDefault));
                ParkRAPosition = Convert.ToInt32(driverProfile.GetValue(driverID, ParkRAPositionProfileName, string.Empty, ParkRAPositionDefault));
                ParkDECPosition = Convert.ToInt32(driverProfile.GetValue(driverID, ParkDECPositionProfileName, string.Empty, ParkDECPositionDefault));
                WiFiModuleID = driverProfile.GetValue(driverID, WiFiModuleIDProfileName, string.Empty, WiFiModuleIDDefault);
            }
        }

        private string GetProfileString()
        {
            string result = "";
            result = result + "traceState " + traceState + Environment.NewLine;
            result = result + "comPort " + comPort + Environment.NewLine;
            result = result + "comSpeed " + comSpeed + Environment.NewLine;
            result = result + "IPAddress " + IPAddress + Environment.NewLine;
            result = result + "IPPort " + IPPort + Environment.NewLine;
            result = result + "WirelessEnabled " + WirelessEnabled + Environment.NewLine;
            result = result + "WirelessProtocol " + WirelessProtocol + Environment.NewLine;
            result = result + "Mount " + Mount + Environment.NewLine;
            result = result + "Rate " + Rate + Environment.NewLine;
            result = result + "MountRACounts " + MountRACounts + Environment.NewLine;
            result = result + "MountDECCounts " + MountDECCounts + Environment.NewLine;
            result = result + "ApertureDiameterValue " + ApertureDiameterValue + Environment.NewLine;
            result = result + "ApertureAreaValue " + ApertureAreaValue + Environment.NewLine;
            result = result + "FocalLengthValue " + FocalLengthValue + Environment.NewLine;
            result = result + "SiteLocation " + SiteLocation + Environment.NewLine;
            result = result + "SiteElevationValue " + SiteElevationValue + Environment.NewLine;
            result = result + "SiteLatitudeValue " + SiteLatitudeValue + Environment.NewLine;
            result = result + "SiteLongitudeValue " + SiteLongitudeValue + Environment.NewLine;
            result = result + "RateOffsetValue " + RateOffsetValue + Environment.NewLine;
            result = result + "SiteAmbientTemperatureValue " + SiteAmbientTemperatureValue + Environment.NewLine;
            result = result + "ApplyRefractionCorrection " + ApplyRefractionCorrection + Environment.NewLine;
            result = result + "RA_SiderealRateFraction " + RA_SiderealRateFraction + Environment.NewLine;
            result = result + "DEC_SiderealRateFraction " + DEC_SiderealRateFraction + Environment.NewLine;
            result = result + "MinimumPulseTime " + MinimumPulseTime + Environment.NewLine;
            result = result + "ParkRAPosition " + ParkRAPosition + Environment.NewLine;
            result = result + "MinimumPulseTime " + MinimumPulseTime + Environment.NewLine;
            result = result + "ParkDECPosition " + ParkDECPosition + Environment.NewLine;
            result = result + "WiFiModuleID " + WiFiModuleID + Environment.NewLine;

            return result;

        }

        private void LoadFormSetupValues()
        {
            // Retrieve current values of user settings from the ASCOM Profile 
            using (ASCOM.Utilities.Serial objSerial = new ASCOM.Utilities.Serial())
            {
                foreach (var item in objSerial.AvailableCOMPorts)
                    ComboBox1.Items.Add(item);
            }
            chkTrace.Checked = traceState;
            ComboBox1.Text = comPort;
            ComboBox2.Text = comSpeed;
            TextBox1.Text = IPAddress;
            TextBox2.Text = IPPort;
            RadioButton1.Checked = !WirelessEnabled;
            if (WirelessProtocol == "TCP")
                RadioButton3.Checked = WirelessEnabled;
            RadioButton1.Checked = !WirelessEnabled;
            ComboBox3.Text = Mount;
            ComboBox4.Text = Rate;
            tbSiteLocation.Text = SiteLocation;
            tbSiteElevation.Text = SiteElevationValue.ToString();
            tbSiteLatitude.Text = SiteLatitudeValue.ToString();
            tbSiteLongitude.Text = SiteLongitudeValue.ToString();
            tbApertureDiameter.Text = ApertureDiameterValue.ToString();
            tbApertureArea.Text = ApertureAreaValue.ToString();
            tbFocalLength.Text = FocalLengthValue.ToString();
            tbRateOffset.Text = RateOffsetValue.ToString();
            tbAmbientTemp.Text = SiteAmbientTemperatureValue.ToString();
            cbRefraction.Checked = ApplyRefractionCorrection;
            nud_RA.Value = (decimal)RA_SiderealRateFraction;
            nud_DEC.Value = (decimal)DEC_SiderealRateFraction;
            nud_PulseTime.Value = MinimumPulseTime;
            cboWiFiModule.Text = WiFiModuleID;

            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();


            // Set up the ToolTip text for the Button and Checkbox.

        }
        private void OK_Button_Click_1(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmdConnect_Click(object sender, EventArgs e)
        {
            try
            {
            var driver = new ASCOM.DriverAccess.Telescope("ASCOM.PMC8.Telescope");
            driver.Connected = true;
                MessageBox.Show("Server Connected", "Notice");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR -  + ex");
                throw ex;
            }


        }

        private void Button9_Click(object sender, EventArgs e)
        {
            WriteProfile();
        }

        private void CmdRefreshProfile_Click(object sender, EventArgs e)
        {
            ReadProfile();
            LoadFormSetupValues();
        }

        private void cmdWriteDefaultValues_Click(object sender, EventArgs e)
        {
            WriteDefaultValues();
            MessageBox.Show("Default Values Written to Profile", "Notice");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

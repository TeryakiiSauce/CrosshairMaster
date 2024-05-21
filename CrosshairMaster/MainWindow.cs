namespace CrosshairMaster
{
    public partial class MainWindow : Form
    {
        Rectangle screenResolution = Screen.PrimaryScreen!.Bounds;

        const int MAIN_WINDOW_WIDTH = 300;
        const int MAIN_WINDOW_HEIGHT = 150;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Width = MAIN_WINDOW_WIDTH;
            Height = MAIN_WINDOW_HEIGHT;

            BackColor = Color.FromArgb(255, 33, 33, 33);

            // Positioning the window somewhere decent (which is not exactly at the centre lol)
            int x = screenResolution.Width / 5;
            int y = screenResolution.Height / 5;

            Location = new Point(x, y);

            InitializeMonitorsAvailable();
        }

        private void displayCrosshairCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            displayCrosshairCheckBox.Text = displayCrosshairCheckBox.Checked ? "Turned on" : "Turned off";

            // TODO: display new form for crosshair
        }

        /// <summary>
        /// To display all available monitors in dropdown (WIP).
        /// </summary>
        private void InitializeMonitorsAvailable()
        {
            // Monitors part
            monitorsDropDown.Enabled = false; // will be removed in the future when the functionality is finished.

            String[] monitorsAvailable = new string[Screen.AllScreens.Length];

            for (int i = 0; i < monitorsAvailable.Length; i++)
            {
                String monitorName = "";

                monitorName = Screen.AllScreens[i].Primary ? "Primary Display" : Screen.AllScreens[i].DeviceName[4..] /* removes the first four unnecessary characters */;

                monitorsAvailable[i] = monitorName;
            }

            monitorsDropDown.DataSource = monitorsAvailable;
            monitorsDropDown.Text = monitorsAvailable[0];
        }
    }
}

namespace CrosshairMaster
{
    public partial class MainWindow : Form
    {
        // TODO: need to add another checkbox for displaying screen blueprint (bc why not? lol)

        Rectangle screenResolution = Screen.PrimaryScreen!.Bounds;

        const int MAIN_WINDOW_WIDTH  = 300;
        const int MAIN_WINDOW_HEIGHT = 150;

        CrosshairDisplay crosshairDisplay;

        public MainWindow()
        {
            InitializeComponent();

            crosshairDisplay = new CrosshairDisplay(screenResolution);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Width  = MAIN_WINDOW_WIDTH;
            Height = MAIN_WINDOW_HEIGHT;

            BackColor = Color.FromArgb(255, 33, 33, 33);

            // Positioning the window somewhere decent (which is not exactly at the centre lol)
            int x = screenResolution.Width  / 5;
            int y = screenResolution.Height / 5;

            Location = new Point(x, y);

            LoadMonitorsAvailable();
        }

        private void displayCrosshairCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            displayCrosshairCheckBox.Text = displayCrosshairCheckBox.Checked ? "Turned on" : "Turned off";

            if (displayCrosshairCheckBox.Checked) { crosshairDisplay.Show(); }
            else { crosshairDisplay.Hide(); }
        }

        /// <summary>
        /// To display all available monitors in the dropdown (WIP).
        /// </summary>
        private void LoadMonitorsAvailable()
        {
            // Monitors part
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

using System.Runtime.InteropServices;

namespace CrosshairMaster
{
    public partial class CrosshairDisplay : Form
    {
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);



        // ~~ Top Level Variables ~~

        Graphics? g;

        Rectangle screenResolution;

        const int WINDOW_SIZE_X = 200;
        const int WINDOW_SIZE_Y = 200;

        const float CANVAS_MIDDLE_POINT_X = ((WINDOW_SIZE_X - 1f) / 2f);
        const float CANVAS_MIDDLE_POINT_Y = ((WINDOW_SIZE_Y - 1f) / 2f);

        // ~~ End of 'Top Level Variables' ~~



        public CrosshairDisplay(Rectangle screenResolution)
        {
            InitializeComponent();

            this.screenResolution = screenResolution;
        }

        private void CrosshairDisplay_Load(object sender, EventArgs e)
        {
            TopLevel = true;
            TopMost  = true;

            BackColor = Color.Black;
            TransparencyKey = Color.Black;

            FormBorderStyle = FormBorderStyle.None;

            Width  = WINDOW_SIZE_X;
            Height = WINDOW_SIZE_Y;

            int x = (screenResolution.Width  / 2) - (WINDOW_SIZE_X / 2);
            int y = (screenResolution.Height / 2) - (WINDOW_SIZE_Y / 2);

            Location = new Point(x, y);

            int initialStyle = GetWindowLong(Handle, -20);
            SetWindowLong(Handle, -20, initialStyle | 0x80000 | 0x20);
        }

        private void CrosshairDisplay_Paint(object sender, PaintEventArgs e)
        {
            // Note: Drawing pixels start from 0 (Zero) so to draw a 1920 horizontal line,
            // deduct 1 (One) so that all pixels appear.

            g = e.Graphics;

            //DrawBlueprint(); // TODO: this function should be moved to the main window (displayed using checkbox)
            DrawMiddleDot(color: Color.Lime);
            DrawCrosshairLines(color: Color.Lime);
        }

        [Obsolete("This function will be moved to the main screen soon.")]
        private void DrawBlueprint()
        {
            if (g == null) return;

            Pen pen = new Pen(Color.Magenta, 2f);

            g.DrawRectangle(pen, 0, 0, WINDOW_SIZE_X - 1f, WINDOW_SIZE_Y - 1f);
            g.DrawLine(pen, 0, CANVAS_MIDDLE_POINT_Y, WINDOW_SIZE_X - 1f, CANVAS_MIDDLE_POINT_Y);
            g.DrawLine(pen, CANVAS_MIDDLE_POINT_X, 0, CANVAS_MIDDLE_POINT_X, WINDOW_SIZE_Y - 1f);
        }

        // For diameter use even numbers whenever possible
        private void DrawMiddleDot(Color color, float diameter = 4f)
        {
            if (g == null) return;

            float radius = diameter / 2;

            Brush dotBrush = new SolidBrush(color);

            g.FillEllipse(dotBrush, new RectangleF(
                new PointF(CANVAS_MIDDLE_POINT_X - radius, CANVAS_MIDDLE_POINT_Y - radius),
                new SizeF(diameter, diameter)
                ));
        }

        private void DrawCrosshairLines(Color color, float thickness = 2f, float height = 14f, float gap = 8f)
        {
            if (g == null) return;

            float radius = thickness / 2;

            Brush dotBrush = new SolidBrush(color);

            // Top
            g.FillRectangle(dotBrush, new RectangleF(
                new PointF(CANVAS_MIDDLE_POINT_X - radius, CANVAS_MIDDLE_POINT_Y - height - gap),
                new SizeF(thickness, height)
                ));

            // Right
            g.FillRectangle(dotBrush, new RectangleF(
                new PointF(CANVAS_MIDDLE_POINT_X + gap, CANVAS_MIDDLE_POINT_Y - radius),
                new SizeF(height, thickness)
                ));

            // Bottom
            g.FillRectangle(dotBrush, new RectangleF(
                new PointF(CANVAS_MIDDLE_POINT_X - radius, CANVAS_MIDDLE_POINT_Y + gap),
                new SizeF(thickness, height)
                ));

            // Left
            g.FillRectangle(dotBrush, new RectangleF(
                new PointF(CANVAS_MIDDLE_POINT_X - height - gap, CANVAS_MIDDLE_POINT_Y - radius),
                new SizeF(height, thickness)
                ));
        }
    }
}

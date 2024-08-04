using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private Timer timer;

        public Form1()
        {
            InitializeComponent();

            // Initialize Timer
            timer = new Timer();
            timer.Interval = 100; // Set the interval (e.g., 100 ms)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CaptureScreen();
        }

        private void CaptureScreen()
        {
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
            using (Bitmap bmp = new Bitmap(screenBounds.Width, screenBounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(screenBounds.Location, Point.Empty, screenBounds.Size);
                }

                // Update the PictureBox
                pictureBox1.Image?.Dispose(); // Dispose of previous image if necessary
                pictureBox1.Image = new Bitmap(bmp);
            }
        }
    }
}

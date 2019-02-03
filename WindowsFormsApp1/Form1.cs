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
        Form form2;
        Point MD = Point.Empty;
        Rectangle rect = Rectangle.Empty;
        Bitmap bmp = null;
        #region Form1 screenshotting functions
        void form2_MouseDown(object sender, MouseEventArgs e)
        {
            MD = e.Location;
        }

        void form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Point MM = e.Location;
            rect = new Rectangle(Math.Min(MD.X, MM.X), Math.Min(MD.Y, MM.Y),
                                 Math.Abs(MD.X - MM.X), Math.Abs(MD.Y - MM.Y));
            form2.Invalidate();
        }

        void form2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Red, rect);
        }

        void form2_MouseUp(object sender, MouseEventArgs e)
        {
            form2.Hide();
            Screen scr = Screen.AllScreens[0];
            bmp = new Bitmap(rect.Width, rect.Height);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.CopyFromScreen(rect.Location, Point.Empty, rect.Size,
                                 CopyPixelOperation.SourceCopy);
                pictureBox1.Image = bmp;
            }
            topX.Text = rect.Left.ToString();
            topY.Text = rect.Top.ToString();
            bottomX.Text = rect.Right.ToString();
            bottomY.Text = rect.Bottom.ToString();

            form2.Close();
            Show();
        }
        #endregion
        private void GetSSButton_Click(object sender, EventArgs e)
        {
            Hide();
            form2 = new Form();
            form2.BackColor = Color.Wheat;
            form2.TransparencyKey = form2.BackColor;
            form2.ControlBox = false;
            form2.MaximizeBox = false;
            form2.MinimizeBox = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.WindowState = FormWindowState.Maximized;
            form2.MouseDown += form2_MouseDown;
            form2.MouseMove += form2_MouseMove;
            form2.Paint += form2_Paint;
            form2.MouseUp += form2_MouseUp;

            form2.Show();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(bmp != null)
            {
                string folderLoc = @"D:\Users\Jun Xiang\Desktop\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\test";
                BitmapConversion.convertingBitmap.SaveAsJpeg(folderLoc, "0", bmp);
            }
        }
    }
}

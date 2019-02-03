using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Functions;
using WindowsFormsApp1.Structs;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		Form form2;
		Point MD = Point.Empty;
		Rectangle rect = Rectangle.Empty;
		Bitmap bmp = null;

		//instances
		ListViewManager lVManager;
		BotFunctions bot;

		//bot data
		int imgCount = 0;
		List<Rectangle> allRect = new List<Rectangle>();
		List<Bitmap> allBitmaps = new List<Bitmap>();
		List<int> allTime = new List<int>();
		//timer data
		int iterationNumb = 0;



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
		public Form1()
		{
			InitializeComponent();
			lVManager = new ListViewManager(listView1);
			bot = new BotFunctions();
		}
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

		private void addButton_Click(object sender, EventArgs e)
		{
			if (bmp == null)
				return;
			string pos = rect.Left.ToString()+"," + rect.Top.ToString() +","+ rect.Right.ToString()+"," + rect.Bottom.ToString();
			lVManager.Add(pos,imgCount.ToString() ,timeStep.Text);
			//local side for bot to work
			allTime.Add(int.Parse(timeStep.Text));
			allBitmaps.Add(BitmapConversion.Instance.ResizeTo256Bit(bmp));
			allRect.Add(rect);
			bmp = null;
		}
		private void Save_Click(object sender, EventArgs e)
		{
			if(bmp != null)
			{
				string folderLoc = @"D:\Users\Jun Xiang\Desktop\AutoclickerWIthImgCapture\WindowsFormsApp1\bin\Debug\test";
				Bitmap bmpSmall = BitmapConversion.Instance.ResizeTo256Bit(bmp);

				BitmapConversion.Instance.SaveAsJpeg(folderLoc, "0", bmpSmall);

			}
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			timer1.Start();
			timer1.Interval = 5000;
			this.WindowState = FormWindowState.Minimized;
			
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			if(lVManager.time.Count > iterationNumb)
			{
				timer1.Interval = allTime[iterationNumb];
				//Perform Action

				Bitmap bMap = bot.printScreen(allRect[iterationNumb]);

				byte[] a = BitmapConversion.Instance.Array1DFromBitmap(allBitmaps[iterationNumb]);
				byte[] b = BitmapConversion.Instance.Array1DFromBitmap(bMap);
				bool SameImage = BitmapConversion.Instance.CompareBytes(a, b);
				if (SameImage)
				{
					bot.MoveCursor(allRect[iterationNumb]);
					bot.LeftClick();
				}

				//end of actions
				iterationNumb++;
				timer1.Start();
				//reset the actions
				//if (iterationNumb >= lVManager.time.Count)
				//    iterationNumb = 0;
			}
			else
			{
				this.WindowState = FormWindowState.Normal;
			}
		}
	}
}

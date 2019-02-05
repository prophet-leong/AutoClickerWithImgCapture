using Gma.UserActivityMonitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

		int imgCount = 0;

		Keys registedHotkey = Keys.F5;
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			lVManager = new ListViewManager(listView1);
			bot = new BotFunctions(timer1);
			HookManager.KeyDown += HookManager_KeyDown;
		}


		#region HotKey
		private void HookManager_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == registedHotkey)
			{
				this.WindowState = FormWindowState.Normal;
				timer1.Stop();
			}
		}
		#endregion

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
			Point MM = e.Location;
			rect = new Rectangle(Math.Min(MD.X, MM.X), Math.Min(MD.Y, MM.Y),
								 Math.Abs(MD.X - MM.X), Math.Abs(MD.Y - MM.Y));


			form2.Hide();
			Screen scr = Screen.AllScreens[0];

			//force correction so that there wont be an error when ppl just click on a spot
			if (rect.Width <= 0)
				rect.Width = 2;
			if (rect.Height <= 0)
				rect.Height = 2;

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


		#region AddCommandNodes
		private void addButton_Click(object sender, EventArgs e)
		{
			if (bmp == null)
				return;
			string pos = rect.Left.ToString()+"," + rect.Top.ToString() +","+ rect.Right.ToString()+"," + rect.Bottom.ToString();
			lVManager.Add(false.ToString(),pos,imgCount.ToString() ,timeStep.Text);
			//local side for bot to work
			int t = int.Parse(timeStep.Text);
			Bitmap b = BitmapConversion.Instance.ResizeTo256Bit(bmp);
			Rectangle r = rect;
			//add into the list in bot functions
			bot.commands.Add(new DataHandler.CommandNode(r, b, t));
			bmp = null;

			//find someway to change this
			addSubNodeButton.Visible = true;
			addSubNodeButton.Enabled= true;
		}
		private void addSubNodeButton_Click(object sender, EventArgs e)
		{
			if (bmp == null)
				return;
			string pos = rect.Left.ToString() + "," + rect.Top.ToString() + "," + rect.Right.ToString() + "," + rect.Bottom.ToString();
			lVManager.Add(true.ToString(), pos, imgCount.ToString(), timeStep.Text);
			//local side for bot to work
			int t = int.Parse(timeStep.Text);
			Bitmap b = BitmapConversion.Instance.ResizeTo256Bit(bmp);
			Rectangle r = rect;
			//add into the list in bot functions
			//TODO change to be able to append to whichever mainNode is selected
			bot.AddSubNodeAt(bot.commands.Count-1,new DataHandler.CommandNode(r, b, t));
			bmp = null;
		}
		#endregion


		#region ButtonOnClicks
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

		private void Save_Click(object sender, EventArgs e)
		{
			if(bmp != null)
			{
				string folderLoc = @".\test";
				Bitmap bmpSmall = BitmapConversion.Instance.ResizeTo256Bit(bmp);

				BitmapConversion.Instance.SaveAsJpeg(folderLoc, "0", bmpSmall);

			}
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			bot.ResetAllNodes();
			timer1.Start();
			timer1.Interval = 1000;
			this.WindowState = FormWindowState.Minimized;
			
		}
		#endregion


		#region Timer
		private void timer1_Tick(object sender, EventArgs e)
		{
			if(bot.RunStep() == false)
			{
				this.WindowState = FormWindowState.Normal;
			}		
		}

		private void Loop_CheckedChanged(object sender, EventArgs e)
		{
			//once hotkey is done this can be uncommented
			bot.loopCommands = loopCheckBox.Checked;
		}


		#endregion

	}
}

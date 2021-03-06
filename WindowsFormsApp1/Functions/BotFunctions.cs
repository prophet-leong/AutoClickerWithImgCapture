﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DataHandler;

namespace WindowsFormsApp1.Functions
{

	public class BotFunctions
	{
		#region MouseEvents
		const int MOUSEEVENTF_LEFTDOWN = 2;
		const int MOUSEEVENTF_LEFTUP = 4;
		const int MOUSEEVENTF_RIGHTDOWN = 8;
		const int MOUSEEVENTF_RIGHT_UP = 16;
		//input type constant
		const int INPUT_MOUSE = 0;

		[DllImport("User32.dll", SetLastError = true)]
		public static extern int SendInput(int nInputs, ref INPUT pInputs, int cbSize);

		public struct MOUSEINPUT
		{
			public int dx;
			public int dy;
			public int mouseData;
			public int dwFlags;
			public int time;
			public IntPtr dwExtraInfo;
		}

		public struct INPUT
		{
			public uint type;
			public MOUSEINPUT mi;
		};
		#endregion

		public int iterationNumb = 0;
		public bool loopCommands = false;
		public List<CommandNode> commands = new List<CommandNode>();
		Timer timerPtr;

		public BotFunctions(Timer timer)
		{
			timerPtr = timer;
		}



		public void AddSubNodeAt(int i,CommandNode n)
		{
			commands[i].FindEmptySubNode().subNode = n;
		}

		public void ResetAllNodes()
		{
			iterationNumb = 0;
			foreach (CommandNode i in commands)
			{
				i.UnmarkAllNodes();
			}
		}
		void NextIteration()
		{
			++iterationNumb;
			if(loopCommands)
			{
				if (iterationNumb >= commands.Count)
				{
					ResetAllNodes();
				}
			}
		}
		CommandNode GetNode()
		{
			if (iterationNumb >= commands.Count)
				return null;
			CommandNode n = commands[iterationNumb].GetAvalibleNode();
			if(n == null)
			{
				NextIteration();
				return GetNode();
			}
			return n;
		}


		public Bitmap printScreen(Rectangle rect)
		{
			Screen scr = Screen.AllScreens[0];
			Bitmap bmp = new Bitmap(rect.Width, rect.Height);
			Graphics g = Graphics.FromImage(bmp);
			g.CopyFromScreen(rect.Location, Point.Empty, rect.Size, CopyPixelOperation.SourceCopy);
			bmp = BitmapConversion.Instance.ResizeTo256Bit(bmp);
			
			return bmp;
		}
		public void MoveCursor(Rectangle rect)
		{
			int x = (int)((rect.Left + rect.Right) * 0.5f);
			int y = (int)((rect.Top + rect.Bottom) * 0.5f);
			Cursor.Position = new Point(x, y);
		}
		public void LeftClick()
		{
			INPUT i = new INPUT();
			i.type = INPUT_MOUSE;
			i.mi.dx = 0; //clickLocation.X;
			i.mi.dy = 0; // clickLocation.Y;
			i.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
			i.mi.dwExtraInfo = IntPtr.Zero;
			i.mi.mouseData = 0;
			i.mi.time = 0;
			//send the input
			SendInput(1, ref i, Marshal.SizeOf(i));
			//set the INPUT for mouse up and send
			i.mi.dwFlags = MOUSEEVENTF_LEFTUP;
			SendInput(1, ref i, Marshal.SizeOf(i));
		}
		public bool RunStep()
		{
			timerPtr.Stop();
			CommandNode node = GetNode();
			if (node != null)
			{
				//Perform Action

				Bitmap bMap = printScreen(node.rect);

				byte[] a = BitmapConversion.Instance.Array1DFromBitmap(node.bmp);
				byte[] b = BitmapConversion.Instance.Array1DFromBitmap(bMap);
				bool SameImage = BitmapConversion.Instance.CompareBytes(a, b);
				if (SameImage)
				{
					node.used = true;
					MoveCursor(node.rect);
					LeftClick();
					NextIteration();
					//set time for the next loop
					timerPtr.Interval = node.time;
				}
				else
				{
					node.used = true;
					timerPtr.Interval = node.time;
				}
				timerPtr.Start();
				return true;
			}
			timerPtr.Stop();
			return false;

		}
	}
}

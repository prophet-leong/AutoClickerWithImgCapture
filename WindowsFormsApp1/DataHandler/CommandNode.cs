using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DataHandler
{
	public class CommandNode
	{
		public Rectangle rect;
		public Bitmap bmp;
		public int time;

		public bool used = false;

		public CommandNode subNode = null;
		public CommandNode (Rectangle r,Bitmap b ,int t)
		{
			used = false;
			rect = r;
			bmp = b;
			time = t;
		}

		public void UnmarkAllNodes()
		{
			if(subNode != null)
			{
				subNode.UnmarkAllNodes();
			}
			used = false;
		}
		public CommandNode FindEmptySubNode()
		{
			if(subNode != null)
			{
				return subNode.FindEmptySubNode();
			}
			return this;
		}

		public CommandNode GetAvalibleNode()
		{
			if (used)
			{
				if (subNode != null)
					return subNode.GetAvalibleNode();
				else
					return null;
			}
			else
				return this;
		}
		public Rectangle GetRectangle()
		{
			if(used && subNode != null)
			{
				return subNode.GetRectangle();
			}
			else
			{
				return rect;
			}
		}
		public Bitmap GetBitmap()
		{
			if (used )
			{
				if (subNode != null)
					return subNode.GetBitmap();
				else
					return null;
			}
			else
			{
				return bmp;
			}
		}
		public int GetTime()
		{
			if (used)
			{
				if (subNode != null)
					return subNode.GetTime();
				else
					return 0;
			}
			else
			{
				return time;
			}
		}
	}
}

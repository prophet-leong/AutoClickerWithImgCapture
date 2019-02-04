using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Structs
{
	public class ListViewManager
	{
		//datatypes
		public List<string> isSubNode = new List<string>();
		public List<string> pos = new List<string>();
		public List<string> imgName = new List<string>();
		public List<string> time = new List<string>();


		ListView listView;
		public ListViewManager(ListView lV)
		{
			listView = lV;
		}
		
		public void Add(string isSub,string position,string imageName,string iteration)
		{
			//storing into a list for storing later
			isSubNode.Add(isSub);
			pos.Add(position);
			imgName.Add(imageName);
			time.Add(iteration);

			ListViewItem item = new ListViewItem(isSub);

			item.SubItems.Add(position);

			item.SubItems.Add(imageName);

			item.SubItems.Add(iteration);

			listView.Items.Add(item);
		}

	}
}

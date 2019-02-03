using System;
using System.Collections.Generic;
using System.Drawing;
using WindowsFormsApp1;

public class LoadFromFolder
{
    
    string URL = string.Empty;
    List<Bitmap> images = new List<Bitmap>();
	LoadFromFolder()
	{
	}
    public LoadFromFolder(string url)
    {
        this.URL = url;
    }
    public bool Load()
    {
        BitmapConversion.Instance.ConvertToBitmap("");
        return true;
    }
}

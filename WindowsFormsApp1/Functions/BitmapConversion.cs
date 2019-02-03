using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WindowsFormsApp1
{
	class BitmapConversion
	{

		private BitmapConversion()
		{
		}
		private static BitmapConversion instance = null;
		public static BitmapConversion Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new BitmapConversion();
				}
				return instance;
			}
		}
		public Bitmap ConvertToBitmap(string fileName)
		{
			Bitmap bitmap;
			using (System.IO.Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
			{
				Image image = Image.FromStream(bmpStream);

				bitmap = new Bitmap(image);

			}
			return bitmap;
		}
		public void SaveAsJpeg(string folderLocation,string FileName, Bitmap bmp)
		{

			string fileName = FileName;
			if (!System.IO.Path.HasExtension(fileName) || System.IO.Path.GetExtension(fileName) != "jpg")
				fileName =folderLocation+"\\"+ fileName + ".jpg";

			bmp.Save(fileName, ImageFormat.Jpeg);
		}
		public Bitmap ResizeTo256Bit(Bitmap bmp)
		{
			Bitmap bmpMin = new Bitmap(bmp, new Size(16, 16));
			return bmpMin;
		}
		public byte[] Array1DFromBitmap(Bitmap bmp)
		{
			if (bmp == null) throw new NullReferenceException("Bitmap is null");

			Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
			BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
			IntPtr ptr = data.Scan0;
			
			//declare an array to hold the bytes of the bitmap
			int numBytes = data.Stride * bmp.Height;
			byte[] bytes = new byte[numBytes];

			//copy the RGB values into the array
			System.Runtime.InteropServices.Marshal.Copy(ptr, bytes, 0, numBytes);

			bmp.UnlockBits(data);
			return bytes;
		}
		public bool CompareBytes(byte[] a,byte[] b)
		{
			string at = string.Join("",a);
			string bt = string.Join("",b);
			if(at == bt)
				return true;
			return false;
		}
	}

}

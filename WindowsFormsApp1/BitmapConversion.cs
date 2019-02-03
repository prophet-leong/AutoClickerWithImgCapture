using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    class BitmapConversion
    {
        public static BitmapConversion convertingBitmap = new BitmapConversion();
        BitmapConversion()
        {
            if(convertingBitmap == null)
            {
                convertingBitmap = this;
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

            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

    }

}

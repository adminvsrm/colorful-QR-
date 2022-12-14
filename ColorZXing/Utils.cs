using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;

namespace ColorZXing
{
    public class Utils
    {
        public static int GetGrayScale(int r, int g, int b)
        {
            return (r + g + b) / 3;
        }

        public static int GetGrayScale(Color color)
        {
            return (color.R + color.G + color.B) / 3;
        }

        public static bool IsDarkColor(Color color)
        {
            return GetGrayScale(color) < 128;
        }
        public static void WriteBitMap(Bitmap bitmap, string filePath, ImageFormat format)
        {
            using (var fs = File.Create(filePath))
            {
                bitmap.Save(fs, format);
            }
        }

        public static Bitmap ReadBitMap(string filePath)
        {
            var bitmap = new Bitmap(filePath);
            return bitmap;
        }

        public static Bitmap CreateBitmap(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return new Bitmap(ms);
            }
        }

        public static Bitmap DownloadBitmap(Uri url)
        {
            var webClient = new WebClient();
            var bytes = webClient.DownloadData(url.AbsoluteUri);
            return CreateBitmap(bytes);
        }
    }
}

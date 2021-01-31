using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;

namespace ImageMixer.Mixer
{
    public class MixerService : IMixerService
    {
        private int MaxWidth { get; set; }
        private int MaxHeight { get; set; }

        public Bitmap GetBitmapFromFile(string filename)
        {
            Image image = Image.FromFile(filename);
            return (Bitmap)image;
        }

        public Bitmap GetBitmapFromUrl(string url)
        {
            using var memoryStream = new MemoryStream();
            var request = WebRequest.Create(url);
            using var response = request.GetResponse();
            response.GetResponseStream()?.CopyTo(memoryStream);
            return (Bitmap)Image.FromStream(memoryStream);
        }

        public List<Bitmap> GetBitmapsFromDirectory(string directoryName)
        {
            var bitmaps = new List<Bitmap>();
            foreach (var filename in Directory.GetFiles(directoryName))
            {
                var bitmap = GetBitmapFromFile(filename);
                MaxWidth += bitmap.Width;
                var bitmapHeight = bitmap.Height > MaxHeight ? bitmap.Height : MaxHeight;
                MaxHeight = bitmapHeight;
                bitmaps.Add(bitmap);
            }
            return bitmaps;
        }
        
        public List<Bitmap> GetBitmapsFromUrls(string[] urls)
        {
            var bitmaps = new List<Bitmap>();
            foreach (var url in urls)
            {
                var bitmap = GetBitmapFromUrl(url);
                MaxWidth += bitmap.Width;
                var bitmapHeight = bitmap.Height > MaxHeight ? bitmap.Height : MaxHeight;
                MaxHeight = bitmapHeight;
                bitmaps.Add(bitmap);
            }
            return bitmaps;
        }

        public Bitmap CombineBitmaps(List<Bitmap> bitmaps)
        {
            var outputBmp = new Bitmap(MaxWidth, MaxHeight);
            var gfx = Graphics.FromImage(outputBmp);
            gfx.Clear(Color.White);
            int currentPosition = 0;
            foreach (var bitmap in bitmaps)
            {
                gfx.DrawImage(bitmap, currentPosition, 0);
                currentPosition += bitmap.Width;
            }
            return outputBmp;
        }
    }
}
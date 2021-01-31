using System.Collections.Generic;
using System.Drawing;

namespace ImageMixer.Mixer
{
    public interface IMixerService
    {
        Bitmap GetBitmapFromFile(string filename);
        Bitmap GetBitmapFromUrl(string url);
        List<Bitmap> GetBitmapsFromDirectory(string directoryName);
        List<Bitmap> GetBitmapsFromUrls(string[] urls);
        Bitmap CombineBitmaps(List<Bitmap> bitmaps);
    }
}
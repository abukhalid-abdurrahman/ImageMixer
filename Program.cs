using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using ImageMixer.Mixer;

namespace ImageMixer
{
    class Program
    {
        static void Main(string[] args)
        {
            IMixerService mixerService = new MixerService();
            var urls = new string[]
            {
                "https://s3-images-mygaleon-ru.storage.cloud.croc.ru/dbf8d2ad-22d7-4d11-9692-9f7116e677e8.jpg", 
                "https://s3-images-mygaleon-ru.storage.cloud.croc.ru/61dd3d38-2517-48ea-b03a-550e14348997.jpg", 
                "https://s3-images-mygaleon-ru.storage.cloud.croc.ru/c32f6537-4077-4d15-8dfa-9b351f09fa50.jpg", 
                "https://s3-images-mygaleon-ru.storage.cloud.croc.ru/b9112020-0ac4-458e-9955-63e7b5b17684.jpg"
            };
            var bmps = mixerService.GetBitmapsFromUrls(urls);
            var outBmp = mixerService.CombineBitmaps(bmps);
            outBmp.Save("output.bmp", ImageFormat.Bmp);
        }
    }
}
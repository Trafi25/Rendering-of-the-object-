using System;
using System.Collections.Generic;
using System.Text;

namespace Conventor.ImageConcept
{
    public class Image
    {
        public ImageHeader Header { get; set; }
        public  string Path { get; set; }
        public  ImageColor[,] Color { get; set; }
        public byte[] RGBPixel { get; set; }

        public  Image(String Path) {
            this.Path = Path;
        }

    }
}

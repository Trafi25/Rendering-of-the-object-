using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Interfaces;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.ImageConcept;

namespace Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Writer
{
    class Ppm_writer : IImageWriter
    {
        private ASCIIEncoding ASCIi = new ASCIIEncoding();

        public void Write(string path, Image image)
        {
            FileStream fs = File.Create(path);
            WriteHeader(fs, image); WriteData(fs, image);
            fs.Close();
        }

        private void WriteData(FileStream ppmFile, Image image)
        {
            ppmFile.Write(image.RGBPixel);
        }

        private void WriteHeader(FileStream ppmFile, Image image)
        {
            ppmFile.Write(ASCIi.GetBytes("P6"));
            ppmFile.WriteByte(10);
            ppmFile.Write(ASCIi.GetBytes(image.Header.Width.ToString()));
            ppmFile.WriteByte(32);
            ppmFile.Write(ASCIi.GetBytes(image.Header.Height.ToString()));
            ppmFile.WriteByte(10);
            ppmFile.Write(ASCIi.GetBytes("255"));
            ppmFile.WriteByte(10);

        }

    }   
}

using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Interfaces;
using System.Drawing;
using System.Drawing.Imaging;

namespace Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.RenderEngine
{
    class Render
    {
        ICameraPositionProvider camera;
        IReader reader;

        public Render(IReader Reader,ICameraPositionProvider Camera)
        {
            reader = Reader;
            camera = Camera;
        }

        public void StartRender(string sourcePath, string outputPath,int size)
        {
            var Triangles = reader.Read(sourcePath);

            Bitmap newBitmap = new Bitmap(size, size,
                                          PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(newBitmap);

            Color clrBackground = Color.Black;

            Rectangle rect = new Rectangle(0, 0, size, size);
            g.FillRectangle(new SolidBrush(clrBackground),
                            rect);

            Graphics graphics = g;

            double Scale = 1.0;

            for (int i = rect.Left; i <= rect.Right; i++)
            {
                double x = GetCoord(rect.Left,
                    rect.Right, -Scale, Scale, i);
                for (int j = rect.Top; j <= rect.Bottom; j++)
                {
                    double y = GetCoord(rect.Top,
                        rect.Bottom, Scale, -Scale, j);
                    double t = 1.0E10;


                }
            }
        }

        private double GetCoord(double i1, double i2, double w1,
            double w2, double p)
        {
            return ((p - i1) / (i2 - i1)) * (w2 - w1) + w1;
        }
    }
}

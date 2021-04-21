using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Interfaces;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Structures;
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

            float Scale = 1.0f;

            for (int i = rect.Left; i <= rect.Right; i++)
            {
                float x = GetCoord(rect.Left,
                    rect.Right, -Scale, Scale, i);
                for (int j = rect.Top; j <= rect.Bottom; j++)
                {
                    float y = GetCoord(rect.Top,
                        rect.Bottom, Scale, -Scale, j);
                    double t = 1.0E10;

                    Vector3 v = new Vector3(x, y, 0)-camera.GetCameraPosition();

                    v.modv();

                    Triangle triangleHit = null;
                    for (int k = 0; k < (int)Triangles.Count; k++)
                    {
                        Triangle triN = (Triangle)Triangles[k];
                        double taux = triN.GetInterSect(camera.GetCameraPosition(), new Vector3(x,y,0));
                        if (taux < 0) continue;

                        if (taux > 0 && taux < t)
                        {
                            t = taux;
                            triangleHit = triN;
                        }
                    }

                    Color color = Color.FromArgb(10, 20, 10);
                }
            }
        }

        private float GetCoord(float i1, float i2, float w1,
            float w2, float p)
        {
            return ((p - i1) / (i2 - i1)) * (w2 - w1) + w1;
        }

        
    }
}

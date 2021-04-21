using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Interfaces;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Scene;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Structures;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;

namespace Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.RenderEngine
{
    class Render
    {
        ICameraPositionProvider camera;
        IReader reader;
        Light light;

        public Render(IReader Reader,ICameraPositionProvider Camera,Light newlight)
        {
            reader = Reader;
            camera = Camera;
            light = newlight;
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

                    v=v.Norm();

                    Triangle triangleHit = null;                    

                    Hit(ref triangleHit,ref t, Triangles, new Vector3(x, y, 0));

                    Color color = Color.FromArgb(10, 20, 10);

                    if (triangleHit != null)
                    {
                        Vector3 Inters = camera.GetCameraPosition() + t * v;

                        Vector3 l2p = Inters-light.LightPosition;
                        l2p = l2p.Norm();
                        
                        Vector3 vNormal = triangleHit.Normal;
                        vNormal = vNormal.Norm();

                        double cost=GetCosAngle(l2p,vNormal);
                    }
                }
            }
        }

        private float GetCoord(float i1, float i2, float w1,
            float w2, float p)
        {
            return ((p - i1) / (i2 - i1)) * (w2 - w1) + w1;
        }

        private void Hit(ref Triangle triangle,ref double t, ArrayList Triangles,Vector3 Ray)
        {
            for (int k = 0; k < (int)Triangles.Count; k++)
            {
                Triangle triN = (Triangle)Triangles[k];
                double taux = triN.GetInterSect(camera.GetCameraPosition(), Ray);
                if (taux < 0) continue;

                if (taux > 0 && taux < t)
                {
                    t = taux;
                    triangle = triN;
                }
            }
        }

        private double GetCosAngle(Vector3 v1,Vector3 v2)
        {
            var temp = v1.Norm();
            var temp1 = v2.Norm();

            double n = (temp.X * temp1.X + temp.Y * temp1.Y + temp.Z * temp1.Z);
            double d = (temp.Length * temp1.Length);

            if (Math.Abs(d) < 1.0E-10) return 0;
            return n / d;
        }
    }
}

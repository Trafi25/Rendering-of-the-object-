using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Interfaces;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Scene;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Structures;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Tree;
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

            Octree tree = new Octree(Triangles);

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
                    Console.WriteLine($"X:{i}");
                    Console.WriteLine($"Y:{j}");
                    Vector3 v = new Vector3(x, y, 0)-camera.GetCameraPosition();

                    v=v.Norm();

                    Triangle triangleHit = null;

                    tree.FindTrianle(ref triangleHit, ref t, new Vector3(x, y, 0), camera.GetCameraPosition());

                    //Hit(ref triangleHit,ref t, Triangles, new Vector3(x, y, 0),camera.GetCameraPosition());

                    Color color = Color.FromArgb(10, 20, 10);

                    if (triangleHit != null)
                    {
                        Vector3 Inters = camera.GetCameraPosition() + t * v;

                        Vector3 l2p = Inters-light.LightPosition;
                        l2p = l2p.Norm();
                        
                        Vector3 vNormal = triangleHit.Normal;
                        vNormal = vNormal.Norm();

                        double cost=GetCosAngle(l2p,vNormal);

                        if (cost < 0) cost = 0;

                        Vector3 vEye2Inters = Inters - camera.GetCameraPosition();

                        Vector3 vRefl = Reflect(l2p,vNormal);

                        vRefl = vRefl.Norm();
                        vEye2Inters = vEye2Inters.Norm();

                        double cosf = GetCosAngle(vRefl,vEye2Inters);

                        if (cosf < 0)
                            cosf = 0;

                        double result1 = cost * 255.0;

                        double rgbR = (triangleHit.RGB.X * 255)+(0.3775*result1);
                        double rgbG = (triangleHit.RGB.Y * 255) + (0.3775 * result1);
                        double rgbB = (triangleHit.RGB.Z * 255) + (0.5775 * result1);

                        rgbR = Math.Min(rgbR, 255);
                        rgbG = Math.Min(rgbG, 255);
                        rgbB = Math.Min(rgbB, 255);
                        rgbR = Math.Max(rgbR, 0);
                        rgbG = Math.Max(rgbG, 0);
                        rgbB = Math.Max(rgbB, 0);

                        color = Color.FromArgb((int)rgbR, (int)rgbG, (int)rgbB);
                    }

                    Brush brs = new SolidBrush(color);
                    graphics.FillRectangle(brs, i, j, 1, 1);
                    brs.Dispose();
                }

            }

            newBitmap.Save(outputPath, ImageFormat.Png);
        }

        private float GetCoord(float i1, float i2, float w1,
            float w2, float p)
        {
            return ((p - i1) / (i2 - i1)) * (w2 - w1) + w1;
        }

        public static void Hit(ref Triangle triangle,ref double t, ArrayList Triangles,Vector3 Ray,Vector3 camera)
        {
            for (int k = 0; k < (int)Triangles.Count; k++)
            {
                Triangle triN = (Triangle)Triangles[k];
                double taux = triN.GetInterSect(camera, Ray);
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

        private Vector3 Reflect(Vector3 light,Vector3 normal)
        {
            var vx = light.X - (2.0 * normal.X * light.DotProduct(normal));
            var vy = light.Y - (2.0 * normal.Y * light.DotProduct(normal));
            var vz = light.Z - (2.0 * normal.Z * light.DotProduct(normal));
            Vector3 v = new Vector3((float)vx, (float)vy, (float)vz);
            v = v.Norm();
            return v;
        }
    }
}

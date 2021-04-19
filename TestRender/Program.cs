using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRender
{
    class Program
    {
        static void Main(string[] args)
        {
            //bitmap newbitmap = new bitmap(800, 800, pixelformat.format32bppargb);
            //graphics g = graphics.fromimage(newbitmap);

            //color clrbackground = color.black;
            //g.fillrectangle(new solidbrush(clrbackground), new rectangle(0, 0, 800,
            //                800));
            //rectangle rect = new rectangle(0, 0, 800, 800);

            //system.collections.arraylist obj3darraylist;
            //obj3darraylist = new system.collections.arraylist();
            //obj3darraylist.add(new sphere(0.0, 0.0, 90.0, 100.0, 0.0, 0.0, 255.0));
            //obj3darraylist.add(new sphere(-180.0, -130.0, -110.0, 15.0, 255.0, 0.0,
            //                   0.0));
            //obj3darraylist.add(new sphere(-140.0, -140.0, -150.0, 20.0, 255.0, 200.0,
            //                   0.0));
            //graphics graphics = g;
            //// viewer position
            //double px = 0,
            //py = 0,
            //pz = 900;
            //// light position
            //double lpx = 0,
            //lpy = 0,
            //lpz = 100;
            //// light direction
            //double lvx = 100,
            //lvy = 100,
            //lvz = -1;
            //double fmax = 200.0;

            //for (int i = rect.left; i <= rect.right; i++)
            //{
            //    double x = sphere.getcoord(rect.left, rect.right, -fmax, fmax, i);
            //    for (int j = rect.top; j <= rect.bottom; j++)
            //    {
            //        double y = sphere.getcoord(rect.top, rect.bottom, fmax, -fmax, j);
            //        double t = 1.0e10;
            //        double vx = x - px, vy = y - py, vz = -pz;
            //        double mod_v = sphere.modv(vx, vy, vz);
            //        vx = vx / mod_v;
            //        vy = vy / mod_v;
            //        vz = vz / mod_v;
            //        bool bshadow = false;
            //        sphere spherehit = null;
            //        for (int k = 0; k < (int)obj3darraylist.count; k++)
            //        {
            //            sphere sphn = (sphere)obj3darraylist[k];
            //            double taux = sphere.getsphereintersec(sphn.cx, sphn.cy,
            //                          sphn.cz,
            //                          sphn.radius, px, py, pz, vx, vy, vz);
            //            if (taux < 0) continue;
            //            if (taux > 0 && taux < t)
            //            {
            //                t = taux;
            //                spherehit = sphn;
            //            }
            //        }
            //        color color = color.fromargb(10, 20, 10);
            //        if (spherehit != null)
            //        {
            //            double itx = px + t * vx, ity = py + t * vy, itz = pz +
            //            t * vz;
            //            // shadow
            //            double tauxla = sphere.getsphereintersec(spherehit.cx,
            //                            spherehit.cy, spherehit.cz, spherehit.radius,
            //                            lpx, lpy, lpz, itx - lpx,
            //                            ity - lpy, itz - lpz);

            //            for (int k = 0; k < (int)obj3darraylist.count; k++)
            //            {
            //                sphere sphnb = (sphere)(obj3darraylist[k]);
            //                if (sphnb != spherehit)
            //                {
            //                    double tauxlb = sphere.getsphereintersec(sphnb.cx,
            //                                    sphnb.cy, sphnb.cz, sphnb.radius, lpx,
            //                                    lpy, lpz, itx - lpx, ity - lpy, itz -
            //                                    lpz);
            //                    if (tauxlb > 0 && tauxla < tauxlb)
            //                    {
            //                        bshadow = true;
            //                        break;
            //                    }
            //                }
            //            }
            //            double cost = sphere.getcosanglev1v2(lvx, lvy, lvz, itx -
            //                          spherehit.cx, ity - spherehit.cy, itz -
            //                          spherehit.cz);
            //            if (cost < 0) cost = 0;
            //            double fact = 1.0;
            //            if (bshadow == true) fact = 0.5; else fact = 1.0;
            //            double rgbr = spherehit.clr * cost * fact;
            //            double rgbg = spherehit.clg * cost * fact;
            //            double rgbb = spherehit.clb * cost * fact;
            //            color = color.fromargb((int)rgbr, (int)rgbg, (int)rgbb);
            //            //pen = new pen(color);
            //        }
            //        brush brs = new solidbrush(color);
            //        graphics.fillrectangle(brs, i, j, 1, 1);
            //        brs.dispose();

            //    }// for pixels lines
            //}
            //newbitmap.save(@"c:\users\user\desktop\комп графика\testrender\final.png", imageformat.png);








            int scz = 400;

            System.IO.FileStream file = new System.IO.FileStream(
                @"c:\users\user\desktop\комп графика\testrender\cow.obj",
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read);
            System.IO.StreamReader reader = new System.IO.StreamReader(file);
            string filebody = reader.ReadToEnd();
            file.Close();

            string[] lines = filebody.Split('\n');
            ArrayList pointArrayX = new ArrayList();
            ArrayList pointArrayY = new ArrayList();
            ArrayList pointArrayZ = new ArrayList();

            System.Collections.ArrayList obj3dArrayList;
            obj3dArrayList = new System.Collections.ArrayList();

            double rx = 0.5000;
            double ry = 0.5000;
            double rz = 0.0000;

            foreach (string line in lines)
            {
                if (line.Length < 1) continue;
                string auxline = line;
                if (auxline.IndexOf("mtllib") >= 0)
                {
                    auxline = auxline.Replace("mtllib", "");
                    //GetMaterial(auxline);
                }
                else
                    if (auxline[0] == 'v' && auxline[1]!='n')
                {
                    auxline = auxline.Replace("v ", "");
                    auxline = auxline.Replace("\r", "");
                    string[] points = auxline.Split(' ');
                    double x = double.Parse(points[0], CultureInfo.InvariantCulture);
                    double y = double.Parse(points[1], CultureInfo.InvariantCulture);
                    double z = double.Parse(points[2], CultureInfo.InvariantCulture);
                    pointArrayX.Add(x);
                    pointArrayY.Add(y);
                    pointArrayZ.Add(z);
                }
                else
                        if (auxline[0] == 'f')
                {
                    auxline = auxline.Replace("f ", "");
                    auxline = auxline.Replace("//"," ");
                    string[] vertices = auxline.Split(' ');
                    int a = int.Parse(vertices[0]) - 1;
                    int b = int.Parse(vertices[2]) - 1;
                    int c = int.Parse(vertices[4]) - 1;

                    tTriangle tri1 = new tTriangle();
                    tri1.tp1x = (double)pointArrayX[a];
                    tri1.tp1y = (double)pointArrayY[a];
                    tri1.tp1z = (double)pointArrayZ[a];

                    tri1.tp2x = (double)pointArrayX[b];
                    tri1.tp2y = (double)pointArrayY[b];
                    tri1.tp2z = (double)pointArrayZ[b];
                    tri1.tp3x = (double)pointArrayX[c];
                    tri1.tp3y = (double)pointArrayY[c];
                    tri1.tp3z = (double)pointArrayZ[c];

                    tAlgebra.RotX(rx, ref tri1.tp1y, ref tri1.tp1z);
                    tAlgebra.RotX(rx, ref tri1.tp2y, ref tri1.tp2z);
                    tAlgebra.RotX(rx, ref tri1.tp3y, ref tri1.tp3z);
                    tAlgebra.RotY(ry, ref tri1.tp1x, ref tri1.tp1z);
                    tAlgebra.RotY(ry, ref tri1.tp2x, ref tri1.tp2z);
                    tAlgebra.RotY(ry, ref tri1.tp3x, ref tri1.tp3z);
                    tAlgebra.RotZ(rz, ref tri1.tp1x, ref tri1.tp1y);
                    tAlgebra.RotZ(rz, ref tri1.tp2x, ref tri1.tp2y);
                    tAlgebra.RotZ(rz, ref tri1.tp3x, ref tri1.tp3y);

                    // ambient properties for the material   
                    tri1.ambientR = 0.3;
                    tri1.ambientG = 0.4;
                    tri1.ambientB = 0.5;
                    // specular properties for the material   
                    tri1.specularR = 0.911;
                    tri1.specularG = 0.911;
                    tri1.specularB = 0.911;
                    tri1.shininess = 10.6;
                    tri1.diffuseR = 0.3775;
                    tri1.diffuseG = 0.3775;
                    tri1.diffuseB = 0.5775;
                    obj3dArrayList.Add(tri1);
                    tri1.Init();
                }
            }

            Bitmap newBitmap = new Bitmap(scz, scz,
                                          PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(newBitmap);

            Color clrBackground = Color.Black;

            Rectangle rect = new Rectangle(0, 0, scz, scz);
            g.FillRectangle(new SolidBrush(clrBackground),
                            rect);

            Graphics graphics = g;

            double px = 0.0;
            double py = -50.0;
            double pz = 50.0;

            double lpx = 1.0;
            double lpy = 1.0;
            double lpz = 500.0;

            double lp2x = lpx;
            double lp2y = lpy;
            double lp2z = lpz - 0.1;

            double lvx = lp2x - lpx;
            double lvy = lp2y - lpy;
            double lvz = lp2z - lpz;

            tAlgebra.Normalize(ref lvx, ref lvy, ref lvz);

            // virtual mapping size
            double fMax = 2.5;

            for (int i = rect.Left; i <= rect.Right; i++)
            {
                double x = tAlgebra.GetCoord(rect.Left,
                    rect.Right, -fMax, fMax, i);

                for (int j = rect.Top; j <= rect.Bottom; j++)
                {
                    double y = tAlgebra.GetCoord(rect.Top,
                        rect.Bottom, fMax, -fMax, j);

                    double t = 1.0E10;

                    double vx = x - px, vy = y - py, vz = -pz;

                    double mod_v = tAlgebra.modv(vx, vy, vz);
                    vx = vx / mod_v;
                    vy = vy / mod_v;
                    vz = vz / mod_v;

                    bool bShadow = false;

                    tTriangle triangleHit = null;

                    for (int k = 0; k < (int)obj3dArrayList.Count; k++)
                    {
                        tTriangle triN = (tTriangle)obj3dArrayList[k];
                        double taux = triN.GetInterSect(px, py, pz, x, y, 0.0);
                        if (taux < 0) continue;

                        if (taux > 0 && taux < t)
                        {
                            t = taux;
                            triangleHit = triN;
                        }
                    }

                    Color color = Color.FromArgb(10, 20, 10);

                    if (triangleHit != null)
                    {
                        double intersx = px + t * vx,
                            intersy = py + t * vy, intersz = pz + t * vz;
                        double l2px = intersx - lpx,
                            l2py = intersy - lpy, l2pz = intersz - lpz;
                        tAlgebra.Normalize(ref l2px, ref l2py, ref l2pz);

                        double vNormalX = triangleHit.tnormalX,
                            vNormalY = triangleHit.tnormalY,
                            vNormalZ = triangleHit.tnormalZ;
                        tAlgebra.Normalize(ref vNormalX, ref vNormalY,
                            ref vNormalZ);

                        double cost = tAlgebra.GetCosAngleV1V2(l2px, l2py, l2pz,
                            vNormalX, vNormalY, vNormalZ);
                        if (cost < 0) cost = 0;

                        double vReflX = 0, vReflY = 0, vReflZ = 0;
                        double vEye2IntersX = intersx - px,
                            vEye2IntersY = intersy - py,
                            vEye2IntersZ = intersz - pz;
                        tAlgebra.Reflect(l2px, l2py, l2pz, vNormalX, vNormalY,
                            vNormalZ, ref vReflX, ref vReflY, ref vReflZ);

                        tAlgebra.Normalize(ref vReflX, ref vReflY, ref vReflZ);
                        tAlgebra.Normalize(ref vEye2IntersX, ref vEye2IntersY,
                            ref vEye2IntersZ);
                        double cosf = tAlgebra.GetCosAngleV1V2(vReflX, vReflY,
                            vReflZ, vEye2IntersX, vEye2IntersY,
                            vEye2IntersZ);

                        if (cosf < 0)
                            cosf = 0;

                        double result1 = cost * 255.0;
                        double result2 = Math.Pow(cosf, triangleHit.shininess) *
                            255.0;

                        double rgbR = (triangleHit.ambientR * 255.0) +
                            (triangleHit.diffuseR * result1) +
                            (triangleHit.specularR * result2);
                        double rgbG = (triangleHit.ambientG * 255.0) +
                            (triangleHit.diffuseG * result1) +
                            (triangleHit.specularG * result2);
                        double rgbB = (triangleHit.ambientB * 255.0) +
                            (triangleHit.diffuseB * result1) +
                            (triangleHit.specularB * result2);

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

                }// for pixels lines
            }// for pixels columns


            newBitmap.Save(@"c:\users\user\desktop\комп графика\testrender\final1.png", ImageFormat.Png);
            Console.WriteLine("End");
        }
    }
}

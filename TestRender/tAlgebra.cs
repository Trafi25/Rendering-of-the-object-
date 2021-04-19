using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRender
{
    class tAlgebra
    {
        public tAlgebra()
        {
        }

        //i' = i - (2 * n * dot(i, n))
        public static void Reflect(double ix, double iy, double iz,
            double nx, double ny, double nz,
            ref double iix, ref double iiy, ref double iiz)
        {
            iix = ix - (2.0 * nx * Dot3(nx, ny, nz, ix, iy, iz));
            iiy = iy - (2.0 * ny * Dot3(nx, ny, nz, ix, iy, iz));
            iiz = iz - (2.0 * nz * Dot3(nx, ny, nz, ix, iy, iz));
            Normalize(ref iix, ref iiy, ref iiz);
        }
        public static void Cross3(double ux, double uy, double uz,
            double wx,
            double wy, double wz,
            ref double vx, ref double vy,
            ref double vz)
        {
            // u x w
            vx = wz * uy - wy * uz;
            vy = wx * uz - wz * ux;
            vz = wy * ux - wx * uy;
        }
        public static double Dot3(double x1, double y1, double z1,
            double x2, double y2, double z2)
        {
            return (x1 * x2) + (y1 * y2) + (z1 * z2);
        }
        public static double GetCosAngleV1V2(double v1x, double v1y,
            double v1z, double v2x, double v2y, double v2z)
        {
            /* incident angle
            // inters pt (i)
            double ix, iy, iz;
            ix = px+t*vx;
            iy = py+t*vy;
            iz = pz+t*vz;

            // normal at i
            double nx, ny, nz;
            nx = ix - cx;
            ny = iy - cy;
            nz = iz - cz;
            */
            double x, y, z;
            x = v1x; y = v1y; z = v1z;
            Normalize(ref x, ref y, ref z);
            v1x = x; v1y = y; v1z = z;

            x = v2x; y = v2y; z = v2z;
            Normalize(ref x, ref y, ref z);
            v2x = x; v2y = y; v2z = z;

            // cos(t) = (v.w) / (|v|.|w|)
            double n = (v1x * v2x + v1y * v2y + v1z * v2z);
            double d = (modv(v1x, v1y, v1z) * modv(v2x, v2y, v2z));

            if (Math.Abs(d) < 1.0E-10) return 0;
            return n / d;
        }
        public static double modv(double vx, double vy, double vz)
        {
            return System.Math.Sqrt(vx * vx + vy * vy + vz * vz);
        }
        public static double GetCoord(double i1, double i2, double w1,
            double w2, double p)
        {
            return ((p - i1) / (i2 - i1)) * (w2 - w1) + w1;
        }

        public static void Normalize(ref double vx, ref double vy,
            ref double vz)
        {
            double mod_v = tAlgebra.modv(vx, vy, vz);
            if (Math.Abs(mod_v) < 1.0E-10) return;
            vx = vx / mod_v;
            vy = vy / mod_v;
            vz = vz / mod_v;
        }

        public static void RotX(double angle, ref double y, ref double z)
        {
            double y1 = y * System.Math.Cos(angle) - z * System.Math.Sin(angle);
            double z1 = y * System.Math.Sin(angle) + z * System.Math.Cos(angle);
            y = y1;
            z = z1;
        }

        public static void RotY(double angle, ref double x, ref double z)
        {
            double x1 = x * System.Math.Cos(angle) - z * System.Math.Sin(angle);
            double z1 = x * System.Math.Sin(angle) + z * System.Math.Cos(angle);
            x = x1;
            z = z1;
        }

        public static void RotZ(double angle, ref double x, ref double y)
        {
            double x1 = x * System.Math.Cos(angle) - y * System.Math.Sin(angle);
            double y1 = x * System.Math.Sin(angle) + y * System.Math.Cos(angle);
            x = x1;
            y = y1;
        }
    }
}

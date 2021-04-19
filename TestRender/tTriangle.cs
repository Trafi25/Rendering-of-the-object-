using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRender
{
    class tTriangle:tObject
    {
        public tTriangle()
        {
        }

        public void Init()
        {
            getNormal(ref tnormalX, ref tnormalY, ref tnormalZ);
        }
        public bool SameSide(double p1x, double p1y, double p1z,
            double p2x, double p2y, double p2z,
            double ax, double ay, double az,
            double bx, double by, double bz)
        {
            double cp1x = 0, cp1y = 0, cp1z = 0, cp2x = 0, cp2y = 0,
                cp2z = 0;
            tAlgebra.Cross3(bx - ax, by - ay, bz - az, p1x - ax,
                p1y - ay, p1z - az, ref cp1x, ref cp1y, ref cp1z);
            tAlgebra.Cross3(bx - ax, by - ay, bz - az, p2x - ax,
                p2y - ay, p2z - az, ref cp2x, ref cp2y, ref cp2z);
            if (tAlgebra.Dot3(cp1x, cp1y, cp1z, cp2x, cp2y, cp2z) >= 0)
                return true;
            else
                return false;
        }
        public bool PointInTriangle(double px, double py, double pz)
        {
            if (SameSide(px, py, pz, tp1x, tp1y, tp1z,
                tp2x, tp2y, tp2z, tp3x, tp3y, tp3z) &&
            SameSide(px, py, pz, tp2x, tp2y, tp2z,
                tp1x, tp1y, tp1z, tp3x, tp3y, tp3z) &&
            SameSide(px, py, pz, tp3x, tp3y, tp3z,
                tp1x, tp1y, tp1z, tp2x, tp2y, tp2z))
                return true;
            else
                return false;
        }

        // ray p1, ray p2
        public double GetInterSect(double p1x, double p1y, double p1z,
            double p2x, double p2y, double p2z)
        {
            double v1x = tp3x - p1x; double v1y = tp3y - p1y;
            double v1z = tp3z - p1z;
            double v2x = p2x - p1x; double v2y = p2y - p1y;
            double v2z = p2z - p1z;
            double dot1 = tAlgebra.Dot3(tnormalX, tnormalY, tnormalZ,
                v1x, v1y, v1z);
            double dot2 = tAlgebra.Dot3(tnormalX, tnormalY, tnormalZ,
                v2x, v2y, v2z);
            if (Math.Abs(dot2) < 1.0E-6)
                return -1; // division by 0 means parallel
            double u = dot1 / dot2;
            // point in triangle?
            if (!PointInTriangle(p1x + u * (p2x - p1x),
                p1y + u * (p2y - p1y), p1z + u * (p2z - p1z)))
                return -1;
            return u;
        }
        public void getNormal(ref double vx, ref double vy, ref double vz)
        {
            double ux = tp3x - tp1x, uy = tp3y - tp1y, uz = tp3z - tp1z;
            double wx = tp2x - tp1x, wy = tp2y - tp1y, wz = tp2z - tp1z;

            // u x w
            vx = wz * uy - wy * uz;
            vy = wx * uz - wz * ux;
            vz = wy * ux - wx * uy;
        }


        public double tp1x, tp1y, tp1z;
        public double tp2x, tp2y, tp2z;
        public double tp3x, tp3y, tp3z;
        public double tnormalX, tnormalY, tnormalZ;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Structures
{
    class Triangle
    {
        public Vector3 a;
        public Vector3 b;
        public Vector3 c;
        public Vector3 RGB;
        public Vector3 Normal;

        public Triangle(Vector3 a, Vector3 b, Vector3 c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            GetNormal();
        }

        public void GetNormal()
        {            
            Vector3 temp = c - a;
            Vector3 temp1 = b - a;
                        
            var vx = temp1.Z*temp.Y-temp1.Y*temp.Z;
            var vy = temp1.X * temp.Z - temp1.Z * temp.X;
            var vz = temp1.Y * temp.X - temp1.X * temp.Y;
            Normal = new Vector3(vx, vy, vz);
        }

        public double GetInterSect(Vector3 Camera,
            Vector3 Ray)
        {
            Vector3 v1 = c - Camera;
            Vector3 v2 = Ray - Camera;            
            var dot1 = Normal.DotProduct(v1);
            var dot2 = Normal.DotProduct(v2);
            if (Math.Abs(dot2) < 1.0E-6)
                return -1; 
            double u = dot1 / dot2;
            // point in triangle?
            if (!PointInTriangle(Camera + u * (Ray - Camera)))
                return -1;
            return u;
        }

        public bool PointInTriangle(Vector3 Point)
        {
            if (SameSide(Point,a,b,c) &&
            SameSide(Point,b,a,c) &&
            SameSide(Point,c,a,b))
                return true;
            else
                return false;
        }

        public bool SameSide(Vector3 p1,Vector3 p2,Vector3 a,Vector3 b)
        {
            

            Vector3 Cp1 = (b-a).CrossProduct(p1-a);
            Vector3 Cp2 = (b-a).CrossProduct(p2-a);
            if (Cp1.DotProduct(Cp2) >= 0)
                return true;
            else
                return false;
        }
    }
}

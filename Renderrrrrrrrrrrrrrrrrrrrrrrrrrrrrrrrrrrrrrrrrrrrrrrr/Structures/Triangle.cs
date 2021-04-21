using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reander.Structures
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
    }
}

using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Interfaces;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Readers
{
    class ObjReader : IReader
    {
        public ArrayList Read(string path)
        {
            System.IO.FileStream file = new System.IO.FileStream(
                path,
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read);
            System.IO.StreamReader reader = new System.IO.StreamReader(file);
            string filebody = reader.ReadToEnd();
            file.Close();

            string[] lines = filebody.Split('\n');

            ArrayList Points = new ArrayList();
            ArrayList Triangles = new ArrayList();

            foreach(string line in lines)
            {

                if (line.Length < 1) continue;
                string auxline = line;

                if (auxline[0] == 'v' && auxline[1] != 'n' && auxline[1] != 't')
                {
                    auxline = auxline.Replace("v ", "");
                    auxline = auxline.Replace("\r", "");
                    string[] points = auxline.Split(' ');
                    float x = float.Parse(points[0], CultureInfo.InvariantCulture);
                    float y = float.Parse(points[1], CultureInfo.InvariantCulture);
                    float z = float.Parse(points[2], CultureInfo.InvariantCulture);
                    Points.Add(new Vector3(x,y,z));
                }
                else
                        if (auxline[0] == 'f')
                {
                    auxline = auxline.Replace("f ", "");
                    string[] vertices = auxline.Split(' ');
                    int a, b, c;
                    if (vertices[0].Contains("/"))
                    {
                        a = int.Parse(vertices[0].Split("/")[0]) - 1;
                        b = int.Parse(vertices[1].Split("/")[0]) - 1;
                        c = int.Parse(vertices[2].Split("/")[0]) - 1;
                    }
                    else
                    {
                        a = int.Parse(vertices[0]) - 1;
                        b = int.Parse(vertices[1]) - 1;
                        c = int.Parse(vertices[2]) - 1;
                    }
                    Triangle tri1 = new Triangle((Vector3)Points[a],(Vector3)Points[b],(Vector3)Points[c]);
 
                    tri1.RGB = new Vector3(0.4f,0.4f,0.5f);                    
                    Triangles.Add(tri1);                    
                }
            }

            return Triangles;
        }
    }
}

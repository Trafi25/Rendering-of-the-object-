using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.RenderEngine;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Tree
{
    class Octree
    {
        private Node Head;

        public Octree(ArrayList Triangles)
        {
            List<Vector3> points = new List<Vector3>() {
                new Vector3(-1, -1, -1),
                new Vector3(-1, -1, 1),
                new Vector3(1, -1, 1),
                new Vector3(1, -1, -1),
                new Vector3(-1, 1, -1),
                new Vector3(-1, 1, 1),
                new Vector3(1, 1, 1),
                new Vector3(1, 1, -1)
            };
                        

            Head = new Node(points);

            foreach (var Triangle in Triangles)
            {
                Head.TrianglesInNode.Add((Triangle)Triangle);
            }

            Head.DivideTheCube();
        }

        public void FindTrianle(ref Triangle triangle, ref double t, Vector3 Ray, Vector3 camera)
        {
            Head.FindTriangle(ref triangle, ref t, Ray, camera);
        }

        private class Node
        {
            private List<Vector3> Tops;
            public List<Triangle> TrianglesInNode;
            private List<Triangle> EdgesTriangle;
            private List<Node> Childes;

            public Node(List<Vector3> Points)
            {
                Tops = Points;
                TrianglesInNode = new List<Triangle>();
                Childes = new List<Node>();
                EdgesTriangle = new List<Triangle>();
                EdgesTriangle.Add(new Triangle(Tops[0], Tops[4], Tops[7]));
                EdgesTriangle.Add(new Triangle(Tops[0], Tops[3], Tops[7]));
                EdgesTriangle.Add(new Triangle(Tops[0], Tops[3], Tops[2]));
                EdgesTriangle.Add(new Triangle(Tops[0], Tops[1], Tops[2]));
                EdgesTriangle.Add(new Triangle(Tops[1], Tops[4], Tops[5]));
                EdgesTriangle.Add(new Triangle(Tops[0], Tops[1], Tops[4]));
                EdgesTriangle.Add(new Triangle(Tops[6], Tops[7], Tops[3]));
                EdgesTriangle.Add(new Triangle(Tops[6], Tops[2], Tops[3]));
                EdgesTriangle.Add(new Triangle(Tops[6], Tops[2], Tops[5]));
                EdgesTriangle.Add(new Triangle(Tops[2], Tops[1], Tops[5]));
                EdgesTriangle.Add(new Triangle(Tops[4], Tops[6], Tops[7]));
                EdgesTriangle.Add(new Triangle(Tops[4], Tops[6], Tops[5]));
            }

            public void DivideTheCube()
            {
                Childes.Add(new Node(new List<Vector3>() {
                Tops[0],
                0.5f*(Tops[0]+Tops[1]),
                0.5f*(Tops[0]+Tops[2]),
                0.5f*(Tops[0]+Tops[3]),
                0.5f*(Tops[0]+Tops[4]),
                0.5f*(Tops[0]+Tops[5]),
                0.5f*(Tops[0]+Tops[6]),
                0.5f*(Tops[0]+Tops[7])
                }));

                Childes.Add(new Node(new List<Vector3>() {
                0.5f*(Tops[0]+Tops[1]),
                Tops[1],
                0.5f*(Tops[1]+Tops[2]),
                0.5f*(Tops[1]+Tops[3]),
                0.5f*(Tops[1]+Tops[4]),
                0.5f*(Tops[1]+Tops[5]),
                0.5f*(Tops[1]+Tops[6]),
                0.5f*(Tops[1]+Tops[7])
                }));

                Childes.Add(new Node(new List<Vector3>() {
                0.5f*(Tops[2]+Tops[0]),
                0.5f*(Tops[1]+Tops[2]),
                Tops[2],
                0.5f*(Tops[2]+Tops[3]),
                0.5f*(Tops[2]+Tops[4]),
                0.5f*(Tops[2]+Tops[5]),
                0.5f*(Tops[2]+Tops[6]),
                0.5f*(Tops[2]+Tops[7])
                }));

                Childes.Add(new Node(new List<Vector3>() {
                0.5f*(Tops[3]+Tops[0]),
                0.5f*(Tops[1]+Tops[3]),
                0.5f*(Tops[2]+Tops[3]),
                Tops[3],
                0.5f*(Tops[3]+Tops[4]),
                0.5f*(Tops[3]+Tops[5]),
                0.5f*(Tops[3]+Tops[6]),
                0.5f*(Tops[3]+Tops[7])
                }));

                Childes.Add(new Node(new List<Vector3>() {
                0.5f*(Tops[4]+Tops[0]),
                0.5f*(Tops[1]+Tops[4]),
                0.5f*(Tops[2]+Tops[4]),
                0.5f*(Tops[3]+Tops[4]),
                Tops[4],
                0.5f*(Tops[4]+Tops[5]),
                0.5f*(Tops[4]+Tops[6]),
                0.5f*(Tops[4]+Tops[7])
                }));

                Childes.Add(new Node(new List<Vector3>() {
                0.5f*(Tops[5]+Tops[0]),
                0.5f*(Tops[1]+Tops[5]),
                0.5f*(Tops[2]+Tops[5]),
                0.5f*(Tops[3]+Tops[5]),
                0.5f*(Tops[4]+Tops[5]),
                Tops[5],
                0.5f*(Tops[5]+Tops[6]),
                0.5f*(Tops[5]+Tops[7])
                }));

                Childes.Add(new Node(new List<Vector3>() {
                0.5f*(Tops[6]+Tops[0]),
                0.5f*(Tops[1]+Tops[6]),
                0.5f*(Tops[2]+Tops[6]),
                0.5f*(Tops[3]+Tops[6]),
                0.5f*(Tops[4]+Tops[6]),
                0.5f*(Tops[5]+Tops[6]),
                Tops[6],
                0.5f*(Tops[6]+Tops[7])
                }));

                Childes.Add(new Node(new List<Vector3>() {
                0.5f*(Tops[7]+Tops[0]),
                0.5f*(Tops[1]+Tops[7]),
                0.5f*(Tops[2]+Tops[7]),
                0.5f*(Tops[3]+Tops[7]),
                0.5f*(Tops[4]+Tops[7]),
                0.5f*(Tops[5]+Tops[7]),
                0.5f*(Tops[6]+Tops[7]),
                Tops[7]
                }));

                for (int i = 0; i < 8; i++)
                {
                    var temp = Childes[i];
                    var FreeTriangles = TrianglesInNode.GetRange(0, TrianglesInNode.Count);
                    foreach (var Triangle in TrianglesInNode)
                    {
                        if (temp.TriangleHitTheCube(Triangle))
                        {
                            temp.TrianglesInNode.Add(Triangle);
                            FreeTriangles.Remove(Triangle);
                        }else if(temp.PointInTheCube(Triangle))
                        {
                            temp.TrianglesInNode.Add(Triangle);
                        }
                    }
                    TrianglesInNode = FreeTriangles;
                    Childes[i] = temp;
                }

                if (TrianglesInNode.Count > 0)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        var temp = Childes[i];
                        var FreeTriangles = TrianglesInNode.GetRange(0, TrianglesInNode.Count);
                        foreach (var Triangle in TrianglesInNode)
                        {
                            if (temp.PointInTheCube(Triangle))
                            {
                                FreeTriangles.Remove(Triangle);
                            }
                        }
                        TrianglesInNode = FreeTriangles;
                        Childes[i] = temp;
                    }
                }

                for (int i = 0; i < 8; i++)
                    {
                        if (Childes[i].TrianglesInNode.Count < 50)
                        {
                            continue;
                        }
                        Childes[i].DivideTheCube();
                    }                
                }

                private bool PointInTheCube(Triangle triangle)
                {
                    bool CheckX = (triangle.a.X > Tops[0].X && triangle.a.X < Tops[6].X) || (triangle.b.X > Tops[0].X && triangle.b.X < Tops[6].X) || (triangle.c.X > Tops[0].X && triangle.c.X < Tops[6].X);
                    bool CheckY = (triangle.a.Y > Tops[0].Y && triangle.a.Y < Tops[6].Y) || (triangle.b.Y > Tops[0].Y && triangle.b.Y < Tops[6].Y) || (triangle.c.Y > Tops[0].Y && triangle.c.Y < Tops[6].Y);
                    bool CheckZ = (triangle.a.Z > Tops[0].Z && triangle.a.Z < Tops[6].Z) || (triangle.b.Z > Tops[0].Z && triangle.b.Z < Tops[6].Z) || (triangle.c.Z > Tops[0].Z && triangle.c.Z < Tops[6].Z);

                    return CheckX && CheckY && CheckZ;
                }

                private bool TriangleHitTheCube(Triangle triangle)
                {
                    bool CheckX = (triangle.a.X > Tops[0].X && triangle.a.X < Tops[6].X) && (triangle.b.X > Tops[0].X && triangle.b.X < Tops[6].X) && (triangle.c.X > Tops[0].X && triangle.c.X < Tops[6].X);
                    bool CheckY = (triangle.a.Y > Tops[0].Y && triangle.a.Y < Tops[6].Y) && (triangle.b.Y > Tops[0].Y && triangle.b.Y < Tops[6].Y) && (triangle.c.Y > Tops[0].Y && triangle.c.Y < Tops[6].Y);
                    bool CheckZ = (triangle.a.Z > Tops[0].Z && triangle.a.Z < Tops[6].Z) && (triangle.b.Z > Tops[0].Z && triangle.b.Z < Tops[6].Z) && (triangle.c.Z > Tops[0].Z && triangle.c.Z < Tops[6].Z);

                    return CheckX && CheckY && CheckZ;
                }

                public void FindTriangle(ref Triangle triangle, ref double t, Vector3 Ray, Vector3 camera)
                {
                    if(TrianglesInNode.Count==0)
                    {
                        if (Childes == null || !Childes.Any())
                        {
                            return;
                        }
                        else
                        {
                            foreach (var tempChild in Childes)
                            {
                                tempChild.FindTriangle(ref triangle, ref t, Ray, camera);
                                if (triangle != null)
                                {
                                    return;
                                }
                            }
                        }
                    }
                    ArrayList temp = new ArrayList(EdgesTriangle);
                    Render.Hit(ref triangle, ref t, temp, Ray, camera);

                    if (triangle == null)
                    {
                        return;
                    }

                    triangle = null;
                    temp = new ArrayList(TrianglesInNode);
                    t = 1.0E10;
                    CheckTriangleInNode(ref triangle, ref t, temp, Ray, camera);
                    if (triangle != null)
                    {
                        return;
                    }

                    if (Childes == null || !Childes.Any())
                    {
                        return;
                    }

                    foreach (var tempChild in Childes)
                    {
                        tempChild.FindTriangle(ref triangle, ref t, Ray, camera);
                        if (triangle != null)
                        {
                            return;
                        }
                    }
                }

                private void CheckTriangleInNode(ref Triangle triangle, ref double t, ArrayList Triangles, Vector3 Ray, Vector3 camera)
                { 
                    Render.Hit(ref triangle, ref t, Triangles, Ray, camera);
                }
            }
        }    
}

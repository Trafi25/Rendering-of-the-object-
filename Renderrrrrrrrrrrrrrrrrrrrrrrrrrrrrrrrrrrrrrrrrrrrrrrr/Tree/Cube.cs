using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Tree
{
    private class Cube
    {

        public double minX;
        public double minY;
        public double minZ;
        public double maxX;
        public double maxY;
        public double maxZ;

        public Cube(double minX, double minY, double minZ, double maxX, double maxY, double maxZ)
        {
            this.minX = minX;
            this.minY = minY;
            this.minZ = minZ;
            this.maxX = maxX;
            this.maxY = maxY;
            this.maxZ = maxZ;
        }

        public bool IsBelow(int depth, double boundary)
        {
            int dimension = depth % 3;
            if (dimension == 0)
            {
                return maxX < boundary;
            }
            else if (dimension == 1)
            {
                return maxY < boundary;
            }
            else
            {
                return maxZ < boundary;
            }
        }

        public bool IsAbove(int depth, double boundary)
        {
            int dimension = depth % 3;
            if (dimension == 0)
            {
                return boundary <= minX;
            }
            else if (dimension == 1)
            {
                return boundary <= minY;
            }
            else
            {
                return boundary <= minZ;
            }
        }

        public bool Contains(Cube cube)
        {
            return minX <= cube.minX && cube.maxX < maxX &&
                minY <= cube.minY && cube.maxY < maxY &&
                minZ <= cube.minZ && cube.maxZ < maxZ;
        }

        public bool Intersects(Cube cube)
        {
            return (Contains(cube.minX, cube.minY, cube.minZ) || Contains(cube.maxX, cube.maxY, cube.maxZ)) ||
                   (cube.Contains(minX, minY, minZ) || cube.Contains(maxX, maxY, maxZ));
        }

        private bool Contains(double cx, double cy, double cz)
        {
            return minX <= cx && cx < maxX &&
                minY <= cy && cy < maxY &&
                minZ <= cz && cz < maxZ;
        }

    }
}
}

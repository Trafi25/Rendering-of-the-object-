using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Scene
{
    class Light
    {
        public Vector3 LightPosition;
        public Vector3 LightDirection;

        public Light(float PosX=0,float PosY=0,float PosZ=0,float DirX=0, float DirY = 0, float DirZ = -1)
        {
            LightPosition = new Vector3(PosX,PosY,PosZ);
            LightDirection = new Vector3(DirX,DirY,DirZ);
        }
    }
}

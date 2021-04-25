using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Structures;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Scene
{
    class Camera:ICameraPositionProvider
    {
        Vector3 Coordinates;
        public Camera(float X=0,float Y=0,float Z=1)
        {
            Coordinates = new Vector3(X,Y,Z);
        }

        public Vector3 GetCameraPosition()
        {
            return Coordinates;
        }
    }
}

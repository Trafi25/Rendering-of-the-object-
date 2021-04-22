using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Readers;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.RenderEngine;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Scene;
using System;

namespace Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr
{
    class Program
    {
        static void Main(string[] args)
        {
            Render render = new Render(new ObjReader(),new Camera(Y:-100,Z:60),new Light(PosX:-250.0f,PosZ: 200.0f,DirX:180f,DirY:30f,DirZ:199.9f));
            render.StartRender(@"c:\users\user\desktop\комп графика\testrender\cow.obj", @"c:\users\user\desktop\комп графика\final.png",800);
        }
    }
}

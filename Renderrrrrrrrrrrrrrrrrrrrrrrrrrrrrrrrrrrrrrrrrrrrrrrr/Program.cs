
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Exeptions;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Readers;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.RenderEngine;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Scene;
using Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Writer;
using System;

namespace Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = string.Empty;

            string output = string.Empty;
            string[] input;
            try
            {
                foreach (var a in args)
                {
                    input = a.Split('=');
                    switch (input[0])
                    {
                        case "--source":
                            {
                                source = input[1];
                                string[] temp = source.Split('.');
                                if (temp[1] != "obj")
                                {
                                    throw new FormatSupportedException("Формат ввода не поддерживется", temp[1]);
                                }
                            }
                            break;

                        case "--output":
                            {
                                output = input[1];
                            }
                            break;
                        default:
                            throw new UnknowCommandException("Неизвестная команда", input[0]);
                    }

                }
            }
            catch (UnknowCommandException ex)
            {
                Console.WriteLine(ex.ErrorDetails);
            }
            catch (FormatSupportedException ex)
            {
                Console.WriteLine(ex.ErrorDetails);
            }
                      
            Render render = new Render(new ObjReader(), new Camera(Y: -100, Z: 60), new Light(PosX: -250.0f, PosZ: 200.0f, DirX: 180f, DirY: 30f, DirZ: 199.9f),new Ppm_writer());
            render.StartRender(source, output, 800);

        }
    }
}
 


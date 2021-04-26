using System;
using System.Collections.Generic;
using System.Text;
using Conventor.ImageConcept;

namespace Conventor.Interfaces
{
    interface IImageWriter
    {
        public void Write(string path, Image image);
    }
}

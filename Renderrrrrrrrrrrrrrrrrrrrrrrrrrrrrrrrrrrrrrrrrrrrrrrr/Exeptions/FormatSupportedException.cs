using System;
using System.Collections.Generic;
using System.Text;

namespace Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Exeptions
{
    class FormatSupportedException:Exception
    {
        public string ErrorDetails; 
        public FormatSupportedException(string message,string format):base(message)
        {
            ErrorDetails = $"{message} : {format}";
        }
    }
}

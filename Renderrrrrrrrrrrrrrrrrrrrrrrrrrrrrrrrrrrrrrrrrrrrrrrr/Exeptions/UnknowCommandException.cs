using System;
using System.Collections.Generic;
using System.Text;

namespace Renderrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.Exeptions
{ 
    class UnknowCommandException:Exception
    {
        public string ErrorDetails;
        public UnknowCommandException(string message,string value):base(message)
        {
            ErrorDetails = $"{message} : {value}";
        }
    }
}

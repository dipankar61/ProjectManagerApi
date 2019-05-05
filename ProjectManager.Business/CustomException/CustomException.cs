using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Business
{
    public class CustomException : Exception
    {
        private string exMsg;
        public string ExceptionMsg { get => exMsg; set => exMsg = value; }

      
    }
}

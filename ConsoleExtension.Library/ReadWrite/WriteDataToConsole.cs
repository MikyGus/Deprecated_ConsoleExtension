using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExtension.Library.ReadWrite
{
    public class WriteDataToConsole : IWriteData
    {
        public void Write(string data)
        {
            Console.Write(data);
        }

        public void WriteLine(string data)
        {
            Console.WriteLine(data);
        }
    }
}

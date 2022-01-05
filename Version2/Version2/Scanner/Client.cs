using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version2.Scanner
{
    internal class Client
    {
        // Attach to client and open all access handle (read only?)
        // Read generic type
        // Read Bytes -> 1, 2, 4, 8, 16, 32, 64?

        internal static void Attach(int ProcessID) { }
        internal static T Read<T>(IntPtr ptr) { return default; }
        internal static byte[] ReadBytes(IntPtr ptr) { return new List<byte>().ToArray(); }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version2.Scanner
{
    internal enum ReadType : int
    {
        Null = -1,
        Byte,
        Word,
        DWord,
        QWord
    }
}

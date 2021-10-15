using System;
using System.Collections.Generic;
using System.Linq;
using Reloaded.Memory.Sigscan;

namespace WowScanner
{
    internal class Scan
    {
        private Scanner Scans;
        internal Scan() => Scans = new Scanner(WoW.Proc, WoW.Proc.MainModule);

        internal IntPtr FindOffset(Offset Input)
        {
            try
            {
                var Match = Scans.CompiledFindPattern(Input.Pattern).Offset;
                // Console.WriteLine($"0x{Match:X}");
                if (Match == 0x0) return IntPtr.Zero;

                var ValueOffset = Match + Input.Offset1;
                // Console.WriteLine($"0x{ValueOffset:X}");

                var Value = WoW.Read<int>(WoW.Base + ValueOffset);
                // Console.WriteLine($"0x{Value:X}");

                var Next = Match + Input.Offset2;
                // Console.WriteLine($"0x{Value:X}");

                var nValAddress = WoW.Base + Next;
                // Console.WriteLine($"0x{nValAddress:X}");

                var nValue = nValAddress + Value;
                // Console.WriteLine($"0x{nValue:X}");

                var Found = nValue.ToInt64() - WoW.Base.ToInt64() - 1;
                // Console.WriteLine($"0x{Found:X}");


                if (Found != 0 && Input.Levels.Count > 0)
                    Found = ScanNext(Input, Found).ToInt64();
                // Console.WriteLine($"0x{Found:X}");

                if (Found != 0 && Input.AddOffset != 0)
                    Found += Input.AddOffset;
                // Console.WriteLine($"0x{Found:X}");

                return new IntPtr(Found);
            }
            catch (Exception)
            {
                return IntPtr.Zero;
            }
        }
        internal IntPtr ScanNext(Offset o, long l)
        {
            try
            {
                var Base = new IntPtr(l);
                return Base == IntPtr.Zero 
                    ? IntPtr.Zero 
                    : o.Levels.Aggregate(Base, 
                        (current, lvl) => ScanLevel(current.ToInt64(), lvl));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return IntPtr.Zero;
            }
        }
        private IntPtr ScanLevel(long l1, Level l2)
        {
            try
            {
                var ValueOffset = l1 + l2.Offset1;
                var Value = WoW.Read<int>(WoW.Base + (int)ValueOffset);

                var Next = l1 + l2.Offset2;
                var nValAddress = WoW.Base.ToInt64() + Next;
                var nValue = nValAddress + Value;
                var Found = nValue - WoW.Base.ToInt64() - 1;

                return Found != 0? new IntPtr(Found) : IntPtr.Zero;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return IntPtr.Zero;
            }
        }
    }

    internal class Offset
    {
        public string Name { get; set; }
        public string Pattern { get; set; }

        public int Offset1 { get; set; }
        public int Offset2 { get; set; }
        public int AddOffset { get; set; }

        internal List<Level> Levels = new List<Level>();
    }

    internal class Level
    {
        public int Offset1 { get; set; }
        public int Offset2 { get; set; }
    }
}
using Reloaded.Memory.Sigscan;

namespace Wow_Scanner
{
    internal class Scan
    {
        private Scanner Scans;
        internal Scan() => Scans = new Scanner(WoW.Proc, WoW.Proc.MainModule);
        internal IntPtr FindOffset(OffsetBase Input)
        {
            try
            {
                var Match = Scans.CompiledFindPattern(Input.Pattern).Offset;
                if (Match == 0x0) return IntPtr.Zero;

                var ValueOffset = Match + Input.StartIndex;
                var Value = WoW.Read<int>(WoW.Base + ValueOffset);
                
                var Next = Match + Input.EndIndex;
                var nValAddress = WoW.Base + Next;
                var nValue = nValAddress + Value;

                var Found = nValue.ToInt64() - WoW.Base.ToInt64() - 1;
                if (Found != 0 && Input.Levels.Count > 0)
                    Found = ScanNext(Input, Found).ToInt64();

                if (Found != 0 && Input.AddOffset != 0)
                    Found += Input.AddOffset;

                return new IntPtr(Found);
            }
            catch (Exception)
            {
                return IntPtr.Zero;
            }
        }
        internal IntPtr GetField(OffsetBase Input, int index)
        {
            
            var Match = Scans.CompiledFindPattern(Input.Pattern).Offset;
            if (Match == 0x0) return IntPtr.Zero;
            if (Input.Name == "Auto Loot Toggle") Console.WriteLine($"1, 0x{Match:X}");

            var ValueOffset = Match + Input.Fields[index].Offset1;
            var ValueReal = WoW.Read<int>(WoW.Base + ValueOffset);
            return new IntPtr(ValueReal);
        }
        internal IntPtr ScanNext(OffsetBase o, long l)
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
        private IntPtr ScanLevel(long l1, OffsetLevel l2)
        {
            try
            {
                var ValueOffset = l1 + l2.Offset1;
                var Value = WoW.Read<int>(WoW.Base + (int)ValueOffset);

                var Next = l1 + l2.Offset2;
                var nValAddress = WoW.Base.ToInt64() + Next;
                var nValue = nValAddress + Value;
                var Found = nValue - WoW.Base.ToInt64() - 1;

                return Found != 0 ? new IntPtr(Found) : IntPtr.Zero;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return IntPtr.Zero;
            }
        }
    }
}
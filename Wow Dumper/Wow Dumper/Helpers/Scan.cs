using Reloaded.Memory.Sigscan;
using Wow_Dumper.Patterns;

namespace Wow_Dumper.Helpers
{
    internal class Scan
    {
        private static Scanner? Scans;
        private static string Time => $"[{DateTime.Now.ToShortTimeString()}]";

        internal static bool GetOffset(OffsetBase oBase, out IntPtr offset)
        {
            try
            {
                Scans ??= new Scanner(Client.Proc, Client.Proc?.MainModule);

                if (null == Scans)
                    throw new Exception("Could not load scanner lib.");

                var Match = Scans.CompiledFindPattern(oBase.Pattern).Offset;
                if (Match == 0x0)
                    throw new Exception($"Could not find {oBase.Name} pointer.");
                
                var OffsetValue = Client.Read<int>(Client.Base + (Match + oBase.Position));
                var nValAddress = Client.Base + (Match + (oBase.Position + 5));
                var nValue = nValAddress + OffsetValue;
                var bytes = Client.ReadBytes(nValAddress, 8);
                var s = bytes.Aggregate(string.Empty, (Current, b) => Current + $"0x{b:X} ");

                var Found = nValue.ToInt64() - Client.Base.ToInt64() - (oBase.MinusOne ? 1 : 0);
                if (Found != 0 && oBase.Additional != 0)
                    Found += oBase.Additional;

                offset = new IntPtr(Found);
                return offset != IntPtr.Zero;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{Time} {e.Message}");
                offset = IntPtr.Zero;
                return false;
            }
        }
    }
}

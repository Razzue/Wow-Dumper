using System.Globalization;
using Reloaded.Memory.Sigscan;
using Version2.Manager;
using Version2.Writer;

namespace Version2.Helpers
{
    internal class Scan
    {
        private Scanner Scans;
        internal Scan() => Scans = new Scanner(Client.Proc, Client.Proc?.MainModule);

        internal bool TryGetOffsets(Container C)
        {
            try
            {
                if (null == C.Classes || C.Classes.Count <= 0)
                    throw new Exception("No offset classes have been loaded yet.");

                C.Loaded = new Dictionary<string, Dictionary<string, IntPtr>>();
                foreach (var _class in C.Classes)
                {
                    if (string.IsNullOrEmpty(_class.Name) || C.Loaded.ContainsKey(_class.Name))
                        continue;

                    var Temp = new Dictionary<string, IntPtr>();
                    foreach (var _offset in _class.Offsets)
                    {
                        if (TryGetOffset(_offset, out var v1))
                            if (!string.IsNullOrEmpty(_offset.Name) && !Temp.ContainsKey(_offset.Name))
                                Temp.Add(_offset.Name, v1);

                        if (null == _offset.Fields || _offset.Fields.Length <= 0) continue;
                        if (TryGetFields(_offset, out var v2))
                            foreach (var pair in v2.Where(pair => !Temp.ContainsKey(pair.Key)))
                                Temp.Add(pair.Key, pair.Value);
                    }

                    if (Temp.Count > 0)
                        C.Loaded.Add(_class.Name, Temp);
                }

                return null != C.Loaded && C.Loaded.Count == C.Classes.Count;
            }
            catch (Exception e)
            {
                Write.Error(e.Message);
                return false;
            }
        }
        private bool TryGetFields(_Offset o, out Dictionary<string, IntPtr> offsets)
        {
            try
            {
                offsets = new Dictionary<string, IntPtr>();
                var Match = Scans.CompiledFindPattern(o.Pattern).Offset;
                if (Match == 0x0) return false;

                foreach (var f in o.Fields)
                {
                    var ValueOffset = Match + f.Position;
                    var b = Client.ReadBytes(Client.Base + ValueOffset, (int)f.Type);

                    var s = string.Empty;
                    for (var i = b.Length - 1; i >= 0; i--)
                        s += b[i].ToString("X");

                    if (!int.TryParse(s, NumberStyles.HexNumber, null, out var num))
                        continue;

                    if (!offsets.ContainsKey(f.Name))
                        offsets.Add(f.Name, new IntPtr(num));
                }

                return offsets is { Count: > 0 };
            }
            catch (Exception e)
            {
                Write.Error(e.Message);
                offsets = new Dictionary<string, IntPtr>();
                return false;
            }
        }
        private bool TryGetOffset(_Offset o, out IntPtr offset)
        {
            try
            {
                offset = IntPtr.Zero;
                var Match = Scans.CompiledFindPattern(o.Pattern).Offset;
                if (Match == 0x0) return false;

                if (o.IsFunction)
                    offset = new IntPtr(Match);
                if (offset != IntPtr.Zero) return true;

                var Value = Client.Read<int>(Client.Base + (Match + o.Position));
                var nValAddress = Client.Base + (Match + (o.Position + 5));
                var nValue = nValAddress + Value;

                var Found = nValue.ToInt64() - Client.Base.ToInt64() - (o.MinusOne ? 1 : 0);
                if (Found != 0 && (null != o.Levels && o.Levels.Length > 0))
                    foreach (var l in o.Levels)
                    {
                        Found = TryGetLevel(new IntPtr(Found), l).ToInt64();
                        if (Found == 0)
                            throw new Exception("Level crawl broke pointer.");
                    }

                if (Found != 0 && o.Modifier != 0)
                    Found += o.Modifier;

                offset = new IntPtr(Found); 
                return IntPtr.Zero != offset;
            }
            catch (Exception e)
            {
                Write.Error(e.Message);
                offset = IntPtr.Zero;
                return false;
            }
        }
        private IntPtr TryGetLevel(IntPtr offset, _Level l)
        {
            try
            {
                var Value = Client.Read<int>(Client.Base + (offset + l.Position).ToInt32());
                var nValAddress = Client.Base.ToInt64() + (offset + (l.Position + 5)).ToInt64();
                var nValue = nValAddress + Value;
                var Found = nValue - Client.Base.ToInt64() - (l.MinusOne? 1 : 0);

                return Found != 0 ? new IntPtr(Found) : IntPtr.Zero;
            }
            catch (Exception e)
            {
                Write.Error(e.Message);
                return IntPtr.Zero;
            }
        }
    }
}
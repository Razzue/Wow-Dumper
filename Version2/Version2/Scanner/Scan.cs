using Version2.Manager;

namespace Version2.Scanner
{
    internal class Scan
    {
        // Scan _Offset and save value
        // if offset has levels, read one at a time. Save if enabled.
        // if level has fields, read one at a time. Saves if above does.
        // if offset has fields, read one at a time and save value.

        private object ColLock = new object();
        private Dictionary<string, IntPtr>? Collection;
        internal Scan() => Collection = new Dictionary<string, IntPtr>();

        internal void ScanOffset(_Offset offset) { }
        private void ScanLevel(IntPtr Base) { }
        private void ScanField(IntPtr Base) { }
    }
}
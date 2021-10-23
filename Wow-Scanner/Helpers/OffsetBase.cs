namespace Wow_Scanner
{
    internal class OffsetBase
    {
        internal string Name { get; set; }
        internal string Pattern { get; set; }

        internal int StartIndex { get; set; }
        internal int EndIndex { get; set; }
        internal int AddOffset { get; set; }

        internal List<OffsetLevel> Levels = new List<OffsetLevel>();
        internal List<OffsetField> Fields = new List<OffsetField>();
    }

    internal class OffsetLevel
    {
        public int Offset1 { get; set; }
        public int Offset2 { get; set; }
    }

    internal class OffsetField
    {
        public string Name { get; set; }
        public int Offset1 { get; set; }
        public int Offset2 { get; set; }
    }
}
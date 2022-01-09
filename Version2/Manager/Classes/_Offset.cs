namespace Version2.Manager
{
    internal class _Offset
    {
        public string? Name { get; set; } = null;
        public string? Pattern { get; set; } = null;
        public string? Comment { get; set; } = null;
        public int Position { get; set; } = 0;
        public int Modifier { get; set; } = 0;
        public bool MinusOne { get; set; } = true;

        public _Level[]? Levels { get; set; } = null;
        public _Field[]? Fields { get; set; } = null;
    }
}
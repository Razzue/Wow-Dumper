namespace Version2.Manager
{
    internal class _Level
    {
        public string? Name { get; set; } = null;
        public string? Comment { get; set; } = null;
        public int Position { get; set; } = 0;
        public bool Keep { get; set; } = false;

        public _Field[]? Fields { get; set; } = null;
    }
}
namespace Wow_Dumper.Patterns
{
    public class OffsetBase
    {
        public string? Name { get; set; } = null;
        public string? Pattern { get; set; } = null;
        public int Position { get; set; } = 0;
        public int Additional { get; set; } = 0;
        public bool MinusOne { get; set; } = true;

        public LevelBase[]? Levels { get; set; } = null;
        public FieldBase[]? Fields { get; set; } = null;
    }
}
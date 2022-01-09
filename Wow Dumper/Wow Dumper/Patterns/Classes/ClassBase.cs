namespace Wow_Dumper.Patterns
{

    public class ClassBase
    {
        public string? Name { get; set; } = null;
        public string[]? Comments { get; set; } = null;
        public OffsetBase[]? Offsets { get; set; } = null;
    }
}
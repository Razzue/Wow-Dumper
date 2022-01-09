namespace Wow_Dumper.Patterns
{
    public class FieldBase
    {
        public FieldType Type { get; set; } = FieldType.Null;
        public string? Name { get; set; } = null;
        public int Position { get; set; } = 0;
    }
}
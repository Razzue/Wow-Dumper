using Wow_Dumper.Patterns;

namespace Wow_Dumper
{
    internal class Example
    {
        public static bool Load(Manager m)
        {
            m.Patterns = new List<ClassBase>
            {
                new ClassBase
                {
                    Name = "Functions",
                    Offsets = new[]
                    {
                        new OffsetBase
                        {
                            Name = "CGUnit_C__GetPowerSlot",
                            Pattern = "E8 ?? ?? ?? ?? 83 F8 ?? 74 ?? 48 98 8B B4 87 ?? ?? ?? ??",
                            Position = 1,
                        },
                        new OffsetBase
                        {
                            Name = "CGWorldFrame__GetActiveCamera",
                            Pattern = "E8 ?? ?? ?? ?? F3 0F 10 54 24 ?? 45 33 C9 F3 0F 10 4C 24 ?? 48 8B C8",
                            Position = 1,
                        },
                    },
                },
                new ClassBase
                {
                    Name = "Messages",
                    Offsets = new[]
                    {
                        new OffsetBase
                        {
                            Name = "CGPlayer_C_IsAfk",
                            Pattern = "83 3D ?? ?? ?? ?? ?? 75 ?? 41 80 3F ??",
                            Position = 2,
                            MinusOne = false
                        },new OffsetBase
                        {
                            Name = "CGPlayer_C_IsDND",
                            Pattern = "89 15 ?? ?? ?? ?? C7 05 ?? ?? ?? ?? ?? ?? ?? ?? E8 ?? ?? ?? ??",
                            Position = 2
                        },
                    },
                },
                new ClassBase
                {
                    Name = "Camera",
                    Offsets = new[]
                    {
                        new OffsetBase
                        {
                            Name = "Function",
                            Pattern = "E8 ?? ?? ?? ?? F3 0F 10 54 24 ?? 45 33 C9 F3 0F 10 4C 24 ?? 48 8B C8",
                            Position = 1,
                        },
                        new OffsetBase
                        {
                            Name = "Base",
                            Pattern = "48 8B 05 ?? ?? ?? ?? 48 85 C0 74 ?? 48 8B 80 ?? ?? ?? ?? C3 C3 CB",
                            Position = 3,
                            Fields = new []
                            {
                                new FieldBase
                                {
                                    Name = "Offset",
                                    Position = 15,
                                    Type = FieldType.DWord
                                }
                            }
                        },
                    },
                },
                
            };
            return null != m.Patterns && m.Patterns.Count > 0;
        }
    }
}
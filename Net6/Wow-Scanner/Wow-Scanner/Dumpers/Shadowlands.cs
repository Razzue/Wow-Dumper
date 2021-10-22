using System.Text.RegularExpressions;

namespace Wow_Scanner.Dumpers
{
    internal class Shadowlands
    {
        private static List<OffsetBase> Patterns = new List<OffsetBase>
        {
            new OffsetBase
            {
                Name = "Player Name",
                Pattern = "E8 ?? ?? ?? ?? 48 8D 4C 24 ?? 48 8B D8 E8 ?? ?? ?? ?? 4C 89 74 24",
                StartIndex = 1,
                EndIndex = 6,
                Levels = new List<OffsetLevel>
                {
                    new OffsetLevel{ Offset1 = 5, Offset2 = 10 }
                }
            },
            new OffsetBase
            {
                Name = "Player GUID",
                Pattern = "48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 83 BC 24 ?? ?? ?? ?? ?? 7C ?? 48 8B 8C 24 ?? ?? ?? ?? 48 8D 15 ?? ?? ?? ?? 45 33 C9 45 8D 41 ?? E8 ?? ?? ?? ?? 48 81 C4",
                StartIndex = 3,
                EndIndex = 8
            },
            new OffsetBase
            {
                Name = "Pet GUID",
                Pattern = "48 8B 05 ?? ?? ?? ?? 33 DB 45 8B E1",
                StartIndex = 3,
                EndIndex = 8
            },
            new OffsetBase
            {
                Name = "Mouseover GUID",
                Pattern = "0F 11 05 ?? ?? ?? ?? E8 ?? ?? ?? ?? 0F BE D0 4C 8D 05 ?? ?? ?? ?? 41 B9 ?? ?? ?? ?? 48 8B CB",
                StartIndex = 3,
                EndIndex = 8
            },
            new OffsetBase
            {
                Name = "GUIDS",
                Pattern = "48 8B 0D ?? ?? ?? ?? 48 8B 01 FF 50 ?? 48 8B 08 48 39 4B ?? 75 ?? 48 8B 40 ?? 48 39 43 ?? 75 ?? 48 8B 0D ?? ?? ?? ??",
                StartIndex = 3,
                EndIndex = 8,
                AddOffset = 0x50
            },new OffsetBase
            {
                Name = "Bag GUIDS",
                Pattern = "48 8D 3D ?? ?? ?? ?? 90 48 8B 07",
                StartIndex = 3,
                EndIndex = 8
            },
            new OffsetBase
            {
                Name = "Zone ID",
                Pattern = "8B 15 ?? ?? ?? ?? 4C 8D 4C 24 ?? 45 33 C0 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 75 ?? B8 ?? ?? ?? ??",
                StartIndex = 2,
                EndIndex = 7
            },
            new OffsetBase
            {
                Name = "Game Status",
                Pattern = "F6 05 ?? ?? ?? ?? ?? 75 ?? 48 8D 05 ?? ?? ?? ??",
                StartIndex = 3,
                EndIndex = 8
            },
            new OffsetBase
            {
                Name = "Corpse Position",
                Pattern = "8B 05 ?? ?? ?? ?? 89 06 8B 05 ?? ?? ?? ?? 89 07 B0 ??",
                StartIndex = 2,
                EndIndex = 7,
                AddOffset = 0x40
            },
            new OffsetBase
            {
                Name = "Loot Window",
                Pattern = "88 05 ?? ?? ?? ?? 85 DB",
                StartIndex = 2,
                EndIndex = 7
            },
            new OffsetBase
            {
                Name = "Last Message",
                Pattern = "48 8D 0D ?? ?? ?? ?? 41 B8 ?? ?? ?? ?? 48 8D 95 ?? ?? ?? ?? 0F 1F 80 ?? ?? ?? ??",
                StartIndex = 3,
                EndIndex = 8
            },
            new OffsetBase
            {
                Name = "Battleground Finished",
                Pattern = "83 3D ?? ?? ?? ?? ?? 0F 84 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CF",
                StartIndex = 2,
                EndIndex = 7,
                AddOffset = 1
            },
            new OffsetBase
            {
                Name = "Battleground Winner",
                Pattern = "0F B6 05 ?? ?? ?? ?? 41 8B F9 FE C8 49 8B D8 8B F2 48 8B E9 3C ?? 77 ?? 48 8B CB E8 ?? ?? ?? ?? 3D ?? ?? ?? ?? 74 ?? 0F B6 84 24 ?? ?? ?? ?? 44 8B CF C6 44 24 ?? ??",
                StartIndex = 3,
                EndIndex = 8
            },
            new OffsetBase
            {
                Name = "Battleground Info",
                Pattern = "48 8B 0D ?? ?? ?? ?? 33 C0 F6 C1 ?? 75 ?? 8B D0 48 85 C9 75 ?? BA ?? ?? ?? ?? 85 D2 8B 15 ?? ?? ?? ?? 48 0F 44 C1 66 0F 1F 44 00",
                StartIndex = 3,
                EndIndex = 8
            },
            new OffsetBase
            {
                Name = "Keybind Base",
                Pattern = "48 8B 05 ?? ?? ?? ?? 8B FA 48 8B F1",
                StartIndex = 3,
                EndIndex = 8
            },
            new OffsetBase
            {
                Name = "Add On Base",
                Pattern = "8B 15 ?? ?? ?? ?? 4C 8D 0D ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? 41 B8 ?? ?? ?? ?? 4C 8D 9C 24 ?? ?? ?? ??",
                StartIndex = 2,
                EndIndex = 7
            },
            new OffsetBase
            {
                Name = "Spellbook Base",
                Pattern = "44 8B 0D ?? ?? ?? ?? 33 D2 45 85 C9 74 ?? 4C 8B 15 ?? ?? ?? ?? 49 8B 0C D2 44 3B 41 ??",
                StartIndex = 3,
                EndIndex = 8
            },
            new OffsetBase
            {
                Name = "Spellbook Count",
                Pattern = "44 8B 0D ?? ?? ?? ?? 33 D2 45 85 C9 74 ?? 4C 8B 15 ?? ?? ?? ?? 49 8B 0C D2 44 3B 41 ??",
                StartIndex = 3,
                EndIndex = 8,
                AddOffset = -0x8
            },
            new OffsetBase
            {
                Name = "Pet Spellbook Base",
                Pattern = "4C 8B 0D ?? ?? ?? ?? 90 49 8B 0C D1 8B 41 ??",
                StartIndex = 3,
                EndIndex = 8
            },
            new OffsetBase
            {
                Name = "Pet Spellbook Count",
                Pattern = "4C 8B 0D ?? ?? ?? ?? 90 49 8B 0C D1 8B 41 ??",
                StartIndex = 3,
                EndIndex = 8,
                AddOffset = -0x8
            }, 
            new OffsetBase
            {
                Name = "Cooldown Base",
                Pattern = "48 8D 15 ?? ?? ?? ?? 48 1B C9 81 E1 ?? ?? ?? ?? 48 03 CA 8B 53 ??",
                StartIndex = 3,
                EndIndex = 8,
            },
            new OffsetBase
            {
                Name = "Camera Base",
                Pattern = "48 8B 05 ?? ?? ?? ?? 48 8B 88 ?? ?? ?? ?? 48 8B 43 ?? 48 39 81 ?? ?? ?? ??",
                StartIndex = 3,
                EndIndex = 8,
                Fields = new List<OffsetField>
                {
                    new OffsetField()
                    {
                        Name = "Camera OffsetBase",
                        Offset1 = 10,
                        Offset2 = 15
                    }
                }
            },
            new OffsetBase
            {
                Name = "Object Manager",
                Pattern = "48 8B 1D ?? ?? ?? ?? 48 85 DB 74 ?? 80 3D ?? ?? ?? ?? ?? 74 ?? 48 8D 0D ?? ?? ?? ??",
                StartIndex = 3,
                EndIndex = 8,
            },
            new OffsetBase
            {
                Name = "Player Name Cache",
                Pattern = "48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 4C 8B D0 48 85 C0 74 ??",
                StartIndex = 3,
                EndIndex = 8,
            },
        };
        internal static Dictionary<string, IntPtr> Offsets = new Dictionary<string, IntPtr>();

        internal static bool LoadOffsets(Scan Scanner)
        {
            try
            {
                Offsets.Clear();
                Regex re = new Regex(@"[!""#$%&'()\*\+,\./:;<=>\?@\[\\\]^`{\|}~ ]");

                foreach (var Pattern in Patterns)
                {
                    var Pointer = Scanner.FindOffset(Pattern);
                    var ClassName = re.Replace(Pattern.Name, string.Empty);
                    if (Pointer != IntPtr.Zero && !string.IsNullOrEmpty(ClassName))
                        Offsets.Add(ClassName, Pointer);

                    if (Pattern.Fields.Count > 0)
                    {
                        for (var i = 0; i < Pattern.Fields.Count; i++)
                        {
                            var f = Scanner.GetField(Pattern, i);
                            var FieldName = re.Replace(Pattern.Fields[i].Name, string.Empty);
                            if (Pointer != IntPtr.Zero && !string.IsNullOrEmpty(ClassName))
                                Offsets.Add(FieldName, f);
                        }
                    }
                }

                return Offsets.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
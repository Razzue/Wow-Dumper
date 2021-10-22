using System;
using System.Collections.Generic;

namespace WowScanner
{
    class Program
    {
        private static Scan Scanner;

        private static List<Offset> Offsets = new List<Offset>
        {
            new Offset
            {
                Name = "TBC Player Name",
                Pattern = "E8 ?? ?? ?? ?? 48 8D 4C 24 ?? 48 8B D8 E8 ?? ?? ?? ?? 4C 89 74 24",
                Offset1 = 1,
                Offset2 = 6,
                Levels = new List<Level>
                {
                    new Level{ Offset1 = 5, Offset2 = 10 }
                }
            },
            new Offset
            {
                Name = "RET Player Name",
                Pattern = "E8 ?? ?? ?? ?? 48 8D 4C 24 ?? 48 8B D8 E8 ?? ?? ?? ?? 4C 89 74 24",
                Offset1 = 1,
                Offset2 = 6,
                Levels = new List<Level>
                {
                    new Level{ Offset1 = 5, Offset2 = 10 }
                }
            },

            new Offset
            {
                Name = "TBC Player GUID",
                Pattern = "48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 83 BC 24 ?? ?? ?? ?? ?? 7C ?? 48 8B 8C 24 ?? ?? ?? ?? 48 8D 15 ?? ?? ?? ?? 45 33 C9 45 8D 41 ?? E8 ?? ?? ?? ?? 48 81 C4",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "RET Player GUID",
                Pattern = "48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 83 BC 24 ?? ?? ?? ?? ?? 7C ?? 48 8B 8C 24 ?? ?? ?? ?? 48 8D 15 ?? ?? ?? ?? 45 33 C9 45 8D 41 ?? E8 ?? ?? ?? ?? 48 81 C4",
                Offset1 = 3,
                Offset2 = 8
            },

            new Offset
            {
                Name = "TBC Pet GUID",
                Pattern = "48 8B 05 ?? ?? ?? ?? 33 DB 45 8B E1",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "RET Pet GUID",
                Pattern = "48 8B 05 ?? ?? ?? ?? 33 DB 45 8B E1",
                Offset1 = 3,
                Offset2 = 8
            },
            
            new Offset
            {
                Name = "TBC Mouseover GUID",
                Pattern = "48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 ?? 4C 8B C7 48 8D 0D ?? ?? ?? ??",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "RET Mouseover GUID",
                Pattern = "0F 11 05 ?? ?? ?? ?? E8 ?? ?? ?? ?? 0F BE D0 4C 8D 05 ?? ?? ?? ?? 41 B9 ?? ?? ?? ?? 48 8B CB",
                Offset1 = 3,
                Offset2 = 8
            },

            new Offset
            {
                Name = "Target GUIDS",
                Pattern = "48 39 05 ?? ?? ?? ?? 48 8B F9",
                Offset1 = 3,
                Offset2 = 8,
            },
            new Offset
            {
                Name = "Target GUIDS",
                Pattern = "48 8B 0D ?? ?? ?? ?? 48 8B 01 FF 50 ?? 48 8B 08 48 39 4B ?? 75 ?? 48 8B 40 ?? 48 39 43 ?? 75 ?? 48 8B 0D ?? ?? ?? ??",
                Offset1 = 3,
                Offset2 = 8,
                AddOffset = 0x50
            },

            new Offset
            {
                Name = "TBC Bag GUIDS",
                Pattern = "48 8D 0D ?? ?? ?? ?? 48 03 C0 0F 10 44 C1 ?? 0F 11 44 24 ?? EB",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "RET Bag GUIDS",
                Pattern = "48 8D 3D ?? ?? ?? ?? 90 48 8B 07",
                Offset1 = 3,
                Offset2 = 8
            },

            new Offset
            {
                Name = "TBC Zone ID",
                Pattern = "8B 15 ?? ?? ?? ?? 4C 8D 4C 24 ?? 45 33 C0 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 75 ?? B8 ?? ?? ?? ??",
                Offset1 = 2,
                Offset2 = 7
            },
            new Offset
            {
                Name = "RET Zone ID",
                Pattern = "8B 15 ?? ?? ?? ?? 4C 8D 4C 24 ?? 45 33 C0 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 75 ?? B8 ?? ?? ?? ??",
                Offset1 = 2,
                Offset2 = 7
            },

            new Offset
            {
                Name = "TBC Game Status",
                Pattern = "0F B6 15 ?? ?? ?? ?? C1 EA ?? 83 E2 ?? E8 ?? ?? ?? ?? B8 ?? ?? ?? ?? 48 83 C4 ?? C3 40 53",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "RET Game Status",
                Pattern = "F6 05 ?? ?? ?? ?? ?? 75 ?? 48 8D 05 ?? ?? ?? ??",
                Offset1 = 3,
                Offset2 = 8
            },

            new Offset
            {
                Name = "TBC Corpse Position",
                Pattern = "8B 05 ?? ?? ?? ?? 89 06 8B 05 ?? ?? ?? ?? 89 07 B0 ??",
                Offset1 = 2,
                Offset2 = 7,
                AddOffset = 0x40
            },
            new Offset
            {
                Name = "RET Corpse Position",
                Pattern = "8B 05 ?? ?? ?? ?? 89 06 8B 05 ?? ?? ?? ?? 89 07 B0 ??",
                Offset1 = 2,
                Offset2 = 7,
                AddOffset = 0x40
            },

            new Offset
            {
                Name = "TBC Loot Window",
                Pattern = "88 05 ?? ?? ?? ?? 85 DB",
                Offset1 = 2,
                Offset2 = 7
            },
            new Offset
            {
                Name = "RET Loot Window",
                Pattern = "88 05 ?? ?? ?? ?? 85 DB",
                Offset1 = 2,
                Offset2 = 7
            },

            new Offset
            {
                Name = "TBC Last Message",
                Pattern = "48 8D 0D ?? ?? ?? ?? 41 B8 ?? ?? ?? ?? 48 8D 95 ?? ?? ?? ?? 0F 1F 40 ??",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "RET Last Message",
                Pattern = "48 8D 0D ?? ?? ?? ?? 41 B8 ?? ?? ?? ?? 48 8D 95 ?? ?? ?? ?? 0F 1F 80 ?? ?? ?? ??",
                Offset1 = 3,
                Offset2 = 8
            },

            new Offset
            {
                Name = "TBC Battleground Finished",
                Pattern = "83 3D ?? ?? ?? ?? ?? 0F 84 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CF",
                Offset1 = 2,
                Offset2 = 7,
                AddOffset = 1
            },
            new Offset
            {
                Name = "RET Battleground Finished",
                Pattern = "83 3D ?? ?? ?? ?? ?? 0F 84 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CF",
                Offset1 = 2,
                Offset2 = 7,
                AddOffset = 1
            },

            new Offset
            {
                Name = "TBC Battleground Winner",
                Pattern = "89 05 ?? ?? ?? ?? 89 1D ?? ?? ?? ?? 8B FB",
                Offset1 = 2,
                Offset2 = 7
            },
            new Offset
            {
                Name = "RET Battleground Winner",
                Pattern = "0F B6 05 ?? ?? ?? ?? 41 8B F9 FE C8 49 8B D8 8B F2 48 8B E9 3C ?? 77 ?? 48 8B CB E8 ?? ?? ?? ?? 3D ?? ?? ?? ?? 74 ?? 0F B6 84 24 ?? ?? ?? ?? 44 8B CF C6 44 24 ?? ??",
                Offset1 = 3,
                Offset2 = 8
            },

            new Offset
            {
                Name = "TBC Battleground Info",
                Pattern = "48 8B 0D ?? ?? ?? ?? 33 C0 F6 C1 ?? 75 ?? 8B D0 48 85 C9 75 ?? BA ?? ?? ?? ?? 85 D2 8B 15 ?? ?? ?? ?? 48 0F 44 C1 66 0F 1F 44 00",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "RET Battleground Info",
                Pattern = "48 8B 0D ?? ?? ?? ?? 33 C0 F6 C1 ?? 75 ?? 8B D0 48 85 C9 75 ?? BA ?? ?? ?? ?? 85 D2 8B 15 ?? ?? ?? ?? 48 0F 44 C1 66 0F 1F 44 00",
                Offset1 = 3,
                Offset2 = 8
            },

            new Offset
            {
                Name = "TBC Keybind Base",
                Pattern = "48 8B 05 ?? ?? ?? ?? 8B FA 48 8B F1",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "RET Keybind Base",
                Pattern = "48 8B 05 ?? ?? ?? ?? 8B FA 48 8B F1",
                Offset1 = 3,
                Offset2 = 8
            },

            new Offset
            {
                Name = "TBC Add On Base",
                Pattern = "48 8D 0D ?? ?? ?? ?? 49 8B 5D",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "RET Add On Base",
                Pattern = "8B 15 ?? ?? ?? ?? 4C 8D 0D ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? 41 B8 ?? ?? ?? ?? 4C 8D 9C 24 ?? ?? ?? ??",
                Offset1 = 2,
                Offset2 = 7
            },

            new Offset
            {
                Name = "TBC Spellbook Base",
                Pattern = "48 8B 05 ?? ?? ?? ?? 48 8B 0C 18",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "RET Spellbook Base",
                Pattern = "44 8B 0D ?? ?? ?? ?? 33 D2 45 85 C9 74 ?? 4C 8B 15 ?? ?? ?? ?? 49 8B 0C D2 44 3B 41 ??",
                Offset1 = 3,
                Offset2 = 8
            },

            new Offset
            {
                Name = "TBC Spellbook Count",
                Pattern = "48 8B 05 ?? ?? ?? ?? 48 8B 0C 18",
                Offset1 = 3,
                Offset2 = 8,
                AddOffset = -0x8
            },
            new Offset
            {
                Name = "RET Spellbook Count",
                Pattern = "44 8B 0D ?? ?? ?? ?? 33 D2 45 85 C9 74 ?? 4C 8B 15 ?? ?? ?? ?? 49 8B 0C D2 44 3B 41 ??",
                Offset1 = 3,
                Offset2 = 8,
                AddOffset = -0x8
            },

            new Offset
            {
                Name = "TBC Pet Spellbook Base",
                Pattern = "4C 8B 0D ?? ?? ?? ?? 90 49 8B 0C D1 8B 41 ??",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "RET Pet Spellbook Base",
                Pattern = "4C 8B 0D ?? ?? ?? ?? 90 49 8B 0C D1 8B 41 ??",
                Offset1 = 3,
                Offset2 = 8
            },

            new Offset
            {
                Name = "TBC Pet Spellbook Count",
                Pattern = "4C 8B 0D ?? ?? ?? ?? 90 49 8B 0C D1 8B 41 ??",
                Offset1 = 3,
                Offset2 = 8,
                AddOffset = -0x8
            },
            new Offset
            {
                Name = "RET Pet Spellbook Count",
                Pattern = "4C 8B 0D ?? ?? ?? ?? 90 49 8B 0C D1 8B 41 ??",
                Offset1 = 3,
                Offset2 = 8,
                AddOffset = -0x8
            },

            new Offset
            {
                Name = "TBC Cooldown Base",
                Pattern = "48 8D 15 ?? ?? ?? ?? 48 1B C9 81 E1 ?? ?? ?? ?? 48 03 CA 8B 53 ??",
                Offset1 = 3,
                Offset2 = 8,
            },
            new Offset
            {
                Name = "RET Cooldown Base",
                Pattern = "48 8D 15 ?? ?? ?? ?? 48 1B C9 81 E1 ?? ?? ?? ?? 48 03 CA 8B 53 ??",
                Offset1 = 3,
                Offset2 = 8,
            },

            new Offset
            {
                Name = "TBC Camera Base",
                Pattern = "48 8B 05 ?? ?? ?? ?? 48 8B 88 ?? ?? ?? ?? 48 8B 43 ?? 48 39 81 ?? ?? ?? ??",
                Offset1 = 3,
                Offset2 = 8,
                Fields = new List<Field>
                {
                    new Field()
                    {
                        Name = "Camera Offset",
                        Offset1 = 10,
                        Offset2 = 15
                    }
                }
            },
            new Offset
            {
                Name = "RET Camera Base",
                Pattern = "48 8B 05 ?? ?? ?? ?? 48 8B 88 ?? ?? ?? ?? 48 8B 43 ?? 48 39 81 ?? ?? ?? ??",
                Offset1 = 3,
                Offset2 = 8,
                Fields = new List<Field>
                {
                    new Field()
                    {
                        Name = "Camera Offset",
                        Offset1 = 10,
                        Offset2 = 15
                    }
                }
            },

            new Offset
            {
                Name = "TBC Object Manager",
                Pattern = "48 8B 1D ?? ?? ?? ?? 48 85 DB 74 ?? 80 3D ?? ?? ?? ?? ?? 74 ?? 48 8D 0D ?? ?? ?? ??",
                Offset1 = 3,
                Offset2 = 8,
            },
            new Offset
            {
                Name = "RET Object Manager",
                Pattern = "48 8B 1D ?? ?? ?? ?? 48 85 DB 74 ?? 80 3D ?? ?? ?? ?? ?? 74 ?? 48 8D 0D ?? ?? ?? ??",
                Offset1 = 3,
                Offset2 = 8,
            },

            new Offset
            {
                Name = "TBC Player Name Cache",
                Pattern = "48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 4C 8B D0 48 85 C0 74 ??",
                Offset1 = 3,
                Offset2 = 8,
            },
            new Offset
            {
                Name = "RET Player Name Cache",
                Pattern = "48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 4C 8B D0 48 85 C0 74 ??",
                Offset1 = 3,
                Offset2 = 8,
            },
        };

        static void Main(string[] args)
        {
            if (!WoW.FindWow())
                Console.WriteLine("Could not find a classic, or retail client.");
            else
            {
                if (!WoW.GetHandle())
                    {Console.WriteLine("Could not get the client handle.");}
                else
                {
                    Console.WriteLine($"Loaded World of Warcraft {WoW.ClientVersion} {WoW.BuildVersion}");
                    Scanner = new Scan();
                }
            }

            if (null == Scanner)
                Console.WriteLine("Was unable to load the scanner.");
            else
            {
                foreach (var Offset in Offsets)
                {
                    var Pointer = Scanner.FindOffset(Offset);
                    if (Offset.Name.Contains("ERA"))
                    {
                        Console.WriteLine($"{Offset.Name} -> {Pointer.ToInt64()}");
                        if (Offset.Fields.Count > 0)
                            for (var i = 0; i < Offset.Fields.Count; i++)
                            {
                                Console.WriteLine($"{Offset.Fields[i].Name} -> " +
                                                  $"{Scanner.GetField(Offset, i).ToInt64()}");
                            }
                    }
                }
                foreach (var Offset in Offsets)
                {
                    var Pointer = Scanner.FindOffset(Offset);
                    if (Offset.Name.Contains("TBC"))
                    {
                        Console.WriteLine($"{Offset.Name} -> 0x{Pointer.ToInt64():X}");
                        if (Offset.Fields.Count > 0)
                            for (var i = 0; i < Offset.Fields.Count; i++)
                            {
                                Console.WriteLine($"{Offset.Fields[i].Name} -> " +
                                                  $"0x{Scanner.GetField(Offset, i).ToInt64():X}");
                            }
                    }
                }
                Console.WriteLine("");
                foreach (var Offset in Offsets)
                {
                    var Pointer = Scanner.FindOffset(Offset);
                    if (Offset.Name.Contains("RET"))
                        Console.WriteLine($"{Offset.Name} -> 0x{(Pointer.ToInt64())}");
                }
            }


            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

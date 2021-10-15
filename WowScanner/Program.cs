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
                Name = "Player Name",
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
                Name = "Player GUID",
                Pattern = "48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 83 BC 24 ?? ?? ?? ?? ?? 7C ?? 48 8B 8C 24 ?? ?? ?? ?? 48 8D 15 ?? ?? ?? ?? 45 33 C9 45 8D 41 ?? E8 ?? ?? ?? ?? 48 81 C4",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "Pet GUID",
                Pattern = "48 8B 05 ?? ?? ?? ?? 33 DB 45 8B E1",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "Mouseover GUID",
                Pattern = "48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 ?? 4C 8B C7 48 8D 0D ?? ?? ?? ??",
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
                Name = "Bag GUIDS",
                Pattern = "48 8D 0D ?? ?? ?? ?? 48 03 C0 0F 10 44 C1 ?? 0F 11 44 24 ?? EB",
                Offset1 = 3,
                Offset2 = 8
            },new Offset
            {
                Name = "Zone ID",
                Pattern = "8B 15 ?? ?? ?? ?? 4C 8D 4C 24 ?? 45 33 C0 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 75 ?? B8 ?? ?? ?? ??",
                Offset1 = 2,
                Offset2 = 7
            },
            new Offset
            {
                Name = "Game Status",
                Pattern = "0F B6 15 ?? ?? ?? ?? C1 EA ?? 83 E2 ?? E8 ?? ?? ?? ?? B8 ?? ?? ?? ?? 48 83 C4 ?? C3 40 53",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "Corpse Position",
                Pattern = "8B 05 ?? ?? ?? ?? 89 06 8B 05 ?? ?? ?? ?? 89 07 B0 ??",
                Offset1 = 2,
                Offset2 = 7,
                AddOffset = 0x40
            },
            new Offset
            {
                Name = "Loot Window",
                Pattern = "88 05 ?? ?? ?? ?? 85 DB",
                Offset1 = 2,
                Offset2 = 7
            },
            new Offset
            {
                Name = "Last Message",
                Pattern = "48 8D 0D ?? ?? ?? ?? 41 B8 ?? ?? ?? ?? 48 8D 95 ?? ?? ?? ?? 0F 1F 40 ??",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "Battleground Finished",
                Pattern = "83 3D ?? ?? ?? ?? ?? 0F 84 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CF",
                Offset1 = 2,
                Offset2 = 7,
                AddOffset = 1
            },
            new Offset
            {
                Name = "Battleground Winner",
                Pattern = "89 05 ?? ?? ?? ?? 89 1D ?? ?? ?? ?? 8B FB",
                Offset1 = 2,
                Offset2 = 7
            },
            new Offset
            {
                Name = "Battleground Info",
                Pattern = "48 8B 0D ?? ?? ?? ?? 33 C0 F6 C1 ?? 75 ?? 8B D0 48 85 C9 75 ?? BA ?? ?? ?? ?? 85 D2 8B 15 ?? ?? ?? ?? 48 0F 44 C1 66 0F 1F 44 00",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "Keybind Base",
                Pattern = "48 8B 05 ?? ?? ?? ?? 8B FA 48 8B F1",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "Add On Base",
                Pattern = "48 8D 0D ?? ?? ?? ?? 49 8B 5D",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "Spellbook Base",
                Pattern = "48 8B 05 ?? ?? ?? ?? 48 8B 0C 18",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "Spellbook Count",
                Pattern = "48 8B 05 ?? ?? ?? ?? 48 8B 0C 18",
                Offset1 = 3,
                Offset2 = 8,
                AddOffset = -0x8
            },
            new Offset
            {
                Name = "Pet Spellbook Base",
                Pattern = "4C 8B 0D ?? ?? ?? ?? 90 49 8B 0C D1 8B 41 ??",
                Offset1 = 3,
                Offset2 = 8
            },
            new Offset
            {
                Name = "Pet Spellbook Count",
                Pattern = "4C 8B 0D ?? ?? ?? ?? 90 49 8B 0C D1 8B 41 ??",
                Offset1 = 3,
                Offset2 = 8,
                AddOffset = -0x8
            },
            new Offset
            {
                Name = "Cooldown Base",
                Pattern = "48 8D 15 ?? ?? ?? ?? 48 1B C9 81 E1 ?? ?? ?? ?? 48 03 CA 8B 53 ??",
                Offset1 = 3,
                Offset2 = 8,
            },
            new Offset
            {
                Name = "Camera Base",
                Pattern = "48 8B 1D ?? ?? ?? ?? 48 85 DB 74 ?? E8 ?? ?? ?? ?? 84 C0",
                Offset1 = 3,
                Offset2 = 8,
            },
            new Offset
            {
                Name = "Object Manager",
                Pattern = "48 8B 1D ?? ?? ?? ?? 48 85 DB 74 ?? 80 3D ?? ?? ?? ?? ?? 74 ?? 48 8D 0D ?? ?? ?? ??",
                Offset1 = 3,
                Offset2 = 8,
            },
            new Offset
            {
                Name = "Player Name Cache",
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
                    Console.WriteLine("Could not get the client handle.");
                else Scanner = new Scan();
            }

            if (null == Scanner)
                Console.WriteLine("Was unable to load the scanner.");
            else
            {
                foreach (var Offset in Offsets)
                {
                    var Pointer = Scanner.FindOffset(Offset);
                    Console.WriteLine($"{Offset.Name} -> 0x{Pointer.ToInt64():X}");
                }
            }


            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

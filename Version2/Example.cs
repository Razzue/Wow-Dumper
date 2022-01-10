using Version2.Manager;

namespace Version2
{
    internal class ExampleTBC
    {
        internal static bool Load(Container C)
        {
            C.Classes = new List< _Class>
            {
                new _Class
                {
                    Name = "Guids",
                    Offsets = new[]
                    {
                        new _Offset
                        {
                            Name = "Mouseover Guid",
                            Pattern = "0F 10 05 ?? ?? ?? ?? EB ?? BA ?? ?? ?? ??",
                            Position = 3
                        },
                        new _Offset
                        {
                            Name = "Pet Guid",
                            Pattern = "48 8B 05 ?? ?? ?? ?? 33 DB 45 8B E1",
                            Position = 3
                        },
                        new _Offset
                        {
                            Name = "Player Guid",
                            Pattern = "48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 83 BC 24 ?? ?? ?? ?? ?? 7C ?? 48 8B 8C 24 ?? ?? ?? ?? 48 8D 15 ?? ?? ?? ?? 45 33 C9 45 8D 41 ?? E8 ?? ?? ?? ?? 48 81 C4",
                            Position = 3
                        },
                        new _Offset
                        {
                            Name = "Target Guid",
                            Pattern = "48 39 05 ?? ?? ?? ?? 75 ?? B1 ?? E8 ?? ?? ?? ?? 41 B8 ?? ?? ?? ??",
                            Position = 3,
                            Modifier = -0x8
                        },
                        new _Offset
                        {
                            Name = "Last Target Guid",
                            Pattern = "48 39 05 ?? ?? ?? ?? 75 ?? B1 ?? E8 ?? ?? ?? ?? 41 B8 ?? ?? ?? ??",
                            Position = 3,
                            Modifier = -0x8 + 0x10,
                        },
                        new _Offset
                        {
                            Name = "Last Enemy Guid",
                            Pattern = "48 39 05 ?? ?? ?? ?? 75 ?? B1 ?? E8 ?? ?? ?? ?? 41 B8 ?? ?? ?? ??",
                            Position = 3,
                            Modifier = -0x8 + 0x20,
                        },
                        new _Offset
                        {
                            Name = "Last Friendly Guid",
                            Pattern = "48 39 05 ?? ?? ?? ?? 75 ?? B1 ?? E8 ?? ?? ?? ?? 41 B8 ?? ?? ?? ??",
                            Position = 3,
                            Modifier = -0x8 + 0x30,
                        },
                        new _Offset
                        {
                            Name = "Focus Guid",
                            Pattern = "48 39 05 ?? ?? ?? ?? 75 ?? B1 ?? E8 ?? ?? ?? ?? 41 B8 ?? ?? ?? ??",
                            Position = 3,
                            Modifier = -0x8 + 0x40,
                        },
                        new _Offset
                        {
                            Name = "DialogWindowOwner Guid",
                            Pattern = "48 39 05 ?? ?? ?? ?? 75 ?? B1 ?? E8 ?? ?? ?? ?? 41 B8 ?? ?? ?? ??",
                            Position = 3,
                            Modifier = -0x8 + 0x50,
                        },
                        new _Offset
                        {
                            Name = "Bag Guid",
                            Pattern = "48 8D 0D ?? ?? ?? ?? 48 03 C0 0F 10 04 C1 0F 11 44 24 ?? 41 B9 ?? ?? ?? ?? 4C 8D 05 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8D 4C 24 ?? E8 ?? ?? ?? ?? 48 85 C0 74 ??",
                            Position = 3,
                        },
                    }
                }, // Guids
                new _Class
                {
                    Name = "Global Data",
                    Offsets = new []
                    {
                        new _Offset
                        {
                            Name = "In Game Status",
                            Pattern = "0F B6 15 ?? ?? ?? ?? C1 EA ?? 83 E2 ?? E8 ?? ?? ?? ?? B8 ?? ?? ?? ?? 48 83 C4 ?? C3 48 83 EC ??",
                            Position = 3
                        },
                        new _Offset
                        {
                            Name = "Player Name",
                            Pattern = "E8 ?? ?? ?? ?? 48 8D 4C 24 ?? 48 8B D8 E8 ?? ?? ?? ?? 4C 89 74 24",
                            Position = 1,
                            Levels = new []
                            {
                                new _Level { Position = 5 }
                            }
                        },
                        new _Offset
                        {
                            Name = "Corpse Position",
                            Pattern = "8B 05 ?? ?? ?? ?? 89 06 8B 05 ?? ?? ?? ?? 89 07 B0 ??",
                            Position = 2, 
                            Modifier = 0x40
                        },
                        new _Offset
                        {
                            Name = "Last Ui Message",
                            Pattern = "48 8D 05 ?? ?? ?? ?? C3 33 AB ?? ?? ?? ??",
                            Position = 3
                        },
                        new _Offset
                        {
                            Name = "Loot Window",
                            Pattern = "0F B6 15 ?? ?? ?? ?? 48 3B C1 0F 42 C8 E8 ?? ?? ?? ?? C7 05 ?? ?? ?? ?? ?? ?? ?? ??",
                            Position = 3
                        },
                    }
                }, // Globals
                new _Class
                {
                    Name = "Quests",
                    Offsets = new []
                    {
                        new _Offset
                        {
                            Name = "Base",
                            Pattern = "48 8D 05 ?? ?? ?? ?? 48 8D 0C 88",
                            Position = 3
                        },
                        new _Offset
                        {
                            Name = "NumQuests",
                            Pattern = "3B 0D ?? ?? ?? ?? 7D ?? 48 63 C1 48 8D 0C 40 48 8D 05 ?? ?? ?? ?? 48 8D 0C 88",
                            Position = 2
                        },
                        new _Offset
                        {
                            Name = "CurrentQuest",
                            Pattern = "8B 05 ?? ?? ?? ?? 89 01 48 8D 4C 24 ?? E8 ?? ?? ?? ?? 8B 0D ?? ?? ?? ??",
                            Position = 2
                        },
                        new _Offset
                        {
                            Name = "QuestTitle",
                            Pattern = "48 8D 05 ?? ?? ?? ?? BA ?? ?? ?? ?? 74 ??",
                            Position = 3
                        },
                        new _Offset
                        {
                            Name = "GossipQuests",
                            Pattern = "4C 8D 0D ?? ?? ?? ?? 4C 8D 1D ?? ?? ?? ?? 8B D8",
                            Position = 3
                        },
                        new _Offset
                        {
                            Name = "NumQuestChoices",
                            Pattern = "8B 0D ?? ?? ?? ?? 45 33 C9 85 C9 7E ?? 3B D9 7D ?? 85 DB 78 ?? 48 63 C3",
                            Position = 2
                        },
                        new _Offset
                        {
                            Name = "QuestReward",
                            Pattern = "48 8B 05 ?? ?? ?? ?? 44 8B 4C 01 ??",
                            Position = 3
                        },
                    }
                }, // Quests
                new _Class
                {
                    Name = "Auto Loot",
                    Offsets = new[]
                    {
                        new _Offset
                        {
                            Name = "Base",
                            Pattern = "48 8B 05 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 8B 58 ?? E8 ?? ?? ?? ??",
                            Position = 3,
                            Fields = new []
                            {
                                new _Field
                                {
                                    Type = ReadType.Byte,
                                    Name = "Offset",
                                    Position = 16
                                }
                            }
                        },
                    }
                }, // Auto Loot
                new _Class
                {
                    Name = "Click To Move",
                    Offsets = new[]
                    {
                        new _Offset
                        {
                            Name = "Base",
                            Pattern = "48 8B 05 ?? ?? ?? ?? 83 78 ?? ?? 74 ?? F6 81 ?? ?? ?? ?? ?? 75 ?? B0 ??",
                            Position = 3,
                            Fields = new []
                            {
                                new _Field
                                {
                                    Type = ReadType.Byte,
                                    Name = "Offset",
                                    Position = 9
                                }
                            }
                        },
                    }
                }, // Click to Move
                new _Class
                {
                    Name = "Chat",
                    Offsets = new[]
                    {
                        new _Offset
                        {
                            Name = "Open",
                            Pattern = "44 39 25 ?? ?? ?? ?? 0F 8E ?? ?? ?? ??",
                            Position = 3,
                        },
                        new _Offset
                        {
                            Name = "Start",
                            Pattern = "48 8D 15 ?? ?? ?? ?? 4C 8D 05 ?? ?? ?? ?? 80 BA ?? ?? ?? ?? ?? 74 ?? 8B 01 39 82 ?? ?? ?? ?? 74 ?? 48 81 C2 ?? ?? ?? ?? 49 3B D0 75 ?? 32 C0",
                            Position = 3,
                            Fields = new []
                            {
                                new _Field
                                {
                                    Type = ReadType.Word,
                                    Name = "Offset",
                                    Position = 36
                                },
                                new _Field
                                {
                                    Type = ReadType.Byte,
                                    Name = "Message",
                                    Position = 16
                                },
                            }
                        },
                    }
                }, // Chat Offsets
                new _Class
                {
                    Name = "Key Bindings",
                    Offsets = new[]
                    {
                        new _Offset
                        {
                            Name = "Base",
                            Pattern = "48 8B 05 ?? ?? ?? ?? 8B FA 48 8B F1",
                            Position = 3,
                        }
                    }
                }, // Key Bindings
                new _Class
                {
                    Name = "Add On",
                    Offsets = new[]
                    {
                        new _Offset
                        {
                            Name = "Base",
                            Pattern = "8B 15 ?? ?? ?? ?? 4C 8D 0D ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? 41 B8 ?? ?? ?? ?? 4C 8D 9C 24 ?? ?? ?? ??",
                            Position = 2,
                        }
                    }
                }, // Add On
                new _Class
                {
                    Name = "Spellbooks",
                    Offsets = new[]
                    {
                        new _Offset
                        {
                            Name = "Count",
                            Pattern = "44 8B 0D ?? ?? ?? ?? 33 D2 45 85 C9 74 ?? 4C 8B 15 ?? ?? ?? ?? 49 8B 0C D2 44 3B 41 ??",
                            Position = 3,
                        },
                        new _Offset
                        {
                            Name = "Base",
                            Pattern = "44 8B 0D ?? ?? ?? ?? 33 D2 45 85 C9 74 ?? 4C 8B 15 ?? ?? ?? ?? 49 8B 0C D2 44 3B 41 ??",
                            Position = 3,
                            Modifier = 0x8
                        },
                        new _Offset
                        {
                            Name = "PetBase",
                            Pattern = "4C 8B 0D ?? ?? ?? ?? 90 49 8B 0C D1 8B 41 ??",
                            Position = 3,
                            Modifier = 0x8
                        },
                        new _Offset
                        {
                            Name = "PetCount",
                            Pattern = "4C 8B 0D ?? ?? ?? ?? 90 49 8B 0C D1 8B 41 ??",
                            Position = 3,
                        },
                    }
                }, // Spellbooks
                new _Class
                {
                    Name = "Object Manager",
                    Offsets = new[]
                    {
                        new _Offset
                        {
                            Name = "Zone ID",
                            Pattern = "8B 15 ?? ?? ?? ?? 4C 8D 4C 24 ?? 45 33 C0 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 75 ?? B8 ?? ?? ?? ??",
                            Position = 2,
                        },
                        new _Offset
                        {
                            Name = "Names",
                            Pattern = "48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 4C 8B D0 48 85 C0 74 ??",
                            Position = 3,
                        },
                        new _Offset
                        {
                            Name = "Base",
                            Pattern = "48 8B 1D ?? ?? ?? ?? 48 85 DB 74 ?? 80 3D ?? ?? ?? ?? ?? 74 ?? 48 8D 0D ?? ?? ?? ??",
                            Position = 3,
                        },
                        new _Offset
                        {
                            Name = "Cooldown",
                            Pattern = "48 8D 15 ?? ?? ?? ?? 48 1B C9 81 E1 ?? ?? ?? ?? 48 03 CA 8B 53 ??",
                            Position = 3,
                        },
                    }
                }, // Object Manager
                new _Class
                {
                    Name = "Battlegrounds",
                    Offsets = new[]
                    {
                        new _Offset
                        {
                            Name = "Finished",
                            Pattern = "83 3D ?? ?? ?? ?? ?? 0F 84 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CF",
                            Position = 2,
                            Modifier = 0x1
                        },
                        new _Offset
                        {
                            Name = "Winner",
                            Pattern = "89 05 ?? ?? ?? ?? 89 1D ?? ?? ?? ?? 8B FB",
                            Position = 2,
                        },
                        new _Offset
                        {
                            Name = "Info",
                            Pattern = "48 8B 0D ?? ?? ?? ?? 33 C0 F6 C1 ?? 75 ?? 8B D0 48 85 C9 75 ?? BA ?? ?? ?? ?? 85 D2 8B 15 ?? ?? ?? ?? 48 0F 44 C1 66 0F 1F 44 00",
                            Position = 3,
                        },
                    }
                }, // Battleground Manager
                new _Class
                {
                    Name = "Camera",
                    Offsets = new[]
                    {
                        new _Offset
                        {
                            Name = "Base",
                            Pattern = "48 8B 05 ?? ?? ?? ?? 48 8B 88 ?? ?? ?? ?? 48 8B 43 ?? 48 39 81 ?? ?? ?? ??",
                            Position = 3,
                            Fields = new []
                            {
                                new _Field
                                {
                                    Type = ReadType.Word,
                                    Name = "Offset",
                                    Position = 10
                                }
                            }
                        }
                    }
                }  // Camera
            };
            return C.Classes is { Count: > 0 };
        }
    }
}
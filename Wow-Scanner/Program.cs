using Wow_Scanner;
using Wow_Scanner.Dumpers;

Console.WriteLine("Dumper will attach to first active classic client.");
Console.WriteLine("If no classic clients are open, it will attach to a retail client instead.");
Console.WriteLine("Press any key to continue...");
Console.ReadKey();

var CanContinue = false;

if (!WoW.FindWow())
    Console.WriteLine("Could not find a classic, or retail client.");
else
{
    if (!WoW.GetHandle())
       Console.WriteLine("Could not get the client handle."); 
    else
    {
        Console.WriteLine($"Loaded World of Warcraft {WoW.ClientVersion} {WoW.BuildVersion}");
        CanContinue = true;
    }
}

if (CanContinue)
{
    var Scanner = new Scan();
    var expac = WoW.ClientVersion.Split('.').FirstOrDefault();

    switch (expac)
    {
        case "Version 1":
            if (VanillaMastery.LoadOffsets(Scanner))
            {
                foreach (var offset in VanillaMastery.Offsets)
                    Console.WriteLine($"{offset.Key} -> 0x{offset.Value.ToInt64():X}");

                if (ClassWriter.SaveOffsetClass(VanillaMastery.Offsets))
                    Console.WriteLine("Offsets saved to class file.");
            }
            else Console.WriteLine("Could not load offsets?");
            break;

        case "Version 2":
            if (BurningCrusade.LoadOffsets(Scanner))
            {
                foreach (var offset in BurningCrusade.Offsets)
                    Console.WriteLine($"{offset.Key} -> 0x{offset.Value.ToInt64():X}"); 
                // if (ClassWriter.SaveOffsetClass(BurningCrusade.Offsets))
                    // Console.WriteLine("Offsets saved to class file.");
            }
            else Console.WriteLine("Could not load offsets?");
            break;

        case "Version 9":
            if (Shadowlands.LoadOffsets(Scanner))
            {
                foreach (var offset in Shadowlands.Offsets)
                    Console.WriteLine($"{offset.Key} -> 0x{offset.Value.ToInt64():X}");

                if (ClassWriter.SaveOffsetClass(Shadowlands.Offsets))
                    Console.WriteLine("Offsets saved to class file.");
            }
            else Console.WriteLine("Could not load offsets?"); 
                break;

        default:
            Console.WriteLine("Could not load the client expansion.");
            break;
    }

    
}


Console.WriteLine("Press any key to exit.");
Console.ReadKey();


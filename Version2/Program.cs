// Input process id and press enter. 
// Will regex out everything except numbers, and try to parse value.

using System.Text.RegularExpressions;
using Version2;
using Version2.Helpers;
using Version2.Manager;
using Version2.Writer;

// Enter process id to attach to process.
Write.General("Enter process id you wish to attach to, then press enter.");
var str = Console.ReadLine();

// Try to parse console entry
if (string.IsNullOrEmpty(str) || !int.TryParse(str, out var PID))
    Write.Error("Could not parse input.");
else
{
    // Attempt to attach to entered process
    if (!Client.Attach(PID))
        Write.Error("Could not attach to process");
    else
    {
        Write.Success($"Attached to {Client.Proc?.MainWindowTitle}");
        Write.Message($"Base Address    -> 0x{Client.Base.ToInt64():X}");
        Write.Message($"Proc Handle     -> 0x{Client.Handle.ToInt64():X}");
        Write.Message($"Version         -> {Client.Version}");

        // Create a new instance of the scanner and container class.
        var c = new Container();
        var s = new Scan();

        // Try to load the example patterns
        var Loaded = ExampleSOM.Load(c);

        var exp = Client.Version.Split('.').FirstOrDefault();
        switch (exp)
        {
            case "1":
                Loaded = ExampleSOM.Load(c);
                break;

            case "2":
                Loaded = ExampleTBC.Load(c);
                break;

            case "3":
                Write.Warning("Wrath of the Lich King is not implemented.");
                break;

            case "4":
                Write.Warning("Cataclysm is not implemented.");
                break;

            case "5":
                Write.Warning("Mists of Pandaria is not implemented.");
                break;

            case "6":
                Write.Warning("Warlords of Draenor is not implemented.");
                break;

            case "7":
                Write.Warning("Legion is not implemented.");
                break;

            case "8":
                Write.Warning("Battle for Azeroth is not implemented.");
                break;

            case "9":
                Write.Warning("Shadowlands is not implemented.");
                break;

        }

        if (!Loaded)
            Write.Error("Could not load patterns.");
        else
        {
            // Try to get offsets, may take a hot minute.
            if (!s.TryGetOffsets(c))
                Write.Error("Could not load any offsets.");
            else
            {
                Write.Success($"Loaded {c.Loaded.Count} classes");
                if (!DomWriter.Write(c))
                    Write.Error("Could not save offsets to class.");
                else Write.Success("Offsets have been saved to .cs!");

                Console.WriteLine(""); // Just a separator.
                foreach (var pair1 in c.Loaded)
                {
                    var r = new Regex("[^a-zA-Z0-9-> -]");
                    Write.General(r.Replace($"--- {pair1.Key} ---", ""));
                    foreach (var pair2 in pair1.Value)
                        Write.Message(r.Replace($"{pair2.Key}  -> 0x{pair2.Value.ToInt64():X}", ""));
                }
            }
        }

        if (Loaded)
            if (!c.Save("OffsetExample"))
                Write.Error("Could not save patterns to file.");
        else Write.Success("Patterns have been saved to .json!");
    }
}

Write.General("Press any key to exit.");
Console.ReadKey();
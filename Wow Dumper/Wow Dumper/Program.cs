using System.Text.RegularExpressions;
using Wow_Dumper;
using Wow_Dumper.Helpers;
using Wow_Dumper.Patterns;

Console.WriteLine("Enter the id of the process you want to attach to, then hit enter.");
var str1 = Console.ReadLine();

if (string.IsNullOrEmpty(str1))
    Console.WriteLine("Could not read input text.");
else
{
    str1 = Regex.Replace(str1, "[^0-9]", "");
    if (!int.TryParse(str1, out var int1))
        Console.WriteLine("Could not parse input to int32.");
    else
    {
        if (!Client.Attach(int1))
            Console.WriteLine("Could not attach to selected client");
        else
        {
            Console.Clear();
            Console.WriteLine($@"Attached to process {int1}
Base    -> 0x{Client.Base.ToInt64():X}
Handle  -> 0x{Client.Handle.ToInt64():X}
Version -> {Client.ClientVersion},
Build   -> {Client.BuildVersion}
");

            var manager = new Manager();
            Example.Load(manager);

            foreach (var C in manager.Patterns)
            {
                Console.WriteLine($"\n--- [{C.Name}] ---");
                foreach (var o in C.Offsets)
                {
                    if (Scan.GetOffset(o, out var offset))
                        Console.WriteLine($"{o.Name}  -> 0x{offset.ToInt64():X}");
                }
            }

            foreach (var o in manager.Patterns.FirstOrDefault().Offsets)
            {
                
            }
        }
    }
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
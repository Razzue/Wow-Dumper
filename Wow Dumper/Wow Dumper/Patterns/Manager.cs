using Newtonsoft.Json;

namespace Wow_Dumper.Patterns
{
    internal class Manager
    {
        private static string Time => $"[{DateTime.Now.ToShortTimeString()}]";
        internal List<ClassBase>? Patterns;

        internal bool Save(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Input file name is null or empty.");

                if (null == Patterns || Patterns.Count <= 0)
                    throw new Exception("There are no patterns to save.");

                var dir = $@"{Environment.CurrentDirectory}\Patterns";
                Directory.CreateDirectory(dir);

                var path = $@"{dir}\{name}.json";
                var str = JsonConvert.SerializeObject(Patterns, Formatting.Indented);

                if (string.IsNullOrEmpty(str))
                    throw new Exception("Could not serialize pattern list.");

                File.WriteAllText(path, str);
                return File.Exists(path);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{Time} {e.Message}");
                return false;
            }
        }

        internal bool Load(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Input file name is null or empty.");

                var path = $@"{Environment.CurrentDirectory}\Patterns\{name}.json";
                if (!File.Exists(path))
                    throw new Exception("Could not find file by input name.");

                var str = File.ReadAllText(path);
                if (string.IsNullOrEmpty(str))
                    throw new Exception("Could not read any text from file.");

                Patterns = JsonConvert.DeserializeObject<List<ClassBase>>(str);
                if (Patterns is not { Count: > 0 })
                    throw new Exception("Could not deserialize loaded file.");

                return Patterns is { Count: > 0 };
            }
            catch (Exception e)
            {
                Console.WriteLine($"{Time} {e.Message}");
                return false;
            }
        }
    }
}
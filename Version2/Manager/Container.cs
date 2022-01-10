using Newtonsoft.Json;
using Version2.Writer;

namespace Version2.Manager
{
    internal class Container
    {
        internal List<_Class>? Classes;
        internal Dictionary<string, Dictionary<string, IntPtr>>? Loaded;

        internal bool Save(string FileName)
        {
            try
            {
                if (string.IsNullOrEmpty(FileName))
                    throw new Exception("Input file name is null or empty.");

                if (null == Classes || Classes.Count <= 0)
                    throw new Exception("There is nothing to save.");

                var dir = $@"{Environment.CurrentDirectory}\Patterns";
                Directory.CreateDirectory(dir);

                var path = $@"{dir}\{FileName}.json";
                var str = JsonConvert.SerializeObject(Classes, Formatting.Indented);

                if (string.IsNullOrEmpty(str))
                    throw new Exception("Could not serialize pattern list.");

                if (File.Exists(path))
                    File.Delete(path);

                File.WriteAllText(path, str);
                return File.Exists(path);
            }
            catch (Exception ex)
            {
                Write.Error(ex.Message);
                return false;
            }
        }
        internal bool Load(string FileName)
        {
            try
            {
                if (string.IsNullOrEmpty(FileName))
                    throw new Exception("File name is null or empty.");

                var path = $@"{Environment.CurrentDirectory}\Patterns\{FileName}.json";
                if (!File.Exists(path))
                    throw new Exception("Could not find file.");

                var str = File.ReadAllText(path);
                if (string.IsNullOrEmpty(str))
                    throw new Exception("File is blank.");

                Classes = JsonConvert.DeserializeObject<List<_Class>>(str);
                if (Classes is not { Count: > 0 })
                    throw new Exception("Could not deserialize loaded file.");

                return Classes is { Count: > 0 };
            }
            catch (Exception ex)
            {
                Write.Error(ex.Message);
                return false;
            }
        }
    }
}
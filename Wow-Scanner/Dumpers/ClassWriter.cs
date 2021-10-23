using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;

namespace Wow_Scanner.Dumpers
{
    internal class ClassWriter
    {
        private static CodeCompileUnit OffsetUnit;
        private static CodeNamespace OffsetNamespace;
        private static CodeTypeDeclaration OffsetClass;

        internal static bool SaveOffsetClass(Dictionary<string, IntPtr> Offsets)
        {
            try
            {
                OffsetUnit = new CodeCompileUnit();
                OffsetNamespace = new CodeNamespace("Dumper.Offsets");

                OffsetClass = new CodeTypeDeclaration("WowOffsets")
                {
                    IsClass = true,
                    TypeAttributes = TypeAttributes.Public
                };

                foreach (var p in Offsets)
                    OffsetClass.Members.Add(new CodeSnippetTypeMember($"        public const int {p.Key} = 0x{p.Value.ToInt64():X};"));

                OffsetNamespace.Types.Add(OffsetClass);
                OffsetUnit.Namespaces.Add(OffsetNamespace);
                return SaveFile();
            }
            catch (Exception)
            {
                return false;
            }    

        }

        private static bool SaveFile()
        {
            try
            {
                var Path = $@"{Environment.CurrentDirectory}\Offsets.cs";
                var provider = CodeDomProvider.CreateProvider("CSharp");
                var providerOptions = new CodeGeneratorOptions()
                {
                    BlankLinesBetweenMembers = true,
                    BracingStyle = "C"
                };

                using var Writer = new StreamWriter(Path);
                provider.GenerateCodeFromCompileUnit(OffsetUnit, Writer, providerOptions);

                return File.Exists(Path);
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}

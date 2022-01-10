using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text.RegularExpressions;
using Version2.Helpers;
using Version2.Manager;

namespace Version2.Writer
{
    internal class DomWriter
    {
        internal static bool Write(Container C)
        {
            try
            {
                if (null == C.Classes || C.Classes.Count <= 0)
                    throw new Exception("No patterns have been loaded.");

                if (null == C.Loaded || C.Loaded.Count <= 0)
                    throw new Exception("No offsets have been loaded.");

                var r = new Regex("[^a-zA-Z0-9-> -]");
                var _ccu = new CodeCompileUnit();
                var _space = new CodeNamespace("Offset_Manager");
                var _class = new CodeTypeDeclaration($"Offsets_{Client.Build}")
                {
                    IsClass = true,
                    TypeAttributes = TypeAttributes.Public
                };

                foreach (var entry in C.Classes)
                {
                    if (!C.Loaded.TryGetValue(entry.Name, out var v1)) continue;

                    var name = r.Replace(entry.Name, "").Replace(" ", "_");
                    var _class2 = new CodeTypeDeclaration(name)
                    {
                        IsClass = true,
                        TypeAttributes = TypeAttributes.Public
                    };

                    if (entry.Offsets is not { Length: > 0 }) continue;
                    foreach (var oEntry in entry.Offsets)
                    {
                        if (!v1.TryGetValue(oEntry.Name, out var v2)) continue;
                        name = r.Replace(oEntry.Name, "").Replace(" ", "_");
                        _class2.Members.Add(new CodeMemberField(typeof(int), name)
                        {
                            Attributes = MemberAttributes.Public | MemberAttributes.Const,
                            InitExpression = new CodeSnippetExpression($"0x{v2.ToInt64():X}")
                        });

                        if (oEntry.Fields is not { Length: > 0 }) continue;
                        foreach (var fEntry in oEntry.Fields)
                        {
                            if (!v1.TryGetValue(fEntry.Name, out var v3)) continue;
                            name = r.Replace(fEntry.Name, "").Replace(" ", "_");
                            _class2.Members.Add(new CodeMemberField(typeof(int), name)
                            {
                                Attributes = MemberAttributes.Public | MemberAttributes.Const,
                                InitExpression = new CodeSnippetExpression($"0x{v3.ToInt64():X}")
                            });
                        }
                    }
                    _class.Members.Add(_class2);
                }

                _space.Types.Add(_class);
                _ccu.Namespaces.Add(_space);

                var str = $@"{Environment.CurrentDirectory}\Offsets.cs";
                var provider = CodeDomProvider.CreateProvider("CSharp");
                var providerOptions = new CodeGeneratorOptions()
                {
                    BlankLinesBetweenMembers = true,
                    BracingStyle = "C"
                };
                using (var Writer = new StreamWriter(str))
                    provider.GenerateCodeFromCompileUnit(_ccu, Writer, providerOptions);

                return File.Exists(str);
            }
            catch (Exception e)
            {
                Writer.Write.Error(e.Message);
                return false;
            }
        }
    }
}
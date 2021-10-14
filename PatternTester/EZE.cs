using System.Reflection;

[assembly: Obfuscation(Feature = "debug [secure]", Exclude = false)]
[assembly: Obfuscation(Feature = "apply to type *: apply to member * when method or internal: virtualization", Exclude = false)]
[assembly: Obfuscation(Feature = "code control flow obfuscation", Exclude = false)]
[assembly: Obfuscation(Feature = "encrypt symbol names with password MochaBeanIsDaBomb", Exclude = false)]
[assembly: Obfuscation(Feature = "embed [no-compress] Reloaded.Memory.dll", Exclude = false)]
[assembly: Obfuscation(Feature = "embed [no-compress] Reloaded.Memory.Sigscan.dll", Exclude = false)]
[assembly: Obfuscation(Feature = "embed [no-compress] System.Memory.dll", Exclude = false)]
[assembly: Obfuscation(Feature = "embed [no-compress] System.Buffers.dll", Exclude = false)]
[assembly: Obfuscation(Feature = "embed [no-compress] System.Numerics.Vectors", Exclude = false)]
[assembly: Obfuscation(Feature = "embed [no-compress] System.Runtime.CompilerServices.Unsafe.dll", Exclude = false)]
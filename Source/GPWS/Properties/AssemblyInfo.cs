using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("KSP_GPWS")]
[assembly: AssemblyDescription("Adds warning sounds for KSP")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("L Aerospace/KSP Division")]
[assembly: AssemblyProduct("GPWS /L Unofficial")]
[assembly: AssemblyCopyright("© 2021 LisiasT")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//[assembly: AssemblyInformationalVersionAttribute("<%= git_version %>")]
[assembly: AssemblyVersion(GPWS.Version.Number)]
[assembly: AssemblyFileVersion(GPWS.Version.Number)]

[assembly: KSPAssembly("KSP_GPWS", GPWS.Version.major, GPWS.Version.minor)]
[assembly: KSPAssemblyDependency("KSPe", 2, 3)]
[assembly: KSPAssemblyDependency("KSPe.UI", 2, 3)]
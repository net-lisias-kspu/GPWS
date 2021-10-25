using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("GPWS /L Unleashed")]
[assembly: AssemblyDescription("Adds warning sounds for KSP")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(KSP_GPWS.LegalMamboJambo.Company)]
[assembly: AssemblyProduct(KSP_GPWS.LegalMamboJambo.Product)]
[assembly: AssemblyCopyright(KSP_GPWS.LegalMamboJambo.Copyright)]
[assembly: AssemblyTrademark(KSP_GPWS.LegalMamboJambo.Trademark)]
[assembly: AssemblyCulture("")]

//[assembly: AssemblyInformationalVersionAttribute("<%= git_version %>")]
[assembly: AssemblyVersion(KSP_GPWS.Version.Number)]
[assembly: AssemblyFileVersion(KSP_GPWS.Version.Number)]

[assembly: KSPAssemblyDependency("KSPe", 2, 3)]
[assembly: KSPAssemblyDependency("KSPe.UI", 2, 3)]
[assembly: KSPAssemblyDependency("KSPe.HMI", 2, 3)][assembly: KSPAssembly("KSP_GPWS", KSP_GPWS.Version.major, KSP_GPWS.Version.minor)]
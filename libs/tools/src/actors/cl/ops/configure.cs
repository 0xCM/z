//-----------------------------------------------------------------------------
// Copyright   :  Copyright 2020 Aaron R Robinson
// License     :  See Robinson.lic in project license directory
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;
    using System.Text;

    partial struct Vc
    {
        public static CmdLine cl(ClCmdInfo cmdinfo, FS.FolderPath vsdir)
        {
            var winSdk = WinSdk.latest();
            var vcToolDir = Vc.vcinfo(vsdir).ToolVersionRoot;

            bool isDebug = IsDebug(cmdinfo.Configuration);
            bool is64Bit = Is64BitTarget(cmdinfo.Architecture, cmdinfo.RuntimeID);

            var archDir = is64Bit ? FS.folder("x64") : FS.folder("x86");

            // VC inc and lib paths
            var vcIncDir = vcToolDir +  FS.folder("include");
            var libDir = vcToolDir + FS.folder("lib") + archDir;
            var binDir = vcToolDir + FS.folder("bin\\Hostx64") + archDir;

            // Create arguments
            var compilerFlags = new StringBuilder();
            var linkerFlags = new StringBuilder();
            SetConfigurationBasedFlags(isDebug, ref compilerFlags, ref linkerFlags);

            // Set compiler flags
            compilerFlags.Append($"/TC /MT /GS /Zi ");
            compilerFlags.Append($"/D DNNE_ASSEMBLY_NAME={cmdinfo.AssemblyName} /D DNNE_COMPILE_AS_SOURCE ");
            compilerFlags.Append($"/I \"{vcIncDir}\" /I \"{cmdinfo.PlatformPath}\" /I \"{cmdinfo.NetHostPath}\" ");

            // Add WinSDK inc paths
            foreach (var incPath in winSdk.IncPaths)
                compilerFlags.Append($"/I \"{incPath}\" ");

            // Add user defined inc paths last - these will be searched last on MSVC.
            // https://docs.microsoft.com/cpp/build/reference/i-additional-include-directories#remarks
            foreach (var incPath in cmdinfo.UserIncludes)
                compilerFlags.Append($"/I \"{incPath.Format(PathSeparator.BS)}\" ");

            // compilerFlags.Append($"\"{export.Source}\" \"{Path.Combine(export.PlatformPath, "platform.c")}\" ");

            // Set linker flags
            linkerFlags.Append($"/DLL ");
            linkerFlags.Append($"/LIBPATH:\"{libDir}\" ");

            // Add WinSDK lib paths
            foreach (var libPath in winSdk.LibPaths)
            {
                var combined = libPath + archDir;
                linkerFlags.Append($"/LIBPATH:\"{combined.Format(PathSeparator.BS)}\" ");
            }

            var nethost = cmdinfo.NetHostPath + FS.file("nethost.lib");
            linkerFlags.Append($"\"{nethost.Format(PathSeparator.BS)}\" Advapi32.lib ");
            linkerFlags.Append($"/IGNORE:4099 "); // libnethost.lib doesn't ship PDBs so linker warnings occur.

            // Define artifact names
            var outputPath = cmdinfo.OutputPath + cmdinfo.OutputName;
            var impLibPath = Path.ChangeExtension(outputPath, ".lib");
            linkerFlags.Append($"/IMPLIB:\"{impLibPath}\" /OUT:\"{outputPath}\" ");

            var cmd = (binDir + FS.file("cl.exe")).Name;
            var args = $"{compilerFlags} /link {linkerFlags}";
            return new CmdLine(cmd, args);
        }

        static bool Is64BitTarget(string arch, string rid)
        {
            return arch.ToLower() switch
            {
                "x64" => true,
                "amd64" => true,
                "x86" => false,
                "msil" => rid.Contains("x64"), // e.g. win-x86, win-x64, etc
                _ => IntPtr.Size == 8, // Fallback is the process bitness
            };
        }

        static bool IsDebug(string config)
            => "Debug".Equals(config);

        static void SetConfigurationBasedFlags(bool isDebug, ref StringBuilder compiler, ref StringBuilder linker)
        {
            if (isDebug)
            {
                compiler.Append($"/Od /LDd ");
                linker.Append($"");
            }
            else
            {
                compiler.Append($"/O2 /LD ");
                linker.Append($"");
            }
        }
    }
}
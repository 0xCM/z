//-----------------------------------------------------------------------------
// Copyright   :  Copyright 2020 Aaron R Robinson
// License     :  See Robinson.lic in project license directory
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.IO;

    using static sys;

    public struct VcInfo
    {
        public FolderPath VsRoot;

        public FolderPath ToolRoot;

        public Version128 Version;

        public FolderPath ToolVersionRoot;

        public static VcInfo Empty
            => default;

        public bool IsEmpty
            => ToolRoot.IsEmpty;
    }
    
    public struct WinSdkInfo
    {
        public string Version;

        public EnvPath IncPaths;

        public EnvPath LibPaths;

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendLineFormat("SdkVer:{0}", Version);
            dst.AppendLineFormat("/I{0}", IncPaths.Format());
            dst.AppendLineFormat("/LIBPATH {0}", LibPaths.Format());
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
    
    partial struct Vc
    {
        [Op]
        public static WinSdkInfo winsdk()
        {
            using (var kits = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows Kits\Installed Roots"))
            {
                string win10sdkRoot = (string)kits.GetValue("KitsRoot10");

                // Sort the entries in descending order as
                // to defer to the latest version.
                var versions = new SortedList<Version, string>(new VersionDescendingOrder());

                // Collect the possible SDK versions.
                foreach (var verMaybe in kits.GetSubKeyNames())
                {
                    if (!Version.TryParse(verMaybe, out Version versionMaybe))
                        continue;

                    versions.Add(versionMaybe, verMaybe);
                }

                // Find the latest version of the SDK.
                foreach (var version in versions)
                {
                    // WinSDK inc and lib paths
                    var incDir = FS.dir(Path.Combine(win10sdkRoot, "Include", version.Value));
                    var libDir = FS.dir(Path.Combine(win10sdkRoot, "Lib", version.Value));
                    if (!incDir.Exists || !libDir.Exists)
                        continue;

                    var sharedIncDir = incDir +  FS.folder("shared");
                    var umIncDir =  incDir + FS.folder("um");
                    var ucrtIncDir = incDir + FS.folder("ucrt");
                    var umLibDir = libDir + FS.folder("um");
                    var ucrtLibDir = libDir + FS.folder("ucrt");

                    return new WinSdkInfo()
                    {
                        Version = version.Value,
                        IncPaths = array(sharedIncDir, umIncDir, ucrtIncDir),
                        LibPaths = array(umLibDir, ucrtLibDir),
                    };
                }
            }

            throw new Exception("No Win10 SDK version found.");
        }

        public static CmdLine cl(ClCmdInfo cmdinfo, FolderPath vsdir)
        {
            var winSdk = winsdk();
            var vcToolDir = vcinfo(vsdir).ToolVersionRoot;

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

        readonly struct VersionDescendingOrder : IComparer<Version>
        {
            public int Compare(Version x, Version y)
                => y.CompareTo(x);
        }
    }
}
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

    using static core;

    partial class WinSdk
    {
        [Op]
        public static WinSdkInfo latest()
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

        readonly struct VersionDescendingOrder : IComparer<Version>
        {
            public int Compare(Version x, Version y)
                => y.CompareTo(x);
        }
    }
}
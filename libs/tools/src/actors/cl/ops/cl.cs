//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial struct Vc
    {
        [Op]
        public static VcInfo vcinfo(FolderPath vsroot)
        {
            var dst = VcInfo.Empty;
            dst.VsRoot = vsroot;
            dst.ToolRoot = vsroot + FS.folder("VC\\Tools\\MSVC\\");
            var version = new Version();
            string latestPath = null;
            foreach(var subdir in dst.ToolRoot.SubDirs())
            {
                var vdir = Path.GetFileName(subdir.Name);
                if (!Version.TryParse(vdir, out Version v) || v < version)
                    continue;

                dst.Version = v;
                version = v;
                dst.ToolVersionRoot = subdir;
            }

            return dst;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ProjectModels;

    partial class ProjectServices
    {
       public static ConfigFile configuration(FolderPath root)
            => new ConfigFile(root + FS.file("config", FileKind.Cmd), Z0.Settings.cmd(root + FS.file("config", FileKind.Cmd)));   
    }
}
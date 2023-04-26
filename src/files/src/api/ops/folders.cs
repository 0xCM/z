//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial struct FS
    {
        public static IEnumerable<FolderPath> folders(FolderPath root, string match, bool recurse = true)
            => Directory.Exists(root.Name) ? Directory.EnumerateDirectories(root.Name, match, options(recurse)).Select(FS.dir) : sys.empty<FolderPath>();

        public static IEnumerable<FolderPath> folders(FolderPath root, bool recurse = true)
            => folders(root, "*", recurse);
    }
}
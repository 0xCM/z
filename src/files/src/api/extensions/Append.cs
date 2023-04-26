//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial class XTend
    {
        public static FilePath Path(this Assembly src)
            => FS.path(src.Location);

        public static FolderPath Folder(this Assembly src)
            => src.Path().FolderPath;

        public static void Append(this FilePath dst, params string[] src)
        {
            using var writer = new StreamWriter(dst.EnsureParentExists().Name, true);
            foreach(var line in src)
                writer.WriteLine(line);
        }

        public static void Append(this FilePath dst, string src)
            => File.AppendAllText(dst.Name, src);
    }
}
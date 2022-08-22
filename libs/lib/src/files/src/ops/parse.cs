//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct FS
    {
        public static bool parse(char sep, string src, out FolderPaths dst)
        {
            var result = true;
            dst = FolderPaths.Empty;
            var i = text.index(src, sep);
            if(i > 0)
            {
                var parts = text.split(src, sep);
                var count = parts.Length;
                dst = sys.alloc<FS.FolderPath>(count);
                for(var j=0; j<count; j++)
                    dst[j] = FS.dir(skip(parts,j));
            }
            else
                dst = new FolderPaths(new FS.FolderPath[]{FS.dir(src)});
            return result;
        }

        public static bool parse(string src, out FolderPaths dst)
            => parse(Chars.Semicolon, src, out dst);
    }
}